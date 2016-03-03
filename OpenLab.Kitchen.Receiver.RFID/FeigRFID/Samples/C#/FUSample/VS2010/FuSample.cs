using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using OBID;


namespace FUSample
{
	/// <summary>
	/// Zusammenfassung für Form1.
	/// </summary>
	public class FuSample : System.Windows.Forms.Form
	{
		private GroupBox groupBox3;
		private Label label2;
		private TextBox DatAdr;
		private Label label3;
		private Label label4;
		private TextBox DatSetC1;
		private TextBox DatSetC2;
		private Label label7;
		private Label label8;
		private TextBox MuxOutCh2;
		private Label label6;
		private TextBox MuxAdr;
		private Label label1;
		private TextBox MuxOutCh1;
		private Label label5;
		private GroupBox groupBox2;
		private Label label9;
		private Label label10;
		private Label label11;
		private TextBox DatMode;
		private TextBox DatNewAdr;
		private Button btn_0xCB_DatSetMode;
		private Button btn_0xCA_DatSetAddress;
		private Button btn_0xC9_DatDetect;
		private Button btn_0xC8_DatStoreSettings;
		private Button btn_0xC6_DatStartTuning;
		private Button btn_0xC5_DatReTuning;
		private Button btn_0xC4_DatSetOutputs;
		private Button btn_0xC3_DatGetAntennaValues;
		private Button btn_0xC2_DatSetCapacities;
		private Button btn_0xC1_DatCpuReset;
		private Button btn_0xC0_DatGetFirmwareVersion;
		private Button btn_0xDF_MuxGetFirmwareVersion;
		private Button btn_0xDE_MuxCpuReset;
		private Button btn_0xDD_MuxSelectChannel;
		private Button btn_0xDC_MuxDetect;
		private CheckBox DatOut1;
		private CheckBox DatOut2;
		private CheckBox DatOut3;
        private CheckBox checkBoxUhf;
        /// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private FedmIscReader reader;		// reader object
        private FedmIscFunctionUnit mux;    // HF Multiplexer
        private FedmIscFunctionUnit umux;   // UHF Multiplexer
		private FedmIscFunctionUnit dat;	// dynamic antenna object


		public FuSample()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

