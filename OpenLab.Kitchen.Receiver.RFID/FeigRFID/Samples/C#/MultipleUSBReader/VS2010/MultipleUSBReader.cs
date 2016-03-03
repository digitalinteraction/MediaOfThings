using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OBID;
        
namespace MultipleUSBReader
{
    
        
    public partial class MultipleUSBReader : Form, FeIscListener,FeUsbListener
    {
        
        private GroupBox groupBoxUSBReadersList;
        private ListBox listBoxUSBReaders;
        private Label labelReadersNumb;
        private Label labelReadersNumber;
        private GroupBox groupBoxProtocols;
        private TextBox textBoxProtocols;
        private GroupBox groupBoxTagsList;
        private ListBox listBoxTags;
        private Label labelTagsNumb;
        private Label labelTagsNumber;
        private Button buttonClean;
        private Button buttonInventory;
       
        FedmIscReader ActReader;  
        SortedList map = new SortedList();
        FeUsb UsbPort;

        int idx;
        long devID;
             
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultipleUSBReader));
            this.groupBoxUSBReadersList = new System.Windows.Forms.GroupBox();
            this.listBoxUSBReaders = new System.Windows.Forms.ListBox();
            this.labelReadersNumb = new System.Windows.Forms.Label();
            this.labelReadersNumber = new System.Windows.Forms.Label();
            this.groupBoxProtocols = new System.Windows.Forms.GroupBox();
            this.buttonClean = new System.Windows.Forms.Button();
            this.textBoxProtocols = new System.Windows.Forms.TextBox();
            this.groupBoxTagsList = new System.Windows.Forms.GroupBox();
            this.buttonInventory = new System.Windows.Forms.Button();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.labelTagsNumb = new System.Windows.Forms.Label();
            this.labelTagsNumber = new System.Windows.Forms.Label();
            this.groupBoxUSBReadersList.SuspendLayout();
            this.groupBoxProtocols.SuspendLayout();
            this.groupBoxTagsList.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUSBReadersList
            // 
            this.groupBoxUSBReadersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxUSBReadersList.Controls.Add(this.listBoxUSBReaders);
            this.groupBoxUSBReadersList.Controls.Add(this.labelReadersNumb);
            this.groupBoxUSBReadersList.Controls.Add(this.labelReadersNumber);
            this.groupBoxUSBReadersList.Location = new System.Drawing.Point(12, 12);
            this.groupBoxUSBReadersList.Name = "groupBoxUSBReadersList";
            this.groupBoxUSBReadersList.Size = new System.Drawing.Size(212, 144);
            this.groupBoxUSBReadersList.TabIndex = 0;
            this.groupBoxUSBReadersList.TabStop = false;
            this.groupBoxUSBReadersList.Text = "USBReadersList";
            // 
            // listBoxUSBReaders
            // 
            this.listBoxUSBReaders.AllowDrop = true;
            this.listBoxUSBReaders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxUSBReaders.FormattingEnabled = true;
            this.listBoxUSBReaders.Location = new System.Drawing.Point(9, 30);
            this.listBoxUSBReaders.Name = "listBoxUSBReaders";
            this.listBoxUSBReaders.Size = new System.Drawing.Size(193, 108);
            this.listBoxUSBReaders.TabIndex = 2;
            this.listBoxUSBReaders.SelectedIndexChanged += new System.EventHandler(this.listBoxUSBReaders_SelectedIndexChanged);
            // 
            // labelReadersNumb
            // 
            this.labelReadersNumb.AutoSize = true;
            this.labelReadersNumb.Location = new System.Drawing.Point(166, 16);
            this.labelReadersNumb.Name = "labelReadersNumb";
            this.labelReadersNumb.Size = new System.Drawing.Size(13, 13);
            this.labelReadersNumb.TabIndex = 1;
            this.labelReadersNumb.Text = "0";
            // 
            // labelReadersNumber
            // 
            this.labelReadersNumber.AutoSize = true;
            this.labelReadersNumber.Location = new System.Drawing.Point(6, 16);
            this.labelReadersNumber.Name = "labelReadersNumber";
            this.labelReadersNumber.Size = new System.Drawing.Size(163, 13);
            this.labelReadersNumber.TabIndex = 0;
            this.labelReadersNumber.Text = "Number of Connected Readers  :";
            // 
            // groupBoxProtocols
            // 
            this.groupBoxProtocols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxProtocols.Controls.Add(this.buttonClean);
            this.groupBoxProtocols.Controls.Add(this.textBoxProtocols);
            this.groupBoxProtocols.Location = new System.Drawing.Point(12, 162);
            this.groupBoxProtocols.Name = "groupBoxProtocols";
            this.groupBoxProtocols.Size = new System.Drawing.Size(584, 199);
            this.groupBoxProtocols.TabIndex = 1;
            this.groupBoxProtocols.TabStop = false;
            this.groupBoxProtocols.Text = "ProtocolWindow";
            // 
            // buttonClean
            // 
            this.buttonClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClean.Location = new System.Drawing.Point(510, 19);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(68, 23);
            this.buttonClean.TabIndex = 1;
            this.buttonClean.Text = "Clean";
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // textBoxProtocols
            // 
            this.textBoxProtocols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProtocols.Location = new System.Drawing.Point(9, 19);
            this.textBoxProtocols.Multiline = true;
            this.textBoxProtocols.Name = "textBoxProtocols";
            this.textBoxProtocols.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxProtocols.Size = new System.Drawing.Size(495, 174);
            this.textBoxProtocols.TabIndex = 0;
            this.textBoxProtocols.TextChanged += new System.EventHandler(this.textBoxProtocols_TextChanged);
            // 
            // groupBoxTagsList
            // 
            this.groupBoxTagsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTagsList.Controls.Add(this.buttonInventory);
            this.groupBoxTagsList.Controls.Add(this.listBoxTags);
            this.groupBoxTagsList.Controls.Add(this.labelTagsNumb);
            this.groupBoxTagsList.Controls.Add(this.labelTagsNumber);
            this.groupBoxTagsList.Location = new System.Drawing.Point(230, 12);
            this.groupBoxTagsList.Name = "groupBoxTagsList";
            this.groupBoxTagsList.Size = new System.Drawing.Size(366, 144);
            this.groupBoxTagsList.TabIndex = 2;
            this.groupBoxTagsList.TabStop = false;
            this.groupBoxTagsList.Text = "TagsList";
            // 
            // buttonInventory
            // 
            this.buttonInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInventory.Location = new System.Drawing.Point(292, 30);
            this.buttonInventory.Name = "buttonInventory";
            this.buttonInventory.Size = new System.Drawing.Size(68, 23);
            this.buttonInventory.TabIndex = 3;
            this.buttonInventory.Text = "Inventory";
            this.buttonInventory.UseVisualStyleBackColor = true;
            this.buttonInventory.Click += new System.EventHandler(this.buttonInventory_Click);
            // 
            // listBoxTags
            // 
            this.listBoxTags.AllowDrop = true;
            this.listBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.Location = new System.Drawing.Point(9, 30);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.Size = new System.Drawing.Size(277, 108);
            this.listBoxTags.TabIndex = 2;
            // 
            // labelTagsNumb
            // 
            this.labelTagsNumb.AutoSize = true;
            this.labelTagsNumb.Location = new System.Drawing.Point(202, 16);
            this.labelTagsNumb.Name = "labelTagsNumb";
            this.labelTagsNumb.Size = new System.Drawing.Size(13, 13);
            this.labelTagsNumb.TabIndex = 1;
            this.labelTagsNumb.Text = "0";
            // 
            // labelTagsNumber
            // 
            this.labelTagsNumber.AutoSize = true;
            this.labelTagsNumber.Location = new System.Drawing.Point(6, 16);
            this.labelTagsNumber.Name = "labelTagsNumber";
            this.labelTagsNumber.Size = new System.Drawing.Size(199, 13);
            this.labelTagsNumber.TabIndex = 0;
            this.labelTagsNumber.Text = "Number of Tags on connected Reader  :";
            // 
            // MultipleUSBReader
            // 
            this.ClientSize = new System.Drawing.Size(608, 373);
            this.Controls.Add(this.groupBoxTagsList);
            this.Controls.Add(this.groupBoxProtocols);
            this.Controls.Add(this.groupBoxUSBReadersList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultipleUSBReader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MultipleUSBReaderSample  -  FEIG ELECTRONIC  -  advanced reader technology";
            this.groupBoxUSBReadersList.ResumeLayout(false);
            this.groupBoxUSBReadersList.PerformLayout();
            this.groupBoxProtocols.ResumeLayout(false);
            this.groupBoxProtocols.PerformLayout();
            this.groupBoxTagsList.ResumeLayout(false);
            this.groupBoxTagsList.PerformLayout();
            this.ResumeLayout(false);

        }
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MultipleUSBReader());
        }

        public void OnConnectReader(int DeviceHdl, long DeviceID)
        {
            AddDevice(DeviceID);
        }

        public void OnDisConnectReader(int DeviceHdl, long DeviceID)
        {
            RemoveDevice(DeviceID);
        }

        //Init usbport  with Events(connect/disconect)     
        public void USBInit()
        {
            long nDeviceID = 0;
            String sDeviceID;
            UsbPort     = new FeUsb();

            UsbPort.AddEventListener(0, (FeUsbListener)this, FeUsbListenerConst.FEUSB_CONNECT_EVENT);
            UsbPort.AddEventListener(0, (FeUsbListener)this, FeUsbListenerConst.FEUSB_DISCONNECT_EVENT);

            try
            {
                UsbPort.ScanAndOpen(FeUsbScanSearch.SCAN_ALL, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            for (int i = 0; i < UsbPort.ScanListSize; i++)
            {
                sDeviceID = UsbPort.GetScanListPara(i, "Device-ID");
                if (sDeviceID.Length % 2 != 0)
                    sDeviceID = "0" + sDeviceID;
                nDeviceID = FeHexConvert.HexStringToLong(sDeviceID);
                AddDevice(nDeviceID);
            }
        }

        public MultipleUSBReader()
        {
             InitializeComponent();
             //Init from USB_Ports
             USBInit();
        }

        private void listBoxUSBReaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select deviceID
            idx = this.listBoxUSBReaders.SelectedIndex;
            if(idx != -1)
            {
                //convert from  String to Long
                devID = Convert.ToInt64(this.listBoxUSBReaders.Text);
            }
        }
        
        private void buttonInventory_Click(object sender, EventArgs e)
        {
            //If not selected deviceID 
            if (idx != -1)
            {
                //Look if DeviceID is in map 
                if ( map.ContainsKey(devID) ==  true)
                {
                    ReadActiveReader(devID);
                }
                else
                {
                    MessageBox.Show (" No Readers are selected! ");
                }
            }
            else
            {
                MessageBox.Show (" Please select  Reader! ");
            }
        }
        
        private void buttonClean_Click(object sender, EventArgs e)
        {
            this.textBoxProtocols.Clear();
        }

        //Add and Connect Reader 
        public void AddDevice(long DeviceID)
        
        {
            FedmIscReader      AdUSBReader;

            AdUSBReader     = new FedmIscReader();

            // add ebent listener for protocol streams to be displayed in a window
            AdUSBReader.AddEventListener((FeIscListener)this, FeIscListenerConst.SEND_STRING_EVENT);
            AdUSBReader.AddEventListener((FeIscListener)this, FeIscListenerConst.RECEIVE_STRING_EVENT);

            // max IIDs for each Inventory
            AdUSBReader.SetTableSize(FedmIscReaderConst.ISO_TABLE, 128);

            //Try to connect Readers 
            try
            {
                //Connect with USB_Port
                AdUSBReader.ConnectUSB((int)DeviceID);
                map.Add(DeviceID, AdUSBReader);
                this.listBoxUSBReaders.Items.Add(DeviceID.ToString()); 
                ReaderCount();
                // Read out ReadInfo of connected reader
                AdUSBReader.ReadReaderInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
		    }
        }
        
        //Remove and disconnect Reader 
        public void RemoveDevice(long DeviceID)
        {
            FedmIscReader      RemUSBReader;  
           
            try
            {
                if (DeviceID != 0)
                {
                    //hold Index hrom Key in SortedList 
                    int KeyIdx = map.IndexOfKey(DeviceID);
                    //Readers with their correct DeviceID 
                    RemUSBReader = (FedmIscReader)map.GetByIndex(KeyIdx);
                    //Remove Reader from USB
                    RemUSBReader.DisConnect();
                    //remove Readers that not more  on USB_Port from intern Scanliste
                    UsbPort.Scan(FeUsbScanSearch.SCAN_PACK, null);
                    //Remove DeviceID from map
                    map.Remove(DeviceID);
                    ReaderCount();
                    this.listBoxUSBReaders.Items.Remove(DeviceID.ToString());
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
	        }
        }

        //Count from Readers
        public void ReaderCount()
        {
            //Convert in string
            string Counter = Convert.ToString(map.Count);
            this.labelReadersNumb.Text = Counter;
        }
        
        //method from Interface FeIscListener
        public void OnReceiveProtocol(FedmIscReader reader, byte[] receiveProtocol) 
        {
        }
        
        //method from Interface FeIscListener
        public void OnReceiveProtocol(FedmIscReader reader, String receiveProtocol)
        {
            DisplayReceiveProtocol(receiveProtocol);
        }
        
        //method from interface FeIscListener    
        public void OnSendProtocol(FedmIscReader reader, byte[] sendProtocol)
        {
        }
        
        //method from interface FeIscListener
        public void OnSendProtocol(FedmIscReader reader, String sendProtocol)
        {
            DisplaySendProtocol(sendProtocol);
        }
        
        //show sent Protocol
        public void DisplaySendProtocol(string protocol)
        {
            this.textBoxProtocols.Text += protocol;
        }
        
        //show received protocol
        public void DisplayReceiveProtocol(string protocol)
        {
            this.textBoxProtocols.Text += protocol;
        }
        
        //Read activated/selected Reader
        public void ReadActiveReader(long DeviceID)
        {
            string[] serialNumber = new string[0]; 
            
            int index;
          
            //Activate from selected reader
            index = map.IndexOfKey(DeviceID);
            ActReader = (FedmIscReader)map.GetByIndex(index);

            ActReader.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_CMD, 0x01);
            ActReader.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, 0x00);
            try
            {
                ActReader.ResetTable(FedmIscReaderConst.ISO_TABLE);

                ActReader.SendProtocol(0x69); // RFReset
                ActReader.SendProtocol(0xB0); // ISOCmd

                while (ActReader.GetLastStatus() == 0x94) // more flag set?
                {
                    ActReader.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_MORE, 0x01);
                    ActReader.SendProtocol(0xB0);
                }
                 //new dimensiion from array serialNumber
                serialNumber    = new string[ActReader.GetTableLength(FedmIscReaderConst.ISO_TABLE)];
                                        
                this.labelTagsNumb.Text = ActReader.GetTableLength(FedmIscReaderConst.ISO_TABLE).ToString();
                
                if(ActReader.GetTableLength(FedmIscReaderConst.ISO_TABLE) > 0)
                {
                    int i;
                    for(i = 0;i <=(ActReader.GetTableLength(FedmIscReaderConst.ISO_TABLE) - 1);i++)
                    {
                        ActReader.GetTableData(i, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_SNR,out serialNumber[i]);
                    }
                    TagChanged(serialNumber);
                 }
                else
                {
                    this.listBoxTags.Items.Clear();
                }
            } 
            catch (Exception ex) 
            {
                 MessageBox.Show(ex.ToString());
            }          
        }
        
        //Show multiple TranspondersID
        public void TagChanged(string[] serialNumber)
        {
            int i;
            this.listBoxTags.Items.Clear();
            for (i = 0;i <= serialNumber.Length - 1;i++)
            {
                if (this.listBoxTags.Items.Contains(serialNumber[i] ))
                {
                }
                else
                {
                    this.listBoxTags.Items.Add(serialNumber[i] );
                }
            }
        }

        private void textBoxProtocols_TextChanged(object sender, EventArgs e)
        {
            this.textBoxProtocols.SelectionStart = this.textBoxProtocols.Text.Length;
            this.textBoxProtocols.SelectionLength = this.textBoxProtocols.Text.Length;
            this.textBoxProtocols.ScrollToCaret();
            this.textBoxProtocols.Refresh();
        }
      
    }
}