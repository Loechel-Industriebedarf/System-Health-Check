using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemHealth
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        /*
         * When the form is loaded, a timer is started. Every 10 minutes the function StartAllChecks() gets executed.
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            //Starts all checks
            StartAllChecks();

            //Starts all checks again after 10 Minutes
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 600000; //Time in milliseconds - 60 seconds * 10 minutes * 1000 milliseconds
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        /*
         * Helper function, that gets executed, when the timer from Form1_Load runs out.
         */
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            StartAllChecks();
        }


        /*
         * Primary function. Executes all checks for example Amazon errors or programs that are not running.
         */
        private void StartAllChecks()
        {
            try
            {
                updateProgressBar.BeginInvoke(new MethodInvoker(() =>
                {
                    updateProgressBar.Value = 0;
                    Int32 processCount = 0;

                    CheckOrderCount(ebayOrdersButton, "BELEGART = '8' OR BELEGART = '11' OR BELEGART = '12' OR BELEGART = '14' OR BELEGART = '18'");
                    updateProgressBar.PerformStep();

                    CheckOrderCount(amazonOrdersButton, "BELEGART = '7'");
                    updateProgressBar.PerformStep();

                    processCount = ExecutePowershellProcessCount("ConvCold", "server-01");
                    CheckProcessCount(nwInvoiceButton, processCount, processCount == 1, "Die Rechnungsverarbeitung von Nordwest läuft derzeit nicht.");
                    updateProgressBar.PerformStep();

                    processCount = ExecutePowershellProcessCount("DHL");
                    CheckProcessCount(dhlProcessButton, processCount, processCount != 1, "");
                    updateProgressBar.PerformStep();

                    processCount = ExecutePowershellProcessCount("Amazon");
                    CheckProcessCount(amazonProcessButton, processCount, processCount == 2, "Die Amazon Prozesse scheinen nicht zu laufen.");
                    updateProgressBar.PerformStep();

                    processCount = ExecutePowershellProcessCount("timeout") + ExecutePowershellProcessCount("cmd");
                    CheckProcessCount(ebayProcessButton, processCount, processCount >= 1, "Die Ebay Prozesse scheinen nicht zu laufen.");
                    updateProgressBar.PerformStep();

                    CheckForErrorFiles(errorFilesButton, "S:\\", "*ERROR*.csv", "Es gibt ERROR Files bei den Bestellabholungen.");
                    updateProgressBar.PerformStep();

                    CheckForErrorFiles(picardErrorFilesButton, "W:\\Picard\\DESADV\\ERROR", "*.xml", "Es gibt ERROR Files bei Picard.");
                    updateProgressBar.PerformStep();

                    CheckForErrorFiles(mercateoErrorFilesButton, "W:\\Mercateo\\ORDERS\\ERROR", "*.xml", "Es gibt ERROR Files bei Mercateo.");
                    updateProgressBar.PerformStep();

                    CheckForErrorFiles(toolineoErrorFilesButton, "W:\\Toolineo\\ORDERS\\ERROR", "*.xml", "Es gibt ERROR Files bei Toolineo.");
                    updateProgressBar.PerformStep();

                    CheckDHLDPDApi();
                    updateProgressBar.PerformStep();

                    CheckLastOrderExecute();
                    updateProgressBar.PerformStep();

                    updateProgressBar.Value = 100;
                }));

                //Write the current date to a label on the gui
                lastUpdatedLabel.BeginInvoke(new MethodInvoker(() =>
                {
                    lastUpdatedLabel.Text = "Letztes Update: " + DateTime.Now.ToString("HH:mm:ss");
                }));
            }
            catch(Exception ex)
            {

            }
        }



        /*
         * @param Button b                      The button, that should be updated, based on the functions result (color/text)
         * @param String whereQuery             A where query to restrict the sql-query further
         */
        private void CheckOrderCount(Button b, String whereQuery)
        {
            OdbcDataReader dr =
                ExecuteReadSql("SELECT COUNT(*) AS Counter FROM dbo.AUFTRAGSKOPF WHERE (" + whereQuery + ") AND ERFASSUNGSDATUM > DATEADD(HOUR, -1, GETDATE())");

            while (dr.Read())
            {
                String orderCounter = dr["Counter"].ToString();

                b.BeginInvoke(new MethodInvoker(() =>
                {
                    b.Text = orderCounter;

                    if (Convert.ToInt32(orderCounter) >= 1)
                    {
                        b.BackColor = Color.Green;
                    }
                    else
                    {
                        b.BackColor = Color.Red;
                    }

                }));
            }
        }



        /*
         * @param String powershellProcessName  The name of the process we are looking for
         * @param String server                 The server, on which the powershell script should be executed (default: server-03)
         * @return Int32 processCount           Number of processes the powershell script found
         */
        private Int32 ExecutePowershellProcessCount(String powershellProcessName)
        {
            return ExecutePowershellProcessCount(powershellProcessName, "server-03");
        }
        private Int32 ExecutePowershellProcessCount(String powershellProcessName, String server)
        {
            using (PowerShell ps = PowerShell.Create())
            {
                // specify the script code to run.
                ps.AddScript("Invoke-Command -ComputerName " + server + " -ScriptBlock { (Get-Process | Where-Object {$_.Name -match '" + powershellProcessName + "'}).count }");

                // execute the script and await the result.
                var pipelineObjects = ps.Invoke();

                Int32 processCount = 0;

                // print the resulting pipeline objects to the console.
                foreach (var item in pipelineObjects)
                {
                    processCount = Convert.ToInt32(item.BaseObject.ToString());
                }

                return processCount;
            }
        }



        /*
         * @param Button b                      The button, that should be updated, based on the functions result (color/text)
         * @param Boolean check                 True/false condition to choose, which color/text the button should get (Example: processCount == 1)
         * @param String errorMsg               Error message, that will be displayed, if check is false. If the errorMsg is empty, no message will be shown
         *                                          and the button will be yellow instead of red
         */
        private void CheckProcessCount(Button b, Int32 processCount, Boolean check, String errorMsg)
        {
            b.BeginInvoke(new MethodInvoker(() =>
            {
                if (check)
                {
                    b.Text = "OK";
                    b.BackColor = Color.Green;
                }
                else
                {
                    b.Text = "X";
                    if (String.IsNullOrEmpty(errorMsg))
                    {
                        b.BackColor = Color.Yellow;
                    }
                    else
                    {
                        b.BackColor = Color.Red;
                        MessageBox.Show(errorMsg);
                    }

                }
            }));
        }



        /*
         * 
         */
        private void CheckForErrorFiles(Button b, String sDir, String search, String errorMsg)
        {
            string[] files = Directory.GetFiles(sDir, search, SearchOption.AllDirectories);

            b.BeginInvoke(new MethodInvoker(() =>
            {
                if (files.Count() == 0)
                {
                    b.Text = "OK";
                    b.BackColor = Color.Green;
                }
                else
                {
                    b.Text = "X";
                    b.BackColor = Color.Red;
                    MessageBox.Show(errorMsg);
                }
            }));
        }



        /*
        * Checks, if the DHL and DPD APIs are reachable.
        */
        private void CheckDHLDPDApi()
        {      
            try
            {
                String url = "https://status.shipcloud.io/";

                //Download information to string
                String htmlCode = "";

                WebClient client = new WebClient();
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.87 Safari/537.36");

                htmlCode = client.DownloadString(url);

                dhlProcessButton.BeginInvoke(new MethodInvoker(() =>
                {
                    if (!htmlCode.Contains("Subscribe to updates for <strong>DHL: Disruption of Service</strong>"))
                    {
                        dhlApiButton.Text = "OK";
                        dhlApiButton.BackColor = Color.Green;
                    }
                    else
                    {
                        dhlApiButton.Text = "X";
                        dhlApiButton.BackColor = Color.Red;
                        MessageBox.Show("Die DHL API hat derzeit Probleme.");
                    }
                }));

                dpdApiButton.BeginInvoke(new MethodInvoker(() =>
                {
                    if (!htmlCode.Contains("Subscribe to updates for <strong>DPD: Disruption of Service</strong>" +
                    "< a data - toggle = \"modal\" class=\"subscribe\""))
                    {
                        dpdApiButton.Text = "OK";
                        dpdApiButton.BackColor = Color.Green;
                    }
                    else
                    {
                        dpdApiButton.Text = "X";
                        dpdApiButton.BackColor = Color.Red;
                        MessageBox.Show("Die DPD API hat derzeit Probleme.");
                    }
                }));

            }
            catch (Exception ex)
            {

            }
        }



        /*
        * 
        */
        private void CheckLastOrderExecute()
        {
            string lastExecution = System.IO.File.ReadAllText(@"S:\last.txt").Replace("\r","").Replace("\n","");
            DateTime lastExecutionDateTime;
            try
            {
                lastExecutionDateTime = DateTime.ParseExact(lastExecution, "dd.MM.yyyy HH:mm:ss,ff", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch(Exception ex)
            {
                lastExecutionDateTime = DateTime.ParseExact(lastExecution, "dd.MM.yyyy  H:mm:ss,ff", System.Globalization.CultureInfo.InvariantCulture);
            }
            
            DateTime currentDateTime = DateTime.Now;

            lastRunButton.BeginInvoke(new MethodInvoker(() =>
            {
                lastRunButton.Text = lastExecutionDateTime.ToString("HH:mm:ss");
                if ((currentDateTime - lastExecutionDateTime).TotalMinutes < 30)
                {
                    lastRunButton.BackColor = Color.Green;
                }
                else
                {
                    lastRunButton.BackColor = Color.Red;
                    MessageBox.Show("Die Ebay/Real/Conrad etc. Bestellungen werden nicht mehr importiert!");
                }    
            }));
        }



        /*
         * 
         */
        private OdbcDataReader ExecuteReadSql(string sql)
        {
            OdbcDataReader dr = null;
            try
            {
                OdbcConnection conn = new OdbcConnection("DSN=eNVenta SQL Server;Server=server-03;Database=LOE01;Uid=sa;Pwd=sasasa;");
                conn.Open();
                OdbcCommand comm = new OdbcCommand(sql, conn);
                dr = comm.ExecuteReader();

                return dr;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        /*
         * Allgemeine Bestellungen buttons
         */
        private void errorFilesButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("S:\\");
        }

        private void lastRunButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("S:\\");
        }



        /*
         * Amazon Bestellungen buttons
         */
        private void amazonProcessButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("S:\\Amazon");
        }

        private void amazonOrdersButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("S:\\Amazon");
        }



        /*
         * Ebay/Real/Conrad etc. Bestellungen buttons
         */
        private void ebayProcessButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("S:\\");
        }

        private void ebayOrdersButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("S:\\");
        }



        /*
         * Picard/Mercateo/Nordwest/FTP Buttons
         */

        private void mercateoErrorFilesButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("W:\\Mercateo\\ORDERS\\ERROR");
        }

        private void picardErrorFilesButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("W:\\Picard\\DESADV\\ERROR");
        }

        private void nwInvoiceButton_Click(object sender, EventArgs e)
        {

        }

        private void toolineoErrorFilesButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("W:\\Toolineo\\ORDERS\\ERROR");
        }



        /*
         * DHL Buttons
         */

        private void dhlProcessButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://status.shipcloud.io/");
        }

        private void dhlApiButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://status.shipcloud.io/");
        }

        private void dpdApiButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://status.shipcloud.io/");

        }



        /*
         * UPDATE! Button
         */

        private void updateStatsManuallyButton_Click(object sender, EventArgs e)
        {
            StartAllChecks();
        }

        








        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void lastUpdatedLabel_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


    }
}
