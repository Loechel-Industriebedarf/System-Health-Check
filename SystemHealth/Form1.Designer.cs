namespace SystemHealth
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ebayOrdersButton = new System.Windows.Forms.Button();
            this.lastUpdatedLabel = new System.Windows.Forms.Label();
            this.updateStatsManuallyButton = new System.Windows.Forms.Button();
            this.amazonOrdersButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.amazonProcessButton = new System.Windows.Forms.Button();
            this.ebayProcessButton = new System.Windows.Forms.Button();
            this.dhlProcessButton = new System.Windows.Forms.Button();
            this.dhlApiButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dpdApiButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.updateProgressBar = new System.Windows.Forms.ProgressBar();
            this.errorFilesButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lastRunButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.mercateoErrorFilesButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.picardErrorFilesButton = new System.Windows.Forms.Button();
            this.nwInvoiceButton = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.toolineoErrorFilesButton = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amazon Bestellungen";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ebayOrdersButton
            // 
            this.ebayOrdersButton.Enabled = false;
            this.ebayOrdersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ebayOrdersButton.Location = new System.Drawing.Point(96, 246);
            this.ebayOrdersButton.Name = "ebayOrdersButton";
            this.ebayOrdersButton.Size = new System.Drawing.Size(75, 75);
            this.ebayOrdersButton.TabIndex = 1;
            this.ebayOrdersButton.Text = " ";
            this.ebayOrdersButton.UseVisualStyleBackColor = true;
            this.ebayOrdersButton.Click += new System.EventHandler(this.ebayOrdersButton_Click);
            // 
            // lastUpdatedLabel
            // 
            this.lastUpdatedLabel.AutoSize = true;
            this.lastUpdatedLabel.Location = new System.Drawing.Point(9, 606);
            this.lastUpdatedLabel.Name = "lastUpdatedLabel";
            this.lastUpdatedLabel.Size = new System.Drawing.Size(85, 13);
            this.lastUpdatedLabel.TabIndex = 2;
            this.lastUpdatedLabel.Text = "Letztes Update: ";
            this.lastUpdatedLabel.Click += new System.EventHandler(this.lastUpdatedLabel_Click);
            // 
            // updateStatsManuallyButton
            // 
            this.updateStatsManuallyButton.Location = new System.Drawing.Point(201, 593);
            this.updateStatsManuallyButton.Name = "updateStatsManuallyButton";
            this.updateStatsManuallyButton.Size = new System.Drawing.Size(145, 25);
            this.updateStatsManuallyButton.TabIndex = 3;
            this.updateStatsManuallyButton.Text = "UPDATE!";
            this.updateStatsManuallyButton.UseVisualStyleBackColor = true;
            this.updateStatsManuallyButton.Click += new System.EventHandler(this.updateStatsManuallyButton_Click);
            // 
            // amazonOrdersButton
            // 
            this.amazonOrdersButton.Enabled = false;
            this.amazonOrdersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amazonOrdersButton.Location = new System.Drawing.Point(96, 141);
            this.amazonOrdersButton.Name = "amazonOrdersButton";
            this.amazonOrdersButton.Size = new System.Drawing.Size(75, 75);
            this.amazonOrdersButton.TabIndex = 4;
            this.amazonOrdersButton.Text = " ";
            this.amazonOrdersButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ebay/Real/Conrad etc. Bestellungen";
            // 
            // amazonProcessButton
            // 
            this.amazonProcessButton.Enabled = false;
            this.amazonProcessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amazonProcessButton.Location = new System.Drawing.Point(15, 141);
            this.amazonProcessButton.Name = "amazonProcessButton";
            this.amazonProcessButton.Size = new System.Drawing.Size(75, 75);
            this.amazonProcessButton.TabIndex = 6;
            this.amazonProcessButton.Text = " ";
            this.amazonProcessButton.UseVisualStyleBackColor = true;
            // 
            // ebayProcessButton
            // 
            this.ebayProcessButton.Enabled = false;
            this.ebayProcessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ebayProcessButton.Location = new System.Drawing.Point(15, 246);
            this.ebayProcessButton.Name = "ebayProcessButton";
            this.ebayProcessButton.Size = new System.Drawing.Size(75, 75);
            this.ebayProcessButton.TabIndex = 7;
            this.ebayProcessButton.Text = " ";
            this.ebayProcessButton.UseVisualStyleBackColor = true;
            // 
            // dhlProcessButton
            // 
            this.dhlProcessButton.Enabled = false;
            this.dhlProcessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dhlProcessButton.Location = new System.Drawing.Point(16, 461);
            this.dhlProcessButton.Name = "dhlProcessButton";
            this.dhlProcessButton.Size = new System.Drawing.Size(75, 75);
            this.dhlProcessButton.TabIndex = 8;
            this.dhlProcessButton.Text = " ";
            this.dhlProcessButton.UseVisualStyleBackColor = true;
            // 
            // dhlApiButton
            // 
            this.dhlApiButton.Enabled = false;
            this.dhlApiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dhlApiButton.Location = new System.Drawing.Point(97, 461);
            this.dhlApiButton.Name = "dhlApiButton";
            this.dhlApiButton.Size = new System.Drawing.Size(75, 75);
            this.dhlApiButton.TabIndex = 10;
            this.dhlApiButton.Text = " ";
            this.dhlApiButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 522);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "DHL-API";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 522);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Server";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Server";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Server";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(97, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Bestellungen";
            // 
            // dpdApiButton
            // 
            this.dpdApiButton.Enabled = false;
            this.dpdApiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpdApiButton.Location = new System.Drawing.Point(178, 461);
            this.dpdApiButton.Name = "dpdApiButton";
            this.dpdApiButton.Size = new System.Drawing.Size(75, 75);
            this.dpdApiButton.TabIndex = 17;
            this.dpdApiButton.Text = " ";
            this.dpdApiButton.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 307);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Bestellungen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 522);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "DPD-API";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 434);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 24);
            this.label10.TabIndex = 20;
            this.label10.Text = "DHL/DPD";
            // 
            // updateProgressBar
            // 
            this.updateProgressBar.Location = new System.Drawing.Point(201, 562);
            this.updateProgressBar.Name = "updateProgressBar";
            this.updateProgressBar.Size = new System.Drawing.Size(145, 25);
            this.updateProgressBar.TabIndex = 21;
            // 
            // errorFilesButton
            // 
            this.errorFilesButton.Enabled = false;
            this.errorFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorFilesButton.Location = new System.Drawing.Point(12, 36);
            this.errorFilesButton.Name = "errorFilesButton";
            this.errorFilesButton.Size = new System.Drawing.Size(75, 75);
            this.errorFilesButton.TabIndex = 22;
            this.errorFilesButton.Text = " ";
            this.errorFilesButton.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "ERROR Files";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(221, 24);
            this.label12.TabIndex = 24;
            this.label12.Text = "Allgemeine Bestellungen";
            // 
            // lastRunButton
            // 
            this.lastRunButton.Enabled = false;
            this.lastRunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastRunButton.Location = new System.Drawing.Point(97, 36);
            this.lastRunButton.Name = "lastRunButton";
            this.lastRunButton.Size = new System.Drawing.Size(75, 75);
            this.lastRunButton.TabIndex = 25;
            this.lastRunButton.Text = " ";
            this.lastRunButton.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(98, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Abholung";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(151, 142);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "1h";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(151, 247);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "1h";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(135, 37);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "30Min";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 593);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(186, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "Updated alle 10 Minuten automatisch.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(15, 324);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(273, 24);
            this.label18.TabIndex = 31;
            this.label18.Text = "Picard/Mercateo/Nordwest/FTP";
            // 
            // mercateoErrorFilesButton
            // 
            this.mercateoErrorFilesButton.Enabled = false;
            this.mercateoErrorFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mercateoErrorFilesButton.Location = new System.Drawing.Point(16, 351);
            this.mercateoErrorFilesButton.Name = "mercateoErrorFilesButton";
            this.mercateoErrorFilesButton.Size = new System.Drawing.Size(75, 75);
            this.mercateoErrorFilesButton.TabIndex = 32;
            this.mercateoErrorFilesButton.Text = " ";
            this.mercateoErrorFilesButton.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 412);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 33;
            this.label19.Text = "Mercateo";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(97, 412);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 13);
            this.label20.TabIndex = 35;
            this.label20.Text = "Picard";
            // 
            // picardErrorFilesButton
            // 
            this.picardErrorFilesButton.Enabled = false;
            this.picardErrorFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picardErrorFilesButton.Location = new System.Drawing.Point(96, 351);
            this.picardErrorFilesButton.Name = "picardErrorFilesButton";
            this.picardErrorFilesButton.Size = new System.Drawing.Size(75, 75);
            this.picardErrorFilesButton.TabIndex = 34;
            this.picardErrorFilesButton.Text = " ";
            this.picardErrorFilesButton.UseVisualStyleBackColor = true;
            // 
            // nwInvoiceButton
            // 
            this.nwInvoiceButton.Enabled = false;
            this.nwInvoiceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nwInvoiceButton.Location = new System.Drawing.Point(177, 351);
            this.nwInvoiceButton.Name = "nwInvoiceButton";
            this.nwInvoiceButton.Size = new System.Drawing.Size(75, 75);
            this.nwInvoiceButton.TabIndex = 36;
            this.nwInvoiceButton.Text = " ";
            this.nwInvoiceButton.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(178, 412);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 13);
            this.label21.TabIndex = 37;
            this.label21.Text = "NW-Invoice";
            // 
            // toolineoErrorFilesButton
            // 
            this.toolineoErrorFilesButton.Enabled = false;
            this.toolineoErrorFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolineoErrorFilesButton.Location = new System.Drawing.Point(258, 351);
            this.toolineoErrorFilesButton.Name = "toolineoErrorFilesButton";
            this.toolineoErrorFilesButton.Size = new System.Drawing.Size(75, 75);
            this.toolineoErrorFilesButton.TabIndex = 38;
            this.toolineoErrorFilesButton.Text = " ";
            this.toolineoErrorFilesButton.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(259, 412);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 13);
            this.label22.TabIndex = 39;
            this.label22.Text = "Toolineo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 622);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.toolineoErrorFilesButton);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.nwInvoiceButton);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.picardErrorFilesButton);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.mercateoErrorFilesButton);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lastRunButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.errorFilesButton);
            this.Controls.Add(this.updateProgressBar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dpdApiButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dhlApiButton);
            this.Controls.Add(this.dhlProcessButton);
            this.Controls.Add(this.ebayProcessButton);
            this.Controls.Add(this.amazonProcessButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.amazonOrdersButton);
            this.Controls.Add(this.updateStatsManuallyButton);
            this.Controls.Add(this.lastUpdatedLabel);
            this.Controls.Add(this.ebayOrdersButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Läuft alles?";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ebayOrdersButton;
        private System.Windows.Forms.Label lastUpdatedLabel;
        private System.Windows.Forms.Button updateStatsManuallyButton;
        private System.Windows.Forms.Button amazonOrdersButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button amazonProcessButton;
        private System.Windows.Forms.Button ebayProcessButton;
        private System.Windows.Forms.Button dhlProcessButton;
        private System.Windows.Forms.Button dhlApiButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button dpdApiButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar updateProgressBar;
        private System.Windows.Forms.Button errorFilesButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button lastRunButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button mercateoErrorFilesButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button picardErrorFilesButton;
        private System.Windows.Forms.Button nwInvoiceButton;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button toolineoErrorFilesButton;
        private System.Windows.Forms.Label label22;
    }
}

