namespace NotificationSample
{
    partial class NotificationSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationSample));
            this.groupBoxNotChannel = new System.Windows.Forms.GroupBox();
            this.labelPortNr = new System.Windows.Forms.Label();
            this.textBoxPortNr = new System.Windows.Forms.TextBox();
            this.checkBoxAkn = new System.Windows.Forms.CheckBox();
            this.buttonListen = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.groupBoxNotChannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxNotChannel
            // 
            this.groupBoxNotChannel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxNotChannel.Controls.Add(this.labelPortNr);
            this.groupBoxNotChannel.Controls.Add(this.textBoxPortNr);
            this.groupBoxNotChannel.Controls.Add(this.checkBoxAkn);
            this.groupBoxNotChannel.Controls.Add(this.buttonListen);
            this.groupBoxNotChannel.Location = new System.Drawing.Point(803, 6);
            this.groupBoxNotChannel.Name = "groupBoxNotChannel";
            this.groupBoxNotChannel.Size = new System.Drawing.Size(145, 145);
            this.groupBoxNotChannel.TabIndex = 1;
            this.groupBoxNotChannel.TabStop = false;
            this.groupBoxNotChannel.Text = "Notification Channel";
            // 
            // labelPortNr
            // 
            this.labelPortNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPortNr.AutoSize = true;
            this.labelPortNr.Location = new System.Drawing.Point(42, 83);
            this.labelPortNr.Name = "labelPortNr";
            this.labelPortNr.Size = new System.Drawing.Size(37, 13);
            this.labelPortNr.TabIndex = 3;
            this.labelPortNr.Text = "PortNr";
            // 
            // textBoxPortNr
            // 
            this.textBoxPortNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPortNr.Location = new System.Drawing.Point(83, 79);
            this.textBoxPortNr.Name = "textBoxPortNr";
            this.textBoxPortNr.Size = new System.Drawing.Size(42, 20);
            this.textBoxPortNr.TabIndex = 2;
            this.textBoxPortNr.Text = "10005";
            // 
            // checkBoxAkn
            // 
            this.checkBoxAkn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAkn.AutoSize = true;
            this.checkBoxAkn.Location = new System.Drawing.Point(26, 112);
            this.checkBoxAkn.Name = "checkBoxAkn";
            this.checkBoxAkn.Size = new System.Drawing.Size(102, 17);
            this.checkBoxAkn.TabIndex = 1;
            this.checkBoxAkn.Text = "with Ack. [0x32]";
            this.checkBoxAkn.UseVisualStyleBackColor = true;
            // 
            // buttonListen
            // 
            this.buttonListen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonListen.Location = new System.Drawing.Point(34, 26);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(81, 34);
            this.buttonListen.TabIndex = 0;
            this.buttonListen.Text = "Listen";
            this.buttonListen.UseVisualStyleBackColor = true;
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(818, 552);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(118, 40);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxData
            // 
            this.textBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxData.Location = new System.Drawing.Point(6, 12);
            this.textBoxData.Multiline = true;
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxData.Size = new System.Drawing.Size(787, 582);
            this.textBoxData.TabIndex = 3;
            // 
            // NotificationSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 599);
            this.Controls.Add(this.textBoxData);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.groupBoxNotChannel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotificationSample";
            this.Text = "Notification Sample  -  RFID by FEIG ELECTRONIC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NotificationSample_FormClosing);
            this.groupBoxNotChannel.ResumeLayout(false);
            this.groupBoxNotChannel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxNotChannel;
        private System.Windows.Forms.Label labelPortNr;
        private System.Windows.Forms.TextBox textBoxPortNr;
        private System.Windows.Forms.CheckBox checkBoxAkn;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxData;
    }
}

