
namespace APDUSample
{
    partial class PortConnection
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
            this.groupBoxTCP_IP = new System.Windows.Forms.GroupBox();
            this.textBoxTimeout = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.labelTimeout = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.groupBoxSerialPort = new System.Windows.Forms.GroupBox();
            this.comboBoxFrame = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.comboBoxPortnumber = new System.Windows.Forms.ComboBox();
            this.textBoxTimeoutSP = new System.Windows.Forms.TextBox();
            this.labelTimeoutSP = new System.Windows.Forms.Label();
            this.labelFrame = new System.Windows.Forms.Label();
            this.labelBaudrate = new System.Windows.Forms.Label();
            this.labelPortNumber = new System.Windows.Forms.Label();
            this.radioButtonTCP_IP = new System.Windows.Forms.RadioButton();
            this.radioButtonSerialPort = new System.Windows.Forms.RadioButton();
            this.radioButtonUSB = new System.Windows.Forms.RadioButton();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.groupBoxTCP_IP.SuspendLayout();
            this.groupBoxSerialPort.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTCP_IP
            // 
            this.groupBoxTCP_IP.Controls.Add(this.textBoxTimeout);
            this.groupBoxTCP_IP.Controls.Add(this.textBoxPort);
            this.groupBoxTCP_IP.Controls.Add(this.textBoxHost);
            this.groupBoxTCP_IP.Controls.Add(this.labelTimeout);
            this.groupBoxTCP_IP.Controls.Add(this.labelPort);
            this.groupBoxTCP_IP.Controls.Add(this.labelHost);
            this.groupBoxTCP_IP.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTCP_IP.Name = "groupBoxTCP_IP";
            this.groupBoxTCP_IP.Size = new System.Drawing.Size(165, 179);
            this.groupBoxTCP_IP.TabIndex = 0;
            this.groupBoxTCP_IP.TabStop = false;
            this.groupBoxTCP_IP.Text = "TCP/IP";
            // 
            // textBoxTimeout
            // 
            this.textBoxTimeout.Location = new System.Drawing.Point(69, 97);
            this.textBoxTimeout.Name = "textBoxTimeout";
            this.textBoxTimeout.Size = new System.Drawing.Size(90, 20);
            this.textBoxTimeout.TabIndex = 5;
            this.textBoxTimeout.Text = "3000";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(69, 59);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(90, 20);
            this.textBoxPort.TabIndex = 4;
            this.textBoxPort.Text = "10001";
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(69, 24);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(90, 20);
            this.textBoxHost.TabIndex = 3;
            this.textBoxHost.Text = "192.168.10.10";
            // 
            // labelTimeout
            // 
            this.labelTimeout.AutoSize = true;
            this.labelTimeout.Location = new System.Drawing.Point(18, 100);
            this.labelTimeout.Name = "labelTimeout";
            this.labelTimeout.Size = new System.Drawing.Size(45, 13);
            this.labelTimeout.TabIndex = 2;
            this.labelTimeout.Text = "Timeout";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(18, 62);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(26, 13);
            this.labelPort.TabIndex = 1;
            this.labelPort.Text = "Port";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(18, 27);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(29, 13);
            this.labelHost.TabIndex = 0;
            this.labelHost.Text = "Host";
            // 
            // groupBoxSerialPort
            // 
            this.groupBoxSerialPort.Controls.Add(this.comboBoxFrame);
            this.groupBoxSerialPort.Controls.Add(this.comboBoxBaudrate);
            this.groupBoxSerialPort.Controls.Add(this.comboBoxPortnumber);
            this.groupBoxSerialPort.Controls.Add(this.textBoxTimeoutSP);
            this.groupBoxSerialPort.Controls.Add(this.labelTimeoutSP);
            this.groupBoxSerialPort.Controls.Add(this.labelFrame);
            this.groupBoxSerialPort.Controls.Add(this.labelBaudrate);
            this.groupBoxSerialPort.Controls.Add(this.labelPortNumber);
            this.groupBoxSerialPort.Location = new System.Drawing.Point(183, 12);
            this.groupBoxSerialPort.Name = "groupBoxSerialPort";
            this.groupBoxSerialPort.Size = new System.Drawing.Size(210, 179);
            this.groupBoxSerialPort.TabIndex = 1;
            this.groupBoxSerialPort.TabStop = false;
            this.groupBoxSerialPort.Text = "Serial Port";
            // 
            // comboBoxFrame
            // 
            this.comboBoxFrame.FormattingEnabled = true;
            this.comboBoxFrame.Items.AddRange(new object[] {
            "7N1",
            "7E1",
            "7O1",
            "7N2",
            "7E2",
            "7O2",
            "8N1",
            "8E1",
            "8O1"});
            this.comboBoxFrame.Location = new System.Drawing.Point(103, 96);
            this.comboBoxFrame.Name = "comboBoxFrame";
            this.comboBoxFrame.Size = new System.Drawing.Size(101, 21);
            this.comboBoxFrame.TabIndex = 7;
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxBaudrate.Location = new System.Drawing.Point(104, 58);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(100, 21);
            this.comboBoxBaudrate.TabIndex = 6;
            // 
            // comboBoxPortnumber
            // 
            this.comboBoxPortnumber.FormattingEnabled = true;
            this.comboBoxPortnumber.Location = new System.Drawing.Point(104, 23);
            this.comboBoxPortnumber.Name = "comboBoxPortnumber";
            this.comboBoxPortnumber.Size = new System.Drawing.Size(100, 21);
            this.comboBoxPortnumber.TabIndex = 5;
            // 
            // textBoxTimeoutSP
            // 
            this.textBoxTimeoutSP.Location = new System.Drawing.Point(104, 136);
            this.textBoxTimeoutSP.Name = "textBoxTimeoutSP";
            this.textBoxTimeoutSP.Size = new System.Drawing.Size(100, 20);
            this.textBoxTimeoutSP.TabIndex = 4;
            this.textBoxTimeoutSP.Text = "1000";
            // 
            // labelTimeoutSP
            // 
            this.labelTimeoutSP.AutoSize = true;
            this.labelTimeoutSP.Location = new System.Drawing.Point(17, 139);
            this.labelTimeoutSP.Name = "labelTimeoutSP";
            this.labelTimeoutSP.Size = new System.Drawing.Size(45, 13);
            this.labelTimeoutSP.TabIndex = 3;
            this.labelTimeoutSP.Text = "Timeout";
            // 
            // labelFrame
            // 
            this.labelFrame.AutoSize = true;
            this.labelFrame.Location = new System.Drawing.Point(17, 100);
            this.labelFrame.Name = "labelFrame";
            this.labelFrame.Size = new System.Drawing.Size(36, 13);
            this.labelFrame.TabIndex = 2;
            this.labelFrame.Text = "Frame";
            // 
            // labelBaudrate
            // 
            this.labelBaudrate.AutoSize = true;
            this.labelBaudrate.Location = new System.Drawing.Point(17, 62);
            this.labelBaudrate.Name = "labelBaudrate";
            this.labelBaudrate.Size = new System.Drawing.Size(50, 13);
            this.labelBaudrate.TabIndex = 1;
            this.labelBaudrate.Text = "Baudrate";
            // 
            // labelPortNumber
            // 
            this.labelPortNumber.AutoSize = true;
            this.labelPortNumber.Location = new System.Drawing.Point(17, 27);
            this.labelPortNumber.Name = "labelPortNumber";
            this.labelPortNumber.Size = new System.Drawing.Size(61, 13);
            this.labelPortNumber.TabIndex = 0;
            this.labelPortNumber.Text = "Portnumber";
            // 
            // radioButtonTCP_IP
            // 
            this.radioButtonTCP_IP.AutoSize = true;
            this.radioButtonTCP_IP.Location = new System.Drawing.Point(409, 16);
            this.radioButtonTCP_IP.Name = "radioButtonTCP_IP";
            this.radioButtonTCP_IP.Size = new System.Drawing.Size(61, 17);
            this.radioButtonTCP_IP.TabIndex = 5;
            this.radioButtonTCP_IP.Text = "TCP/IP";
            this.radioButtonTCP_IP.UseVisualStyleBackColor = true;
            this.radioButtonTCP_IP.CheckedChanged += new System.EventHandler(this.radioButtonTCP_IP_CheckedChanged);
            // 
            // radioButtonSerialPort
            // 
            this.radioButtonSerialPort.AutoSize = true;
            this.radioButtonSerialPort.Location = new System.Drawing.Point(409, 39);
            this.radioButtonSerialPort.Name = "radioButtonSerialPort";
            this.radioButtonSerialPort.Size = new System.Drawing.Size(73, 17);
            this.radioButtonSerialPort.TabIndex = 6;
            this.radioButtonSerialPort.Text = "Serial Port";
            this.radioButtonSerialPort.UseVisualStyleBackColor = true;
            this.radioButtonSerialPort.CheckedChanged += new System.EventHandler(this.radioButtonSerialPort_CheckedChanged);
            // 
            // radioButtonUSB
            // 
            this.radioButtonUSB.AutoSize = true;
            this.radioButtonUSB.Location = new System.Drawing.Point(409, 62);
            this.radioButtonUSB.Name = "radioButtonUSB";
            this.radioButtonUSB.Size = new System.Drawing.Size(47, 17);
            this.radioButtonUSB.TabIndex = 7;
            this.radioButtonUSB.Text = "USB";
            this.radioButtonUSB.UseVisualStyleBackColor = true;
            this.radioButtonUSB.CheckedChanged += new System.EventHandler(this.radioButtonUSB_CheckedChanged);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(409, 146);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 8;
            this.buttonConnect.Text = "C&onnect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // PortConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 197);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.radioButtonUSB);
            this.Controls.Add(this.radioButtonSerialPort);
            this.Controls.Add(this.radioButtonTCP_IP);
            this.Controls.Add(this.groupBoxSerialPort);
            this.Controls.Add(this.groupBoxTCP_IP);
            this.Name = "PortConnection";
            this.ShowIcon = false;
            this.Text = "Connection configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PortConnection_FormClosing);
            this.groupBoxTCP_IP.ResumeLayout(false);
            this.groupBoxTCP_IP.PerformLayout();
            this.groupBoxSerialPort.ResumeLayout(false);
            this.groupBoxSerialPort.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTCP_IP;
        private System.Windows.Forms.GroupBox groupBoxSerialPort;
        private System.Windows.Forms.TextBox textBoxTimeout;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.Label labelTimeout;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.ComboBox comboBoxFrame;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.ComboBox comboBoxPortnumber;
        private System.Windows.Forms.TextBox textBoxTimeoutSP;
        private System.Windows.Forms.Label labelTimeoutSP;
        private System.Windows.Forms.Label labelFrame;
        private System.Windows.Forms.Label labelBaudrate;
        private System.Windows.Forms.Label labelPortNumber;
        private System.Windows.Forms.RadioButton radioButtonTCP_IP;
        private System.Windows.Forms.RadioButton radioButtonSerialPort;
        private System.Windows.Forms.RadioButton radioButtonUSB;
        private System.Windows.Forms.Button buttonConnect;
    }
}

