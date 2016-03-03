using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using OBID;

namespace ScanSample
{
	/// <summary>
	/// Zusammenfassung für Form1.
	/// </summary>
	public class ScanSample : System.Windows.Forms.Form, OBID.FeIscListener
	{
        public delegate void DelegateOnRecProtocol(byte[] protocol);

        private FedmIscReader reader;
        private DelegateOnRecProtocol delOnRecProtocol;

        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox dataWindow;
		private System.Windows.Forms.ComboBox comboAscii;
		private System.Windows.Forms.TextBox textBoxBusAddress;
        private System.Windows.Forms.ComboBox comboSerialPort;
		private System.Windows.Forms.TextBox textBoxTimeout;
		private System.Windows.Forms.CheckBox buttonConnect;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ScanSample()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

			// initializing of reader
			try 
			{
				reader = new FedmIscReader();
                delOnRecProtocol = new DelegateOnRecProtocol(DisplayReceiveProtocol);
			} 
			catch (FedmException e) 
			{
				System.Console.WriteLine(e.ToString());
				Application.Exit();
			}
        
			// Set the parameters in dialog
			comboSerialPort.SelectedItem = Convert.ToString(1);
			textBoxBusAddress.Text = Convert.ToString(255);
			textBoxTimeout.Text = "600";
			buttonConnect.Checked = false;
			comboAscii.SelectedIndex = 1;  //output ASCii
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (reader.Connected) 
				{
					try 
					{
						// remove the listener
						reader.RemoveEventListener(this, FeIscListenerConst.SCANNER_PRT_EVENT);
						reader.DisConnect();
					} 
					catch (Exception) {}
				}

				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanSample));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboAscii = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonConnect = new System.Windows.Forms.CheckBox();
            this.textBoxTimeout = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboSerialPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBusAddress = new System.Windows.Forms.TextBox();
            this.dataWindow = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboAscii);
            this.groupBox1.Location = new System.Drawing.Point(748, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Format";
            // 
            // comboAscii
            // 
            this.comboAscii.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAscii.Items.AddRange(new object[] {
            "Hex",
            "ASCII"});
            this.comboAscii.Location = new System.Drawing.Point(16, 24);
            this.comboAscii.Name = "comboAscii";
            this.comboAscii.Size = new System.Drawing.Size(121, 21);
            this.comboAscii.TabIndex = 0;
            this.comboAscii.SelectedIndexChanged += new System.EventHandler(this.comboAscii_IndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonConnect);
            this.groupBox2.Controls.Add(this.textBoxTimeout);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboSerialPort);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxBusAddress);
            this.groupBox2.Location = new System.Drawing.Point(748, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 176);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Communication Port";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonConnect.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonConnect.Location = new System.Drawing.Point(16, 136);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(120, 24);
            this.buttonConnect.TabIndex = 10;
            this.buttonConnect.Text = "&Connect";
            this.buttonConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonConnect.CheckedChanged += new System.EventHandler(this.buttonConnect_CheckedChanged);
            // 
            // textBoxTimeout
            // 
            this.textBoxTimeout.Location = new System.Drawing.Point(72, 90);
            this.textBoxTimeout.Name = "textBoxTimeout";
            this.textBoxTimeout.Size = new System.Drawing.Size(64, 20);
            this.textBoxTimeout.TabIndex = 9;
            this.textBoxTimeout.Text = "600";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Timeout";
            // 
            // comboSerialPort
            // 
            this.comboSerialPort.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboSerialPort.Location = new System.Drawing.Point(72, 56);
            this.comboSerialPort.Name = "comboSerialPort";
            this.comboSerialPort.Size = new System.Drawing.Size(64, 21);
            this.comboSerialPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "COM";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "BusAdr";
            // 
            // textBoxBusAddress
            // 
            this.textBoxBusAddress.Location = new System.Drawing.Point(72, 24);
            this.textBoxBusAddress.Name = "textBoxBusAddress";
            this.textBoxBusAddress.Size = new System.Drawing.Size(64, 20);
            this.textBoxBusAddress.TabIndex = 0;
            this.textBoxBusAddress.Text = "255";
            // 
            // dataWindow
            // 
            this.dataWindow.Location = new System.Drawing.Point(8, 8);
            this.dataWindow.Multiline = true;
            this.dataWindow.Name = "dataWindow";
            this.dataWindow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dataWindow.Size = new System.Drawing.Size(726, 336);
            this.dataWindow.TabIndex = 2;
            // 
            // ScanSample
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(912, 349);
            this.Controls.Add(this.dataWindow);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScanSample";
            this.Text = "ScanSample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScanSample_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ScanSample());
		}

		public void  OnSendProtocol(FedmIscReader reader, byte[] sendProtocol)
		{
		}

		public void  OnReceiveProtocol(FedmIscReader reader, byte[] receiveProtocol)
        {
//            DelegateOnRecProtocol delOnRecProtocol = new DelegateOnRecProtocol(DisplayReceiveProtocol);
            this.Invoke(delOnRecProtocol, receiveProtocol);
        }

		public void  DisplayReceiveProtocol(byte[] receiveProtocol)
		{
			string data = "";

			if (this.comboAscii.SelectedIndex == 1) 
			{
				for (int i = 0; i < receiveProtocol.Length; i++) 
				{
					data += (char)receiveProtocol[i];
				}
			}
			else 
			{
				data = FeHexConvert.ByteArrayToHexStringWithSpaces(receiveProtocol);
                data += "\r\n";
            }
			this.dataWindow.AppendText(data);
		}

		public void  OnSendProtocol(FedmIscReader reader, string sendProtocol)
		{
			return;
		}

		public void  OnReceiveProtocol(FedmIscReader reader, string receiveProtocol)
		{
			return;
		}

		private void buttonConnect_CheckedChanged(object sender, System.EventArgs e)
		{
			if (buttonConnect.Checked) 
			{            
				try 
				{
                    this.UseWaitCursor = true;
                    buttonConnect.Text = "Dis&connect";
					reader.ConnectCOMM(Int32.Parse((string)comboSerialPort.SelectedItem),true);
                
					// Set the parameters
					reader.SetBusAddress((byte)Int32.Parse(textBoxBusAddress.Text));
					reader.SetPortPara("Timeout", textBoxTimeout.Text);

                    reader.ReadReaderInfo(); // read important reader info
                    reader.ReadCompleteConfiguration(true); // read reader's configuration from EEPROM (this need some time!)

                    // add the listener
                    reader.AddEventListener(this, FeIscListenerConst.SCANNER_PRT_EVENT);
                    this.UseWaitCursor = false;
                } 
				catch (Exception) 
				{
					if (reader.Connected) 
					{
						try 
						{
							reader.RemoveEventListener(this, FeIscListenerConst.SCANNER_PRT_EVENT);
							reader.DisConnect();
						} 
						catch (Exception) {}
					}
					buttonConnect.Checked = false;
					buttonConnect.Text = "&Connect";
					return;
				}
			}
			else 
			{
				try 
				{
					buttonConnect.Text = "&Connect";
					// remove the listener
					reader.RemoveEventListener(this, FeIscListenerConst.SCANNER_PRT_EVENT);
					reader.DisConnect();
				} 
				catch (Exception) {}
			}
        }

        private void ScanSample_FormClosing(object sender, FormClosingEventArgs e)
        {
			if (reader.Connected) 
			{
				try 
				{
					// remove the listener
					reader.RemoveEventListener(this, FeIscListenerConst.SCANNER_PRT_EVENT);
					reader.DisConnect();
				} 
				catch (Exception) {}
			}
        }

        private void comboAscii_IndexChanged(object sender, EventArgs e)
        {
            if (!reader.Connected)
                return;

            // before any host command, the scanner event must be disabled !!
            try
            {
                reader.RemoveEventListener(this, FeIscListenerConst.SCANNER_PRT_EVENT);
            }
            catch (Exception)
            {
                // do anything
            }


            // modify the parameter in the memory...
            if (comboAscii.SelectedIndex == 0)
            {
                reader.SetConfigPara(OBID.ReaderConfig.OperatingMode.ScanMode.DataFormat.Format, (byte)0, true); // unformatted hex
            }
            else
            {
                reader.SetConfigPara(OBID.ReaderConfig.OperatingMode.ScanMode.DataFormat.Format, (byte)2, true); // formatted ascii
            }

            try
            {
                // ... and finally write the reader configuration
                reader.ApplyConfiguration(true);
            }
            catch (Exception)
            {
                // do anything
            }

            // enable scanner event
            try
            {
                reader.AddEventListener(this, FeIscListenerConst.SCANNER_PRT_EVENT);
            }
            catch (Exception)
            {
                // do anything
            }

        }
    }
}
