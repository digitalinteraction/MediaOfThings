using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using OBID;

//Sample without USB Listener (AddDeviceEvent, RemoveDeviceEvent) !!
// Check also the MultiUSBReader Sample

//namespace OBID
//{
	/// <summary>
	/// Zusammenfassung für Form1.
	/// </summary>
	public class LeserApplikation : System.Windows.Forms.Form
	{

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonSearchForReader;
		private System.Windows.Forms.Button buttonQuit;
		private System.Windows.Forms.ListBox listBoxSerialNumber;
		private System.Windows.Forms.Button buttonClearList;
		private System.Windows.Forms.TextBox textBoxDeviceID;
		private System.Windows.Forms.Button buttonSearchForLabels;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private FedmIscReader reader;

		public LeserApplikation()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				try 
				{
                    
                    if (reader.Connected) 
					{
						reader.DisConnect();
					}
				}
				catch (FePortDriverException ex) 
				{
					Console.WriteLine(ex.ToString());
				}
				catch (FeReaderDriverException ex)
				{
					Console.WriteLine(ex.ToString());
				}
				catch (FedmException ex) 
				{
					Console.WriteLine(ex.ToString());
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeserApplikation));
            this.textBoxDeviceID = new System.Windows.Forms.TextBox();
            this.buttonSearchForReader = new System.Windows.Forms.Button();
            this.listBoxSerialNumber = new System.Windows.Forms.ListBox();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonClearList = new System.Windows.Forms.Button();
            this.buttonSearchForLabels = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxDeviceID
            // 
            this.textBoxDeviceID.Location = new System.Drawing.Point(8, 24);
            this.textBoxDeviceID.Name = "textBoxDeviceID";
            this.textBoxDeviceID.Size = new System.Drawing.Size(264, 20);
            this.textBoxDeviceID.TabIndex = 0;
            // 
            // buttonSearchForReader
            // 
            this.buttonSearchForReader.Location = new System.Drawing.Point(280, 24);
            this.buttonSearchForReader.Name = "buttonSearchForReader";
            this.buttonSearchForReader.Size = new System.Drawing.Size(136, 23);
            this.buttonSearchForReader.TabIndex = 1;
            this.buttonSearchForReader.Text = "Search for USB-Reader";
            this.buttonSearchForReader.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxSerialNumber
            // 
            this.listBoxSerialNumber.Location = new System.Drawing.Point(8, 72);
            this.listBoxSerialNumber.Name = "listBoxSerialNumber";
            this.listBoxSerialNumber.Size = new System.Drawing.Size(264, 147);
            this.listBoxSerialNumber.TabIndex = 2;
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(280, 200);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(136, 23);
            this.buttonQuit.TabIndex = 4;
            this.buttonQuit.Text = "Exit";
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Device Number";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "List of Serial Numbers";
            // 
            // buttonClearList
            // 
            this.buttonClearList.Location = new System.Drawing.Point(280, 104);
            this.buttonClearList.Name = "buttonClearList";
            this.buttonClearList.Size = new System.Drawing.Size(136, 23);
            this.buttonClearList.TabIndex = 9;
            this.buttonClearList.Text = "Clear List";
            this.buttonClearList.Click += new System.EventHandler(this.buttonClearList_Click);
            // 
            // buttonSearchForLabels
            // 
            this.buttonSearchForLabels.Location = new System.Drawing.Point(280, 72);
            this.buttonSearchForLabels.Name = "buttonSearchForLabels";
            this.buttonSearchForLabels.Size = new System.Drawing.Size(136, 24);
            this.buttonSearchForLabels.TabIndex = 10;
            this.buttonSearchForLabels.Text = "Search Tags";
            this.buttonSearchForLabels.Click += new System.EventHandler(this.buttonSearchForLabels_Click);
            // 
            // LeserApplikation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(424, 237);
            this.Controls.Add(this.buttonSearchForLabels);
            this.Controls.Add(this.buttonClearList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.listBoxSerialNumber);
            this.Controls.Add(this.buttonSearchForReader);
            this.Controls.Add(this.textBoxDeviceID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LeserApplikation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USB Reader Application  -  FEIG ELECTRONIC";
            this.Load += new System.EventHandler(this.LeserApplikation_Load);
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
			Application.Run(new LeserApplikation());
		}

		private void LeserApplikation_Load(object sender, System.EventArgs e)
		{
			reader = new FedmIscReader();
			int back = reader.SetTableSize(FedmIscReaderConst.ISO_TABLE, 128);

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
            connect();
		}

		private void buttonQuit_Click(object sender, System.EventArgs e)
		{
			Dispose(true);
		}

		

		private void buttonClearList_Click(object sender, System.EventArgs e)
		{
			this.listBoxSerialNumber.Items.Clear();
		}

		private void buttonSearchForLabels_Click(object sender, System.EventArgs e)
		{
			this.listBoxSerialNumber.Items.Clear();
			
			int back;
            reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_CMD, 0x01);
            reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, 0x00);

            String[] tagType = null;
            String[] serialNumber = null;

			try 
			{
				back = reader.ResetTable(FedmIscReaderConst.ISO_TABLE);
				back = reader.SendProtocol(0x69); // RFReset
				System.Console.Write("RF-Reset: ");
				System.Console.WriteLine(reader.GetErrorText(back));
				back = reader.SendProtocol(0xB0); // ISOCmd
				System.Console.Write("Inventory: ");
				if (back < 0) 
				{
					System.Console.WriteLine(reader.GetErrorText(back));
				}
				else 
				{
					System.Console.WriteLine(reader.GetStatusText((byte)back));
				}
				while (reader.GetLastStatus() == 0x94) // more flag set?
				{ 
					reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_MORE, 0x01);
					reader.SendProtocol(0xB0);
				}

				int length = reader.GetTableLength(FedmIscReaderConst.ISO_TABLE);
				serialNumber = new String[length];
				tagType = new String[length];

				Console.WriteLine(reader.GetTableLength(FedmIscReaderConst.ISO_TABLE));
				if (length > 0) 
				{
					int i;
					for (i = 0; i < reader.GetTableLength(FedmIscReaderConst.ISO_TABLE); i++) 
					{
						reader.GetTableData(i, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_SNR, out serialNumber[i]);
						reader.GetTableData(i, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_TRTYPE, out tagType[i]);
						if (tagType[i].Equals("00")) tagType[i] = "Philips I-Code1";
						if (tagType[i].Equals("01")) tagType[i] = "Texas Instruments Tag-it HF";
						if (tagType[i].Equals("03")) tagType[i] = "ISO15693 Transponder";
						if (tagType[i].Equals("04")) tagType[i] = "14443A";
						if (tagType[i].Equals("05")) tagType[i] = "14443B";
						if (tagType[i].Equals("06")) tagType[i] = "EPC";

						this.listBoxSerialNumber.Items.Add(serialNumber[i] + " - " + tagType[i]);
					}
				}
			}
			catch (Exception ex) 
			{
				System.Console.WriteLine(ex.ToString());
			}		
		}

        private void connect()
        {
            String timeout;

            try
            {
                reader.ConnectUSB(0);
                this.textBoxDeviceID.Text = reader.GetPortPara("Device-ID");
                this.buttonSearchForReader.Enabled = false;
                this.buttonSearchForLabels.Enabled = true;

                // demonstration of increasing the timeout
                // changing can be done only after successful connection
                timeout = reader.GetPortPara("Timeout");
                reader.SetPortPara("Timeout", "3000");
                timeout = reader.GetPortPara("Timeout");
            }
            catch (FePortDriverException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (FeReaderDriverException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (FedmException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

	}
//}
