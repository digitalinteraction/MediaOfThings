namespace BRMSample
{
    partial class BRMSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BRMSample));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClearProt = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBoxBRM = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonResetBRM = new System.Windows.Forms.Button();
            this.buttonStartBRM = new System.Windows.Forms.Button();
            this.groupBoxSetup = new System.Windows.Forms.GroupBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxProtocol = new System.Windows.Forms.TextBox();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBoxBRM.SuspendLayout();
            this.groupBoxSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonClearProt);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.groupBoxBRM);
            this.panel1.Controls.Add(this.groupBoxSetup);
            this.panel1.Location = new System.Drawing.Point(750, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 574);
            this.panel1.TabIndex = 0;
            // 
            // buttonClearProt
            // 
            this.buttonClearProt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearProt.Location = new System.Drawing.Point(40, 473);
            this.buttonClearProt.Name = "buttonClearProt";
            this.buttonClearProt.Size = new System.Drawing.Size(166, 37);
            this.buttonClearProt.TabIndex = 3;
            this.buttonClearProt.Text = "Clear Protocol";
            this.buttonClearProt.UseVisualStyleBackColor = true;
            this.buttonClearProt.Click += new System.EventHandler(this.buttonClearProt_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(40, 528);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(166, 37);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // groupBoxBRM
            // 
            this.groupBoxBRM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBRM.Controls.Add(this.buttonClear);
            this.groupBoxBRM.Controls.Add(this.buttonResetBRM);
            this.groupBoxBRM.Controls.Add(this.buttonStartBRM);
            this.groupBoxBRM.Location = new System.Drawing.Point(9, 85);
            this.groupBoxBRM.Name = "groupBoxBRM";
            this.groupBoxBRM.Size = new System.Drawing.Size(221, 178);
            this.groupBoxBRM.TabIndex = 1;
            this.groupBoxBRM.TabStop = false;
            this.groupBoxBRM.Text = "BRM";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(27, 130);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(170, 37);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonResetBRM
            // 
            this.buttonResetBRM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetBRM.Location = new System.Drawing.Point(27, 77);
            this.buttonResetBRM.Name = "buttonResetBRM";
            this.buttonResetBRM.Size = new System.Drawing.Size(170, 37);
            this.buttonResetBRM.TabIndex = 1;
            this.buttonResetBRM.Text = "Reset BRM";
            this.buttonResetBRM.UseVisualStyleBackColor = true;
            this.buttonResetBRM.Click += new System.EventHandler(this.buttonResetBRM_Click);
            // 
            // buttonStartBRM
            // 
            this.buttonStartBRM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartBRM.Location = new System.Drawing.Point(27, 19);
            this.buttonStartBRM.Name = "buttonStartBRM";
            this.buttonStartBRM.Size = new System.Drawing.Size(170, 37);
            this.buttonStartBRM.TabIndex = 0;
            this.buttonStartBRM.Text = "Start BRM";
            this.buttonStartBRM.UseVisualStyleBackColor = true;
            this.buttonStartBRM.Click += new System.EventHandler(this.buttonStartBRM_Click);
            // 
            // groupBoxSetup
            // 
            this.groupBoxSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSetup.Controls.Add(this.buttonConnect);
            this.groupBoxSetup.Location = new System.Drawing.Point(9, 12);
            this.groupBoxSetup.Name = "groupBoxSetup";
            this.groupBoxSetup.Size = new System.Drawing.Size(221, 67);
            this.groupBoxSetup.TabIndex = 0;
            this.groupBoxSetup.TabStop = false;
            this.groupBoxSetup.Text = "Setup";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.Location = new System.Drawing.Point(27, 19);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(170, 37);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connection";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxProtocol
            // 
            this.textBoxProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProtocol.Location = new System.Drawing.Point(3, 349);
            this.textBoxProtocol.Multiline = true;
            this.textBoxProtocol.Name = "textBoxProtocol";
            this.textBoxProtocol.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxProtocol.Size = new System.Drawing.Size(741, 222);
            this.textBoxProtocol.TabIndex = 2;
            this.textBoxProtocol.TextChanged += new System.EventHandler(this.textBoxProtocol_TextChanged);
            // 
            // textBoxData
            // 
            this.textBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxData.Location = new System.Drawing.Point(3, 12);
            this.textBoxData.Multiline = true;
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxData.Size = new System.Drawing.Size(741, 331);
            this.textBoxData.TabIndex = 3;
            // 
            // BRMSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 575);
            this.Controls.Add(this.textBoxData);
            this.Controls.Add(this.textBoxProtocol);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BRMSample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BRMSample for Standard and Advanced Buffered Read Mode  -  FEIG ELECTRONIC  -  ad" +
    "vanced reader techology";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BRMSample_FormClosing);
            this.panel1.ResumeLayout(false);
            this.groupBoxBRM.ResumeLayout(false);
            this.groupBoxSetup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.GroupBox groupBoxBRM;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonResetBRM;
        private System.Windows.Forms.Button buttonStartBRM;
        private System.Windows.Forms.GroupBox groupBoxSetup;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxProtocol;
        private System.Windows.Forms.Button buttonClearProt;
        private System.Windows.Forms.TextBox textBoxData;
    }
}

