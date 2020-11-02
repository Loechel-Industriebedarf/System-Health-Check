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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
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
            this.ebayOrdersButton.Location = new System.Drawing.Point(93, 141);
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
            this.lastUpdatedLabel.Location = new System.Drawing.Point(6, 392);
            this.lastUpdatedLabel.Name = "lastUpdatedLabel";
            this.lastUpdatedLabel.Size = new System.Drawing.Size(85, 13);
            this.lastUpdatedLabel.TabIndex = 2;
            this.lastUpdatedLabel.Text = "Letztes Update: ";
            this.lastUpdatedLabel.Click += new System.EventHandler(this.lastUpdatedLabel_Click);
            // 
            // updateStatsManuallyButton
            // 
            this.updateStatsManuallyButton.Location = new System.Drawing.Point(175, 387);
            this.updateStatsManuallyButton.Name = "updateStatsManuallyButton";
            this.updateStatsManuallyButton.Size = new System.Drawing.Size(145, 23);
            this.updateStatsManuallyButton.TabIndex = 3;
            this.updateStatsManuallyButton.Text = "UPDATE!";
            this.updateStatsManuallyButton.UseVisualStyleBackColor = true;
            this.updateStatsManuallyButton.Click += new System.EventHandler(this.updateStatsManuallyButton_Click);
            // 
            // amazonOrdersButton
            // 
            this.amazonOrdersButton.Enabled = false;
            this.amazonOrdersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amazonOrdersButton.Location = new System.Drawing.Point(93, 36);
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
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ebay/Real/Conrad etc. Bestellungen";
            // 
            // amazonProcessButton
            // 
            this.amazonProcessButton.Enabled = false;
            this.amazonProcessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amazonProcessButton.Location = new System.Drawing.Point(12, 36);
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
            this.ebayProcessButton.Location = new System.Drawing.Point(12, 141);
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
            this.dhlProcessButton.Location = new System.Drawing.Point(13, 246);
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
            this.dhlApiButton.Location = new System.Drawing.Point(94, 246);
            this.dhlApiButton.Name = "dhlApiButton";
            this.dhlApiButton.Size = new System.Drawing.Size(75, 75);
            this.dhlApiButton.TabIndex = 10;
            this.dhlApiButton.Text = " ";
            this.dhlApiButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "DHL-API";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Server";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Server";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Server";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(95, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Bestellungen";
            // 
            // dpdApiButton
            // 
            this.dpdApiButton.Enabled = false;
            this.dpdApiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpdApiButton.Location = new System.Drawing.Point(175, 246);
            this.dpdApiButton.Name = "dpdApiButton";
            this.dpdApiButton.Size = new System.Drawing.Size(75, 75);
            this.dpdApiButton.TabIndex = 17;
            this.dpdApiButton.Text = " ";
            this.dpdApiButton.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(95, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Bestellungen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "DPD-API";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 24);
            this.label10.TabIndex = 20;
            this.label10.Text = "DHL/DPD";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 414);
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
    }
}

