namespace TagHandlerDemo_DESFire_C3
{
    partial class TagHandlerDemo_DESFire
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagHandlerDemo_DESFire));
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_InventorySelect = new System.Windows.Forms.Button();
            this.button_Personalization = new System.Windows.Forms.Button();
            this.button_ReadStandartData = new System.Windows.Forms.Button();
            this.button_WriteStandartData = new System.Windows.Forms.Button();
            this.button_FormatCard = new System.Windows.Forms.Button();
            this.richTextBox_ProtocolWindow = new System.Windows.Forms.RichTextBox();
            this.radioButton_C1USB = new System.Windows.Forms.RadioButton();
            this.radioButton_C1Serial = new System.Windows.Forms.RadioButton();
            this.radioButton_C2FlexSoftCrypto = new System.Windows.Forms.RadioButton();
            this.radioButton_C2SamCrypto = new System.Windows.Forms.RadioButton();
            this.comboBox_COMPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(4, 24);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(146, 47);
            this.button_Connect.TabIndex = 0;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Enabled = false;
            this.button_Disconnect.Location = new System.Drawing.Point(4, 77);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(146, 47);
            this.button_Disconnect.TabIndex = 1;
            this.button_Disconnect.Text = "DisConnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(4, 184);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(146, 47);
            this.button_Close.TabIndex = 2;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_InventorySelect
            // 
            this.button_InventorySelect.Enabled = false;
            this.button_InventorySelect.Location = new System.Drawing.Point(13, 76);
            this.button_InventorySelect.Name = "button_InventorySelect";
            this.button_InventorySelect.Size = new System.Drawing.Size(199, 47);
            this.button_InventorySelect.TabIndex = 3;
            this.button_InventorySelect.Text = "Inventory/Select";
            this.button_InventorySelect.UseVisualStyleBackColor = true;
            this.button_InventorySelect.Click += new System.EventHandler(this.button_InventorySelect_Click);
            // 
            // button_Personalization
            // 
            this.button_Personalization.Enabled = false;
            this.button_Personalization.Location = new System.Drawing.Point(16, 133);
            this.button_Personalization.Name = "button_Personalization";
            this.button_Personalization.Size = new System.Drawing.Size(95, 39);
            this.button_Personalization.TabIndex = 4;
            this.button_Personalization.Text = "Personalization";
            this.button_Personalization.UseVisualStyleBackColor = true;
            this.button_Personalization.Click += new System.EventHandler(this.button_Personalization_Click);
            // 
            // button_ReadStandartData
            // 
            this.button_ReadStandartData.Enabled = false;
            this.button_ReadStandartData.Location = new System.Drawing.Point(16, 191);
            this.button_ReadStandartData.Name = "button_ReadStandartData";
            this.button_ReadStandartData.Size = new System.Drawing.Size(95, 39);
            this.button_ReadStandartData.TabIndex = 5;
            this.button_ReadStandartData.Text = "Read Std. Data";
            this.button_ReadStandartData.UseVisualStyleBackColor = true;
            this.button_ReadStandartData.Click += new System.EventHandler(this.button_ReadStandartData_Click);
            // 
            // button_WriteStandartData
            // 
            this.button_WriteStandartData.Enabled = false;
            this.button_WriteStandartData.Location = new System.Drawing.Point(117, 191);
            this.button_WriteStandartData.Name = "button_WriteStandartData";
            this.button_WriteStandartData.Size = new System.Drawing.Size(95, 39);
            this.button_WriteStandartData.TabIndex = 6;
            this.button_WriteStandartData.Text = "Write Std. Data";
            this.button_WriteStandartData.UseVisualStyleBackColor = true;
            this.button_WriteStandartData.Click += new System.EventHandler(this.button_WriteStandartData_Click);
            // 
            // button_FormatCard
            // 
            this.button_FormatCard.Enabled = false;
            this.button_FormatCard.Location = new System.Drawing.Point(117, 133);
            this.button_FormatCard.Name = "button_FormatCard";
            this.button_FormatCard.Size = new System.Drawing.Size(95, 39);
            this.button_FormatCard.TabIndex = 7;
            this.button_FormatCard.Text = "Format Card";
            this.button_FormatCard.UseVisualStyleBackColor = true;
            this.button_FormatCard.Click += new System.EventHandler(this.button_FormatCard_Click);
            // 
            // richTextBox_ProtocolWindow
            // 
            this.richTextBox_ProtocolWindow.Location = new System.Drawing.Point(10, 24);
            this.richTextBox_ProtocolWindow.Name = "richTextBox_ProtocolWindow";
            this.richTextBox_ProtocolWindow.Size = new System.Drawing.Size(778, 395);
            this.richTextBox_ProtocolWindow.TabIndex = 8;
            this.richTextBox_ProtocolWindow.Text = "";
            this.richTextBox_ProtocolWindow.TextChanged += new System.EventHandler(this.richTextBox_ProtocolWindow_TextChanged);
            // 
            // radioButton_C1USB
            // 
            this.radioButton_C1USB.AutoSize = true;
            this.radioButton_C1USB.Location = new System.Drawing.Point(165, 27);
            this.radioButton_C1USB.Name = "radioButton_C1USB";
            this.radioButton_C1USB.Size = new System.Drawing.Size(47, 17);
            this.radioButton_C1USB.TabIndex = 10;
            this.radioButton_C1USB.TabStop = true;
            this.radioButton_C1USB.Text = "USB";
            this.radioButton_C1USB.UseVisualStyleBackColor = true;
            // 
            // radioButton_C1Serial
            // 
            this.radioButton_C1Serial.AutoSize = true;
            this.radioButton_C1Serial.Location = new System.Drawing.Point(165, 50);
            this.radioButton_C1Serial.Name = "radioButton_C1Serial";
            this.radioButton_C1Serial.Size = new System.Drawing.Size(51, 17);
            this.radioButton_C1Serial.TabIndex = 11;
            this.radioButton_C1Serial.TabStop = true;
            this.radioButton_C1Serial.Text = "Serial";
            this.radioButton_C1Serial.UseVisualStyleBackColor = true;
            // 
            // radioButton_C2FlexSoftCrypto
            // 
            this.radioButton_C2FlexSoftCrypto.AutoSize = true;
            this.radioButton_C2FlexSoftCrypto.Location = new System.Drawing.Point(3, 3);
            this.radioButton_C2FlexSoftCrypto.Name = "radioButton_C2FlexSoftCrypto";
            this.radioButton_C2FlexSoftCrypto.Size = new System.Drawing.Size(194, 17);
            this.radioButton_C2FlexSoftCrypto.TabIndex = 12;
            this.radioButton_C2FlexSoftCrypto.TabStop = true;
            this.radioButton_C2FlexSoftCrypto.Text = "Flex Soft Crypto [0xC3] - Mode 0x00";
            this.radioButton_C2FlexSoftCrypto.UseVisualStyleBackColor = true;
            this.radioButton_C2FlexSoftCrypto.CheckedChanged += new System.EventHandler(this.radioButton_C2FlexSoftCrypto_CheckedChanged);
            // 
            // radioButton_C2SamCrypto
            // 
            this.radioButton_C2SamCrypto.AutoSize = true;
            this.radioButton_C2SamCrypto.Location = new System.Drawing.Point(3, 26);
            this.radioButton_C2SamCrypto.Name = "radioButton_C2SamCrypto";
            this.radioButton_C2SamCrypto.Size = new System.Drawing.Size(174, 17);
            this.radioButton_C2SamCrypto.TabIndex = 13;
            this.radioButton_C2SamCrypto.TabStop = true;
            this.radioButton_C2SamCrypto.Text = "Sam Crypto [0xC3] - Mode 0x01";
            this.radioButton_C2SamCrypto.UseVisualStyleBackColor = true;
            this.radioButton_C2SamCrypto.CheckedChanged += new System.EventHandler(this.radioButton_C2SamCrypto_CheckedChanged);
            // 
            // comboBox_COMPort
            // 
            this.comboBox_COMPort.FormattingEnabled = true;
            this.comboBox_COMPort.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBox_COMPort.Location = new System.Drawing.Point(222, 49);
            this.comboBox_COMPort.Name = "comboBox_COMPort";
            this.comboBox_COMPort.Size = new System.Drawing.Size(43, 21);
            this.comboBox_COMPort.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "COM-Port";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton_C2FlexSoftCrypto);
            this.panel1.Controls.Add(this.radioButton_C2SamCrypto);
            this.panel1.Location = new System.Drawing.Point(13, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 51);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_COMPort);
            this.groupBox1.Controls.Add(this.radioButton_C1Serial);
            this.groupBox1.Controls.Add(this.radioButton_C1USB);
            this.groupBox1.Controls.Add(this.button_Close);
            this.groupBox1.Controls.Add(this.button_Disconnect);
            this.groupBox1.Controls.Add(this.button_Connect);
            this.groupBox1.Location = new System.Drawing.Point(6, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 240);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interface";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.button_FormatCard);
            this.groupBox2.Controls.Add(this.button_WriteStandartData);
            this.groupBox2.Controls.Add(this.button_ReadStandartData);
            this.groupBox2.Controls.Add(this.button_Personalization);
            this.groupBox2.Controls.Add(this.button_InventorySelect);
            this.groupBox2.Location = new System.Drawing.Point(353, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 238);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tag Commands";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox_ProtocolWindow);
            this.groupBox3.Location = new System.Drawing.Point(8, 264);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(803, 434);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Protocol Window";
            // 
            // TagHandlerDemo_DESFire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 711);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 736);
            this.Name = "TagHandlerDemo_DESFire";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "TagHandlerDemo_DESFire_C3";
            this.Load += new System.EventHandler(this.TagHandlerDemo_DESFire_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_InventorySelect;
        private System.Windows.Forms.Button button_Personalization;
        private System.Windows.Forms.Button button_ReadStandartData;
        private System.Windows.Forms.Button button_WriteStandartData;
        private System.Windows.Forms.Button button_FormatCard;
        private System.Windows.Forms.RichTextBox richTextBox_ProtocolWindow;
        private System.Windows.Forms.RadioButton radioButton_C1USB;
        private System.Windows.Forms.RadioButton radioButton_C1Serial;
        private System.Windows.Forms.RadioButton radioButton_C2FlexSoftCrypto;
        private System.Windows.Forms.RadioButton radioButton_C2SamCrypto;
        private System.Windows.Forms.ComboBox comboBox_COMPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

