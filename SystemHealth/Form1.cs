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
         * 
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
         * 
         */
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            StartAllChecks();
        }


        /*
         * 
         */
        private void StartAllChecks()
        {
            try
            {
                updateProgressBar.BeginInvoke(new MethodInvoker(() =>
                {
                    updateProgressBar.Value = 0;
                    Int32 processCount = 0;

                    CheckEbayOrders();
                    updateProgressBar.PerformStep();

                    CheckAmazonOrders();
                    updateProgressBar.PerformStep();

                    CheckDHLDPDApi();
                    updateProgressBar.PerformStep();

                    CheckLastOrderExecute();
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
         * 
         */
        private void CheckEbayOrders()
        {
            OdbcDataReader dr = 
                ExecuteReadSql("SELECT COUNT(*) AS Counter FROM dbo.AUFTRAGSKOPF WHERE (BELEGART = '8' OR BELEGART = '11' OR BELEGART = '12' OR BELEGART = '14' OR BELEGART = '18') AND ERFASSUNGSDATUM > DATEADD(HOUR, -1, GETDATE())");

            while (dr.Read())
            {
                String orderCounter = dr["Counter"].ToString();

                ebayOrdersButton.BeginInvoke(new MethodInvoker(() =>
                {
                    ebayOrdersButton.Text = orderCounter;

                    if (Convert.ToInt32(orderCounter) >= 1)
                    {
                        ebayOrdersButton.BackColor = Color.Green;
                    }
                    else
                    {
                        ebayOrdersButton.BackColor = Color.Red;
                        //MessageBox.Show("Die Ebay Prozesse scheinen nicht zu laufen. Keine Bestellungen in der letzten Stunde.");
                    }
                    
                }));   
            }
        }



        /*
         * 
         */
        private void CheckAmazonOrders()
        {
            OdbcDataReader dr =
                ExecuteReadSql("SELECT COUNT(*) AS Counter FROM dbo.AUFTRAGSKOPF WHERE BELEGART = '7' AND ERFASSUNGSDATUM > DATEADD(HOUR, -1, GETDATE())");

            while (dr.Read())
            {
                String orderCounter = dr["Counter"].ToString();

                amazonOrdersButton.BeginInvoke(new MethodInvoker(() =>
                {
                    amazonOrdersButton.Text = orderCounter;

                    if (Convert.ToInt32(orderCounter) >= 1)
                    {
                        amazonOrdersButton.BackColor = Color.Green;
                    }
                    else
                    {
                        amazonOrdersButton.BackColor = Color.Red;
                        //MessageBox.Show("Die Amazon Prozesse scheinen nicht zu laufen. Keine Bestellungen in der letzten Stunde.");
                    }

                }));
            }
        }



        /*
         * Default value: server-03
         */
        private Int32 ExecutePowershellProcessCount(String powershellScript)
        {
            return ExecutePowershellProcessCount(powershellScript, "server-03");
        }
        private Int32 ExecutePowershellProcessCount(String powershellScript, String server)
        {
            using (PowerShell ps = PowerShell.Create())
            {
                // specify the script code to run.
                ps.AddScript("Invoke-Command -ComputerName " + server + " -ScriptBlock { (Get-Process | Where-Object {$_.Name -match '" + powershellScript + "'}).count }");

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
         * 
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ebayOrdersButton_Click(object sender, EventArgs e)
        {

        }

        private void lastUpdatedLabel_Click(object sender, EventArgs e)
        {

        }

        private void updateStatsManuallyButton_Click(object sender, EventArgs e)
        {
            StartAllChecks();
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
