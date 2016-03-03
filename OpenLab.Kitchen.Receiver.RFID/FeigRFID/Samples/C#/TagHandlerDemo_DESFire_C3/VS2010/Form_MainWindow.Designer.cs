namespace TagHandlerDemo_DESFire_C3
{
    partial class Form_MainWindow
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
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_InventorySelect = new System.Windows.Forms.Button();
            this.button_Personalization = new System.Windows.Forms.Button();
            this.button_ReadStandartData = new System.Windows.Forms.Button();
            this.button_WriteStandartData = new System.Windows.Forms.Button();
            this.button_FormatCard = new System.Windows.Forms.Button();
            this.richTextBox_ProtocolWindow = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_C1USB = new System.Windows.Forms.RadioButton();
            this.radioButton_C1Serial = new System.Windows.Forms.RadioButton();
            this.radioButton_C2FlexSoftCrypto = new System.Windows.Forms.RadioButton();
            this.radioButton_C2SamCrypto = new System.Windows.Forms.RadioButton();
            this.comboBox_COMPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(10, 51);
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
            this.button_Disconnect.Location = new System.Drawing.Point(10, 116);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(146, 47);
            this.button_Disconnect.TabIndex = 1;
            this.button_Disconnect.Text = "DisConnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(10, 369);
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
            this.button_InventorySelect.Location = new System.Drawing.Point(445, 123);
            this.button_InventorySelect.Name = "button_InventorySelect";
            this.button_InventorySelect.Size = new System.Drawing.Size(145, 47);
            this.button_InventorySelect.TabIndex = 3;
            this.button_InventorySelect.Text = "Inventory/Select";
            this.button_InventorySelect.UseVisualStyleBackColor = true;
            this.button_InventorySelect.Click += new System.EventHandler(this.button_InventorySelect_Click);
            // 
            // button_Personalization
            // 
            this.button_Personalization.Enabled = false;
            this.button_Personalization.Location = new System.Drawing.Point(472, 200);
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
            this.button_ReadStandartData.Location = new System.Drawing.Point(472, 256);
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
            this.button_WriteStandartData.Location = new System.Drawing.Point(472, 313);
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
            this.button_FormatCard.Location = new System.Drawing.Point(472, 373);
            this.button_FormatCard.Name = "button_FormatCard";
            this.button_FormatCard.Size = new System.Drawing.Size(95, 39);
            this.button_FormatCard.TabIndex = 7;
            this.button_FormatCard.Text = "Format Card";
            this.button_FormatCard.UseVisualStyleBackColor = true;
            this.button_FormatCard.Click += new System.EventHandler(this.button_FormatCard_Click);
            // 
            // richTextBox_ProtocolWindow
            // 
            this.richTextBox_ProtocolWindow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox_ProtocolWindow.Location = new System.Drawing.Point(10, 454);
            this.richTextBox_ProtocolWindow.Name = "richTextBox_ProtocolWindow";
            this.richTextBox_ProtocolWindow.Size = new System.Drawing.Size(1031, 240);
            this.richTextBox_ProtocolWindow.TabIndex = 8;
            this.richTextBox_ProtocolWindow.Text = "";
            this.richTextBox_ProtocolWindow.TextChanged += new System.EventHandler(this.richTextBox_ProtocolWindow_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(479, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Protocol Window";
            // 
            // radioButton_C1USB
            // 
            this.radioButton_C1USB.AutoSize = true;
            this.radioButton_C1USB.Location = new System.Drawing.Point(171, 51);
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
            this.radioButton_C1Serial.Location = new System.Drawing.Point(171, 74);
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
            this.comboBox_COMPort.Location = new System.Drawing.Point(228, 73);
            this.comboBox_COMPort.Name = "comboBox_COMPort";
            this.comboBox_COMPort.Size = new System.Drawing.Size(43, 21);
            this.comboBox_COMPort.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "COM-Port";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton_C2FlexSoftCrypto);
            this.panel1.Controls.Add(this.radioButton_C2SamCrypto);
            this.panel1.Location = new System.Drawing.Point(422, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 51);
            this.panel1.TabIndex = 16;
            // 
            // Form_MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 704);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_COMPort);
            this.Controls.Add(this.radioButton_C1Serial);
            this.Controls.Add(this.radioButton_C1USB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox_ProtocolWindow);
            this.Controls.Add(this.button_FormatCard);
            this.Controls.Add(this.button_WriteStandartData);
            this.Controls.Add(this.button_ReadStandartData);
            this.Controls.Add(this.button_Personalization);
            this.Controls.Add(this.button_InventorySelect);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Disconnect);
            this.Controls.Add(this.button_Connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimumSize = new System.Drawing.Size(700, 736);
            this.Name = "Form_MainWindow";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "TagHandlerDemo_DESFire_C3Dlg";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_C1USB;
        private System.Windows.Forms.RadioButton radioButton_C1Serial;
        private System.Windows.Forms.RadioButton radioButton_C2FlexSoftCrypto;
        private System.Windows.Forms.RadioButton radioButton_C2SamCrypto;
        private System.Windows.Forms.ComboBox comboBox_COMPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}

