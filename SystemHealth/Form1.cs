﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
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
            updateProgressBar.BeginInvoke(new MethodInvoker(() =>
            {
                updateProgressBar.Value = 0;

                CheckEbayOrders();
                updateProgressBar.PerformStep();

                CheckAmazonOrders();
                updateProgressBar.PerformStep();

                CheckAmazonProcesses();
                updateProgressBar.PerformStep();

                CheckEbayProcesses();
                updateProgressBar.PerformStep();

                CheckDHLProcess();
                updateProgressBar.PerformStep();

                CheckDHLDPDApi();
                updateProgressBar.PerformStep();

                updateProgressBar.Value = 100;
            }));

            //Write the current date to a label on the gui
            lastUpdatedLabel.BeginInvoke(new MethodInvoker(() =>
            {
                lastUpdatedLabel.Text = "Letztes Update: " + DateTime.Now.ToString("HH:mm:ss");
            }));
        }

        /*
         * 
         */
        private void CheckEbayOrders()
        {
            OdbcDataReader dr = 
                ExecuteReadSql("SELECT COUNT(*) AS Counter FROM dbo.AUFTRAGSKOPF WHERE (BELEGART = '8' OR BELEGART = '11' OR BELEGART = '12' OR BELEGART = '13' OR BELEGART = '14' OR BELEGART = '18') AND ERFASSUNGSDATUM > DATEADD(HOUR, -1, GETDATE())");

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
                        MessageBox.Show("Die Ebay Prozesse scheinen nicht zu laufen. Keine Bestellungen in der letzten Stunde.");
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
                        MessageBox.Show("Die Amazon Prozesse scheinen nicht zu laufen. Keine Bestellungen in der letzten Stunde.");
                    }

                }));
            }
        }

        /*
         * 
         */
        private void CheckAmazonProcesses()
        {
            using (PowerShell ps = PowerShell.Create())
            {
                // specify the script code to run.
                ps.AddScript("Invoke-Command -ComputerName server-03 -ScriptBlock { (Get-Process | Where-Object {$_.Name -match 'Amazon'}).count }");

                // execute the script and await the result.
                var pipelineObjects = ps.Invoke();

                Int32 processCount = 0;

                // print the resulting pipeline objects to the console.
                foreach (var item in pipelineObjects)
                {
                    processCount = Convert.ToInt32(item.BaseObject.ToString());
                }

                amazonProcessButton.BeginInvoke(new MethodInvoker(() =>
                {
                    if (Convert.ToInt32(processCount) == 2)
                    {
                        amazonProcessButton.Text = "OK";
                        amazonProcessButton.BackColor = Color.Green;
                    }
                    else
                    {
                        amazonProcessButton.Text = "X";
                        amazonProcessButton.BackColor = Color.Red;
                        MessageBox.Show("Die Amazon Prozesse scheinen nicht zu laufen.");
                    }
                }));
            }
        }

        /*
         * 
         */
        private void CheckEbayProcesses()
        {
            using (PowerShell ps = PowerShell.Create())
            {
                // specify the script code to run.
                ps.AddScript("Invoke-Command -ComputerName server-03 -ScriptBlock { (Get-Process | Where-Object {$_.Name -match 'powershell'}).count }");

                // execute the script and await the result.
                var pipelineObjects = ps.Invoke();

                Int32 processCount = 0;

                // print the resulting pipeline objects to the console.
                foreach (var item in pipelineObjects)
                {
                    processCount = Convert.ToInt32(item.BaseObject.ToString());
                }

                ebayProcessButton.BeginInvoke(new MethodInvoker(() =>
                {
                    

                    if (Convert.ToInt32(processCount) == 1)
                    {
                        ebayProcessButton.Text = "OK";
                        ebayProcessButton.BackColor = Color.Green;
                    }
                    else
                    {
                        ebayProcessButton.Text = "X";
                        ebayProcessButton.BackColor = Color.Red;
                        MessageBox.Show("Die Ebay Prozesse scheinen nicht zu laufen.");
                    }
                }));
            }
        }

        /*
        * 
        */
        private void CheckDHLProcess()
        {
            using (PowerShell ps = PowerShell.Create())
            {
                // specify the script code to run.
                ps.AddScript("Invoke-Command -ComputerName server-03 -ScriptBlock { (Get-Process | Where-Object {$_.Name -match 'DHL'}).count }");

                // execute the script and await the result.
                var pipelineObjects = ps.Invoke();

                Int32 processCount = 0;

                // print the resulting pipeline objects to the console.
                foreach (var item in pipelineObjects)
                {
                    processCount = Convert.ToInt32(item.BaseObject.ToString());
                }

                dhlProcessButton.BeginInvoke(new MethodInvoker(() =>
                {  
                    if (Convert.ToInt32(processCount) != 1)
                    {
                        dhlProcessButton.Text = "OK";
                        dhlProcessButton.BackColor = Color.Green;
                    }
                    else
                    {
                        dhlProcessButton.Text = "X";
                        dhlProcessButton.BackColor = Color.Red;
                        MessageBox.Show("Es läuft ein unnötiger DHL Prozess auf dem Server.");
                    }
                }));
            }
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
                    if (!htmlCode.Contains("DHL: Disruption of Service"))
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
                    if (!htmlCode.Contains("DPD: Disruption of Service"))
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