			//
			// TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
		}
		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FuSample));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_0xC8_DatStoreSettings = new System.Windows.Forms.Button();
            this.DatOut3 = new System.Windows.Forms.CheckBox();
            this.DatOut2 = new System.Windows.Forms.CheckBox();
            this.DatOut1 = new System.Windows.Forms.CheckBox();
            this.btn_0xC4_DatSetOutputs = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.DatMode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DatNewAdr = new System.Windows.Forms.TextBox();
            this.btn_0xCB_DatSetMode = new System.Windows.Forms.Button();
            this.btn_0xCA_DatSetAddress = new System.Windows.Forms.Button();
            this.btn_0xC9_DatDetect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DatSetC2 = new System.Windows.Forms.TextBox();
            this.DatSetC1 = new System.Windows.Forms.TextBox();
            this.btn_0xC6_DatStartTuning = new System.Windows.Forms.Button();
            this.btn_0xC5_DatReTuning = new System.Windows.Forms.Button();
            this.btn_0xC2_DatSetCapacities = new System.Windows.Forms.Button();
            this.btn_0xC3_DatGetAntennaValues = new System.Windows.Forms.Button();
            this.btn_0xC0_DatGetFirmwareVersion = new System.Windows.Forms.Button();
            this.btn_0xC1_DatCpuReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DatAdr = new System.Windows.Forms.TextBox();
            this.MuxOutCh2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MuxAdr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_0xDF_MuxGetFirmwareVersion = new System.Windows.Forms.Button();
            this.btn_0xDE_MuxCpuReset = new System.Windows.Forms.Button();
            this.MuxOutCh1 = new System.Windows.Forms.TextBox();
            this.btn_0xDD_MuxSelectChannel = new System.Windows.Forms.Button();
            this.btn_0xDC_MuxDetect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxUhf = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_0xC8_DatStoreSettings);
            this.groupBox3.Controls.Add(this.DatOut3);
            this.groupBox3.Controls.Add(this.DatOut2);
            this.groupBox3.Controls.Add(this.DatOut1);
            this.groupBox3.Controls.Add(this.btn_0xC4_DatSetOutputs);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.DatMode);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.DatNewAdr);
            this.groupBox3.Controls.Add(this.btn_0xCB_DatSetMode);
            this.groupBox3.Controls.Add(this.btn_0xCA_DatSetAddress);
            this.groupBox3.Controls.Add(this.btn_0xC9_DatDetect);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.DatSetC2);
            this.groupBox3.Controls.Add(this.DatSetC1);
            this.groupBox3.Controls.Add(this.btn_0xC6_DatStartTuning);
            this.groupBox3.Controls.Add(this.btn_0xC5_DatReTuning);
            this.groupBox3.Controls.Add(this.btn_0xC2_DatSetCapacities);
            this.groupBox3.Controls.Add(this.btn_0xC3_DatGetAntennaValues);
            this.groupBox3.Controls.Add(this.btn_0xC0_DatGetFirmwareVersion);
            this.groupBox3.Controls.Add(this.btn_0xC1_DatCpuReset);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.DatAdr);
            this.groupBox3.Location = new System.Drawing.Point(272, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(512, 384);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dynamic Antenna Tuner";
            // 
            // btn_0xC8_DatStoreSettings
            // 
            this.btn_0xC8_DatStoreSettings.Location = new System.Drawing.Point(264, 152);
            this.btn_0xC8_DatStoreSettings.Name = "btn_0xC8_DatStoreSettings";
            this.btn_0xC8_DatStoreSettings.Size = new System.Drawing.Size(128, 40);
            this.btn_0xC8_DatStoreSettings.TabIndex = 26;
            this.btn_0xC8_DatStoreSettings.Text = "[0xC8] Store Settings";
            this.btn_0xC8_DatStoreSettings.Click += new System.EventHandler(this.btn_0xC8_DatStoreSettings_Click);
            // 
            // DatOut3
            // 
            this.DatOut3.Location = new System.Drawing.Point(160, 352);
            this.DatOut3.Name = "DatOut3";
            this.DatOut3.Size = new System.Drawing.Size(56, 16);
            this.DatOut3.TabIndex = 25;
            this.DatOut3.Text = "Out 3";
            // 
            // DatOut2
            // 
            this.DatOut2.Location = new System.Drawing.Point(160, 336);
            this.DatOut2.Name = "DatOut2";
            this.DatOut2.Size = new System.Drawing.Size(56, 16);
            this.DatOut2.TabIndex = 24;
            this.DatOut2.Text = "Out 2";
            // 
            // DatOut1
            // 
            this.DatOut1.Location = new System.Drawing.Point(160, 320);
            this.DatOut1.Name = "DatOut1";
            this.DatOut1.Size = new System.Drawing.Size(56, 16);
            this.DatOut1.TabIndex = 23;
            this.DatOut1.Text = "Out 1";
            // 
            // btn_0xC4_DatSetOutputs
            // 
            this.btn_0xC4_DatSetOutputs.Location = new System.Drawing.Point(16, 320);
            this.btn_0xC4_DatSetOutputs.Name = "btn_0xC4_DatSetOutputs";
            this.btn_0xC4_DatSetOutputs.Size = new System.Drawing.Size(128, 40);
            this.btn_0xC4_DatSetOutputs.TabIndex = 22;
            this.btn_0xC4_DatSetOutputs.Text = "[0xC4] Set Outputs";
            this.btn_0xC4_DatSetOutputs.Click += new System.EventHandler(this.btn_0xC4_DatSetOutputs_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(160, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "C1";
            // 
            // DatMode
            // 
            this.DatMode.Location = new System.Drawing.Point(464, 330);
            this.DatMode.Name = "DatMode";
            this.DatMode.Size = new System.Drawing.Size(24, 20);
            this.DatMode.TabIndex = 20;
            this.DatMode.Text = "0";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(408, 334);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "Mode";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(408, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "New Adr";
            // 
            // DatNewAdr
            // 
            this.DatNewAdr.Location = new System.Drawing.Point(464, 274);
            this.DatNewAdr.Name = "DatNewAdr";
            this.DatNewAdr.Size = new System.Drawing.Size(24, 20);
            this.DatNewAdr.TabIndex = 17;
            this.DatNewAdr.Text = "0";
            // 
            // btn_0xCB_DatSetMode
            // 
            this.btn_0xCB_DatSetMode.Location = new System.Drawing.Point(264, 320);
            this.btn_0xCB_DatSetMode.Name = "btn_0xCB_DatSetMode";
            this.btn_0xCB_DatSetMode.Size = new System.Drawing.Size(128, 40);
            this.btn_0xCB_DatSetMode.TabIndex = 16;
            this.btn_0xCB_DatSetMode.Text = "[0xCB] Set Mode";
            this.btn_0xCB_DatSetMode.Click += new System.EventHandler(this.btn_0xCB_DatSetMode_Click);
            // 
            // btn_0xCA_DatSetAddress
            // 
            this.btn_0xCA_DatSetAddress.Location = new System.Drawing.Point(264, 264);
            this.btn_0xCA_DatSetAddress.Name = "btn_0xCA_DatSetAddress";
            this.btn_0xCA_DatSetAddress.Size = new System.Drawing.Size(128, 40);
            this.btn_0xCA_DatSetAddress.TabIndex = 15;
            this.btn_0xCA_DatSetAddress.Text = "[0xCA] Set Address";
            this.btn_0xCA_DatSetAddress.Click += new System.EventHandler(this.btn_0xCA_DatSetAddress_Click);
            // 
            // btn_0xC9_DatDetect
            // 
            this.btn_0xC9_DatDetect.Location = new System.Drawing.Point(264, 208);
            this.btn_0xC9_DatDetect.Name = "btn_0xC9_DatDetect";
            this.btn_0xC9_DatDetect.Size = new System.Drawing.Size(128, 40);
            this.btn_0xC9_DatDetect.TabIndex = 14;
            this.btn_0xC9_DatDetect.Text = "[0xC9] Detect";
            this.btn_0xC9_DatDetect.Click += new System.EventHandler(this.btn_0xC9_DatDetect_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(160, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "C2";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.Location = new System.Drawing.Point(160, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 0);
            this.label3.TabIndex = 12;
            this.label3.Text = "C1";
            // 
            // DatSetC2
            // 
            this.DatSetC2.Location = new System.Drawing.Point(192, 230);
            this.DatSetC2.Name = "DatSetC2";
            this.DatSetC2.Size = new System.Drawing.Size(24, 20);
            this.DatSetC2.TabIndex = 11;
            this.DatSetC2.Text = "0";
            // 
            // DatSetC1
            // 
            this.DatSetC1.Location = new System.Drawing.Point(192, 206);
            this.DatSetC1.Name = "DatSetC1";
            this.DatSetC1.Size = new System.Drawing.Size(24, 20);
            this.DatSetC1.TabIndex = 10;
            this.DatSetC1.Text = "0";
            // 
            // btn_0xC6_DatStartTuning
            // 
            this.btn_0xC6_DatStartTuning.Location = new System.Drawing.Point(264, 96);
            this.btn_0xC6_DatStartTuning.Name = "btn_0xC6_DatStartTuning";
            this.btn_0xC6_DatStartTuning.Size = new System.Drawing.Size(128, 40);
            this.btn_0xC6_DatStartTuning.TabIndex = 9;
            this.btn_0xC6_DatStartTuning.Text = "[0xC6] Start Tuning";
            this.btn_0xC6_DatStartTuning.Click += new System.EventHandler(this.btn_0xC6_DatStartTuning_Click);
            // 
            // btn_0xC5_DatReTuning
            // 
            this.btn_0xC5_DatReTuning.Location = new System.Drawing.Point(264, 40);
            this.btn_0xC5_DatReTuning.Name = "btn_0xC5_DatReTuning";
            this.btn_0xC5_DatReTuning.Size = new System.Drawing.Size(128, 40);
            this.btn_0xC5_DatReTuning.TabIndex = 8;
            this.btn_0xC5_DatReTuning.Text = "[0xC5] Re-Tuning";
            this.btn_0xC5_DatReTuning.Click += new System.EventHandler(this.btn_0xC5_DatReTuning_Click);
            // 
            // btn_0xC2_DatSetCapacities
            // 
            this.btn_0xC2_DatSetCapacities.Location = new System.Drawing.Point(16, 208);
            this.btn_0xC2_DatSetCapacities.Name = "btn_0xC2_DatSetCapacities";
            this.btn_0xC2_DatSetCapacities.Size = new System.Drawing.Size(128, 40);
            this.btn_0xC2_DatSetCapacities.TabIndex = 7;
            this.btn_0xC2_DatSetCapacities.Text = "[0xC2] Set Capacities";
            this.btn_0xC2_DatSetCapacities.Click += new System.EventHandler(this.btn_0xC2_DatSetCapacities_Click);
            // 
            // btn_0xC3_DatGetAntennaValues
            // 
            this.btn_0xC3_DatGetAntennaValues.Location = new System.Drawing.Point(16, 264);
            this.btn_0xC3_DatGetAntennaValues.Name = "btn_0xC3_DatGetAntennaValues";
            this.btn_0xC3_DatGetAntennaValues.Size = new System.Drawing.Size(128, 40);
            this.btn_0xC3_DatGetAntennaValues.TabIndex = 6;
            this.btn_0xC3_DatGetAntennaValues.Text = "[0xC3] Get Antenna Values";
            this.btn_0xC3_DatGetAntennaValues.Click += new System.EventHandler(this.btn_0xC3_DatGetAntennaValues_Click);
            // 
            // btn_0xC0_DatGetFirmwareVersion
            // 
            this.btn_0xC0_DatGetFirmwareVersion.Location = new System.Drawing.Point(16, 96);
            this.btn_0xC0_DatGetFirmwareVersion.Name = "btn_0xC0_DatGetFirmwareVersion";
            this.btn_0xC0_DatGetFirmwareVersion.Size = new System.Drawing.Size(128, 40);
            this.btn_0xC0_DatGetFirmwareVersion.TabIndex = 5;
            this.btn_0xC0_DatGetFirmwareVersion.Text = "[0xC0] Get Firmware Version";
            this.btn_0xC0_DatGetFirmwareVersion.Click += new System.EventHandler(this.btn_0xC0_DatGetFirmwareVersion_Click);
            // 
            // btn_0xC1_DatCpuReset
            // 
            this.btn_0xC1_DatCpuReset.Location = new System.Drawing.Point(16, 152);
            this.btn_0xC1_DatCpuReset.Name = "btn_0xC1_DatCpuReset";
            this.btn_0xC1_DatCpuReset.Size = new System.Drawing.Size(128, 40);
            this.btn_0xC1_DatCpuReset.TabIndex = 5;
            this.btn_0xC1_DatCpuReset.Text = "[0xC1] CPU-Reset";
            this.btn_0xC1_DatCpuReset.Click += new System.EventHandler(this.btn_0xC1_DatCpuReset_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Address";
            // 
            // DatAdr
            // 
            this.DatAdr.Location = new System.Drawing.Point(88, 38);
            this.DatAdr.Name = "DatAdr";
            this.DatAdr.Size = new System.Drawing.Size(32, 20);
            this.DatAdr.TabIndex = 7;
            this.DatAdr.Text = "1";
            // 
            // MuxOutCh2
            // 
            this.MuxOutCh2.Location = new System.Drawing.Point(200, 174);
            this.MuxOutCh2.Name = "MuxOutCh2";
            this.MuxOutCh2.Size = new System.Drawing.Size(24, 20);
            this.MuxOutCh2.TabIndex = 19;
            this.MuxOutCh2.Text = "0";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.Location = new System.Drawing.Point(160, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 0);
            this.label6.TabIndex = 18;
            this.label6.Text = "Ch2";
            // 
            // MuxAdr
            // 
            this.MuxAdr.Location = new System.Drawing.Point(74, 38);
            this.MuxAdr.Name = "MuxAdr";
            this.MuxAdr.Size = new System.Drawing.Size(32, 20);
            this.MuxAdr.TabIndex = 6;
            this.MuxAdr.Text = "1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Address";
            // 
            // btn_0xDF_MuxGetFirmwareVersion
            // 
            this.btn_0xDF_MuxGetFirmwareVersion.Location = new System.Drawing.Point(16, 264);
            this.btn_0xDF_MuxGetFirmwareVersion.Name = "btn_0xDF_MuxGetFirmwareVersion";
            this.btn_0xDF_MuxGetFirmwareVersion.Size = new System.Drawing.Size(128, 40);
            this.btn_0xDF_MuxGetFirmwareVersion.TabIndex = 4;
            this.btn_0xDF_MuxGetFirmwareVersion.Text = "[0xDF] Get Firmware Version";
            this.btn_0xDF_MuxGetFirmwareVersion.Click += new System.EventHandler(this.btn_0xDF_MuxGetFirmwareVersion_Click);
            // 
            // btn_0xDE_MuxCpuReset
            // 
            this.btn_0xDE_MuxCpuReset.Location = new System.Drawing.Point(16, 208);
            this.btn_0xDE_MuxCpuReset.Name = "btn_0xDE_MuxCpuReset";
            this.btn_0xDE_MuxCpuReset.Size = new System.Drawing.Size(128, 40);
            this.btn_0xDE_MuxCpuReset.TabIndex = 3;
            this.btn_0xDE_MuxCpuReset.Text = "[0xDE] CPU-Reset";
            this.btn_0xDE_MuxCpuReset.Click += new System.EventHandler(this.btn_0xDE_MuxCpuReset_Click);
            // 
            // MuxOutCh1
            // 
            this.MuxOutCh1.Location = new System.Drawing.Point(200, 150);
            this.MuxOutCh1.Name = "MuxOutCh1";
            this.MuxOutCh1.Size = new System.Drawing.Size(24, 20);
            this.MuxOutCh1.TabIndex = 2;
            this.MuxOutCh1.Text = "0";
            // 
            // btn_0xDD_MuxSelectChannel
            // 
            this.btn_0xDD_MuxSelectChannel.Location = new System.Drawing.Point(16, 152);
            this.btn_0xDD_MuxSelectChannel.Name = "btn_0xDD_MuxSelectChannel";
            this.btn_0xDD_MuxSelectChannel.Size = new System.Drawing.Size(128, 40);
            this.btn_0xDD_MuxSelectChannel.TabIndex = 1;
            this.btn_0xDD_MuxSelectChannel.Text = "[0xDD] Select Channel";
            this.btn_0xDD_MuxSelectChannel.Click += new System.EventHandler(this.btn_0xDD_MuxSelectChannel_Click);
            // 
            // btn_0xDC_MuxDetect
            // 
            this.btn_0xDC_MuxDetect.Location = new System.Drawing.Point(16, 96);
            this.btn_0xDC_MuxDetect.Name = "btn_0xDC_MuxDetect";
            this.btn_0xDC_MuxDetect.Size = new System.Drawing.Size(128, 40);
            this.btn_0xDC_MuxDetect.TabIndex = 0;
            this.btn_0xDC_MuxDetect.Text = "[0xDC] Detect";
            this.btn_0xDC_MuxDetect.Click += new System.EventHandler(this.btn_0xDC_MuxDetect_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.Location = new System.Drawing.Point(160, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 0);
            this.label5.TabIndex = 17;
            this.label5.Text = "Ch1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxUhf);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.MuxOutCh2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.MuxAdr);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btn_0xDF_MuxGetFirmwareVersion);
            this.groupBox2.Controls.Add(this.btn_0xDE_MuxCpuReset);
            this.groupBox2.Controls.Add(this.MuxOutCh1);
            this.groupBox2.Controls.Add(this.btn_0xDD_MuxSelectChannel);
            this.groupBox2.Controls.Add(this.btn_0xDC_MuxDetect);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(16, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 384);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Multiplexer";
            // 
            // checkBoxUhf
            // 
            this.checkBoxUhf.AutoSize = true;
            this.checkBoxUhf.Location = new System.Drawing.Point(129, 40);
            this.checkBoxUhf.Name = "checkBoxUhf";
            this.checkBoxUhf.Size = new System.Drawing.Size(48, 17);
            this.checkBoxUhf.TabIndex = 22;
            this.checkBoxUhf.Text = "UHF";
            this.checkBoxUhf.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(152, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "OutCh2";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(152, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "OutCh1";
            // 
            // FuSample
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(800, 413);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FuSample";
            this.Text = "FUSample for HF and UHF Function Units  -  FEIG ELECTRONIC GmbH";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FuSample());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
//			int back = 0;
			try
			{
				reader = new FedmIscReader();
                mux = new FedmIscFunctionUnit(reader, FedmIscFunctionUnit.FU_TYPE_MUX);
                umux = new FedmIscFunctionUnit(reader, FedmIscFunctionUnit.FU_TYPE_UMUX);
                dat = new FedmIscFunctionUnit(reader, FedmIscFunctionUnit.FU_TYPE_DAT);

// the next block is a supplement to manage a complex function unit tree with one root element
// but be care with this methods !! Please have a look to the ISC.SDK.NET manual.
// enable this block for debugging purpose
/*				back = mux.AddChild(1, dat);// a previous created function unit object is added to the 
 *											// child list of the root
				
				FedmIscFunctionUnit child;	// local declaration of a child
				child = mux.GetChild(1);	// local child object is returned from internal child list
											// (identical with object dat)

				back = mux.DeleteChild(1);	// child is removed from internal table, but the object (dat) 
											// exists continuously.
				child = mux.GetChild(1);	// child is unvalid
				back = mux.DeleteChild(1);	// nothing happens
*/
			}
			catch (FedmException ex)
			{
				MessageBox.Show(ex.Message);
			}

			try
			{
				reader.ConnectCOMM(1,true); // COM-Port 1
				reader.SetBusAddress(255);
				reader.SetPortPara("Baud", "38400");
				reader.SetPortPara("Frame", "8E1");
			}
			catch (FedmException ex)
			{
				MessageBox.Show(ex.Message,"Error - FedmException");
			}
			catch (FePortDriverException ex)
			{
                MessageBox.Show(ex.Message, "Error - FePortDriverException");
			}
		}

		private void Form1_Closing()
		{
			reader.DisConnect();
		}

		private void btn_0xDC_MuxDetect_Click(object sender, System.EventArgs e)
		{
            int back = 0;

            if (checkBoxUhf.Checked)
            {
                umux.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_MUX_ADR, uint.Parse(MuxAdr.Text));
                back = umux.SendProtocol(0xDC);
            }
            else
            {
                mux.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_MUX_ADR, uint.Parse(MuxAdr.Text));
                back = mux.SendProtocol(0xDC);
            }
			string msg;
			if(back <= 0)
			{
				msg  = "Return value = " + back.ToString() + "\n\n";
				msg += dat.GetErrorText(back);
			}
			else
			{
				msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
				msg += reader.GetStatusText((byte)back);
			}
			MessageBox.Show(msg);
		}

		private void btn_0xDD_MuxSelectChannel_Click(object sender, System.EventArgs e)
		{
            int back = 0;

            if (checkBoxUhf.Checked)
            {
                umux.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_MUX_ADR, uint.Parse(MuxAdr.Text));
                umux.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_MUX_OUT_CH1, byte.Parse(MuxOutCh1.Text));
                back = umux.SendProtocol(0xDD);
            }
            else
            {
                mux.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_MUX_ADR, uint.Parse(MuxAdr.Text));
                mux.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_MUX_OUT_CH1, byte.Parse(MuxOutCh1.Text));
                mux.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_MUX_OUT_CH2, byte.Parse(MuxOutCh2.Text));
                back = mux.SendProtocol(0xDD);
            }
			string msg;
			if(back <= 0)
			{
				msg  = "Return value = " + back.ToString() + "\n\n";
				msg += dat.GetErrorText(back);
			}
			else
			{
				msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
				msg += reader.GetStatusText((byte)back);
			}
			MessageBox.Show(msg);
		}

		private void btn_0xDE_MuxCpuReset_Click(object sender, System.EventArgs e)
		{
            int back = 0;

            if (checkBoxUhf.Checked)
            {
                umux.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_MUX_ADR, uint.Parse(MuxAdr.Text));
                back = umux.SendProtocol(0xDE);
            }
            else
            {
                mux.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_MUX_ADR, uint.Parse(MuxAdr.Text));
                back = mux.SendProtocol(0xDE);
            }
			string msg;
			if(back <= 0)
			{
				msg  = "Return value = " + back.ToString() + "\n\n";
				msg += dat.GetErrorText(back);
			}
			else
			{
				msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
				msg += reader.GetStatusText((byte)back);
			}
			MessageBox.Show(msg);
		}

		private void btn_0xDF_MuxGetFirmwareVersion_Click(object sender, System.EventArgs e)
		{
            int back = 0;

            if (checkBoxUhf.Checked)
            {
                umux.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_MUX_ADR, uint.Parse(MuxAdr.Text));
                back = umux.SendProtocol(0xDF);
            }
            else
            {
                mux.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_MUX_ADR, uint.Parse(MuxAdr.Text));
                back = mux.SendProtocol(0xDF);
            }
			if(back != 0)
			{
				string msg;
				if(back <= 0)
				{
					msg  = "Return value = " + back.ToString() + "\n\n";
					msg += dat.GetErrorText(back);
				}
				else
				{
					msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
					msg += reader.GetStatusText((byte)back);
				}
				MessageBox.Show(msg);
			}
			else
			{
				string sSwRevMain, sSwRevSub, sSwType, sHwRev, sDip;
                if (checkBoxUhf.Checked)
                {
                    umux.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_SW_REV_MAIN, out sSwRevMain);
                    umux.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_SW_REV_SUB, out sSwRevSub);
                    umux.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_SW_TYPE, out sSwType);
                    umux.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_HW_REV, out sHwRev);
                    umux.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_DIP, out sDip);
                }
                else
                {
                    mux.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_SW_REV_MAIN, out sSwRevMain);
                    mux.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_SW_REV_SUB, out sSwRevSub);
                    mux.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_SW_TYPE, out sSwType);
                    mux.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_HW_REV, out sHwRev);
                    mux.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_DIP, out sDip);
                }
				string msg = "SW-REV = " + sSwRevMain + "." + sSwRevSub + "\n";
				msg += "SW-TYPE = 0x" + sSwType + "\n";
				msg += "HW-REV = 0x" + sHwRev + "\n";
				msg += "DIP = 0x" + sDip;
				MessageBox.Show(msg);
			}		
		}

		private void btn_0xC0_DatGetFirmwareVersion_Click(object sender, System.EventArgs e)
		{
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ADR, uint.Parse(DatAdr.Text));	
			int back = dat.SendProtocol(0xC0);
			if(back != 0)
			{
				string msg;
				if(back <= 0)
				{
					msg  = "Return value = " + back.ToString() + "\n\n";
					msg += dat.GetErrorText(back);
				}
				else
				{
					msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
					msg += reader.GetStatusText((byte)back);
				}
				MessageBox.Show(msg);
			}
			else
			{
				string sSwRevMain, sSwRevSub, sSwType, sHwRev;
				dat.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_SW_REV_MAIN, out sSwRevMain);
				dat.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_SW_REV_SUB, out sSwRevSub);
				dat.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_SW_TYPE, out sSwType);
				dat.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_SOFTVER_HW_REV, out sHwRev);
				string msg = "SW-REV = " + sSwRevMain + "." + sSwRevSub + "\n";
				msg += "SW-TYPE = 0x" + sSwType + "\n";
				msg += "HW-REV = 0x" + sHwRev;
				MessageBox.Show(msg);
			}
		}

		private void btn_0xC1_DatCpuReset_Click(object sender, System.EventArgs e)
		{
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ADR, uint.Parse(DatAdr.Text));	
			int back = dat.SendProtocol(0xC1);
			string msg;
			if(back <= 0)
			{
				msg  = "Return value = " + back.ToString() + "\n\n";
				msg += dat.GetErrorText(back);
			}
			else
			{
				msg  = "Return value = " + back.ToString("X") + "\n\n";
				msg += reader.GetStatusText((byte)back);
			}
			MessageBox.Show(msg);
		}

		private void btn_0xC2_DatSetCapacities_Click(object sender, System.EventArgs e)
		{
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ADR, uint.Parse(DatAdr.Text));	
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ANT_VAL_C1, uint.Parse(DatSetC1.Text));	
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ANT_VAL_C2, uint.Parse(DatSetC2.Text));	
			int back = dat.SendProtocol(0xC2);
			string msg;
			if(back <= 0)
			{
				msg  = "Return value = " + back.ToString() + "\n\n";
				msg += dat.GetErrorText(back);
			}
			else
			{
				msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
				msg += reader.GetStatusText((byte)back);
			}
			MessageBox.Show(msg);
		}

		private void btn_0xC3_DatGetAntennaValues_Click(object sender, System.EventArgs e)
		{
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ADR, uint.Parse(DatAdr.Text));	
			int back = dat.SendProtocol(0xC3);
			if(back != 0)
			{
				string msg;
				if(back <= 0)
				{
					msg  = "Return value = " + back.ToString() + "\n\n";
					msg += dat.GetErrorText(back);
				}
				else
				{
					msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
					msg += reader.GetStatusText((byte)back);
				}
				MessageBox.Show(msg);
			}
			else
			{
				string sC1, sC2, sR, sPhi, sTuSt;
				dat.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ANT_VAL_C1, out sC1);
				dat.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ANT_VAL_C2, out sC2);
				dat.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ANT_VAL_R, out sR);
				dat.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ANT_VAL_PHI, out sPhi);
				dat.GetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ANT_VAL_STATUS, out sTuSt);
				string msg = "C1 = 0x" + sC1 + "\n";
				msg += "C2 = 0x" + sC2 + "\n";
				msg += "R = 0x" + sR + "\n";
				msg += "Phi = 0x" + sPhi + "\n";
				msg += "TU-ST = 0x" + sTuSt;
				MessageBox.Show(msg);
			}
		}

		private void btn_0xC4_DatSetOutputs_Click(object sender, System.EventArgs e)
		{
			byte DatOut = 0;
			if(DatOut1.Checked)
				DatOut |= 0x01;
			if(DatOut2.Checked)
				DatOut |= 0x02;
			if(DatOut3.Checked)
				DatOut |= 0x04;

			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ADR, uint.Parse(DatAdr.Text));	
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_OUT, DatOut);	
			int back = dat.SendProtocol(0xC4);
			string msg;
			if(back <= 0)
			{
				msg  = "Return value = " + back.ToString() + "\n\n";
				msg += dat.GetErrorText(back);
			}
			else
			{
				msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
				msg += reader.GetStatusText((byte)back);
			}
			MessageBox.Show(msg);
		}

		private void btn_0xC5_DatReTuning_Click(object sender, System.EventArgs e)
		{
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ADR, uint.Parse(DatAdr.Text));	
			int back = dat.SendProtocol(0xC5);
			string msg;
			if(back <= 0)
			{
				msg  = "Return value = " + back.ToString() + "\n\n";
				msg += dat.GetErrorText(back);
			}
			else
			{
				msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
				msg += reader.GetStatusText((byte)back);
			}
			MessageBox.Show(msg);
		}

		private void btn_0xC6_DatStartTuning_Click(object sender, System.EventArgs e)
		{
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ADR, uint.Parse(DatAdr.Text));	
			int back = dat.SendProtocol(0xC6);
			string msg;
			if(back <= 0)
			{
				msg  = "Return value = " + back.ToString() + "\n\n";
				msg += dat.GetErrorText(back);
			}
			else
			{
				msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
				msg += reader.GetStatusText((byte)back);
			}
			MessageBox.Show(msg);
		}

		private void btn_0xC8_DatStoreSettings_Click(object sender, System.EventArgs e)
		{
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ADR, uint.Parse(DatAdr.Text));	
			int back = dat.SendProtocol(0xC8);
			string msg;
			if(back <= 0)
			{
				msg  = "Return value = " + back.ToString() + "\n\n";
				msg += dat.GetErrorText(back);
			}
			else
			{
				msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
				msg += reader.GetStatusText((byte)back);
			}
			MessageBox.Show(msg);
		}

		private void btn_0xC9_DatDetect_Click(object sender, System.EventArgs e)
		{
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ADR, uint.Parse(DatAdr.Text));	
			int back = dat.SendProtocol(0xC9);
			string msg;
			if(back <= 0)
			{
				msg  = "Return value = " + back.ToString() + "\n\n";
				msg += dat.GetErrorText(back);
			}
			else
			{
				msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
				msg += reader.GetStatusText((byte)back);
			}
			MessageBox.Show(msg);
		}

		private void btn_0xCA_DatSetAddress_Click(object sender, System.EventArgs e)
		{
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ADR, uint.Parse(DatAdr.Text));	
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_NEW_ADR, uint.Parse(DatNewAdr.Text));	
			int back = dat.SendProtocol(0xCA);
			string msg;
			if(back <= 0)
			{
				msg  = "Return value = " + back.ToString() + "\n\n";
				msg += dat.GetErrorText(back);
			}
			else
			{
				msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
				msg += reader.GetStatusText((byte)back);
			}
			MessageBox.Show(msg);
		}

		private void btn_0xCB_DatSetMode_Click(object sender, System.EventArgs e)
		{
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_ADR, uint.Parse(DatAdr.Text));	
			dat.SetData(FedmIscFunctionUnitID.FEDM_ISC_FU_TMP_DAT_MODE, uint.Parse(DatMode.Text));	
			int back = dat.SendProtocol(0xCB);
			string msg;
			if(back <= 0)
			{
				msg  = "Return value = " + back.ToString() + "\n\n";
				msg += dat.GetErrorText(back);
			}
			else
			{
				msg  = "Return value = 0x" + back.ToString("X") + "\n\n";
				msg += reader.GetStatusText((byte)back);
			}
			MessageBox.Show(msg);
		}
	}
}
