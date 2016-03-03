using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using OBID;

namespace BRMSample
{
    public partial class BRMSample : Form, FeIscListener
    {                                                    
        //definition of delegatetyp
        public delegate void DelegateTextBoxDataClear();
        public delegate void DelegateReaderDisconnect();
        public delegate void DelegateOnSendProtocol(string sendprotocol);
        public delegate void DelegateOnReceiveProtocol(string receiveprotocol);

        public delegate void DelegateDisplayRecSets(int recSets,
                                                    byte[] type,
                                                    string[] serialNumber,
                                                    string[] dataBlock,
                                                    string[] time,
                                                    string[] date,
                                                    byte[] antennaNr,
                                                    Dictionary<byte, FedmIscRssiItem>[] dicRSSI,
                                                    byte[] input,
                                                    byte[] state);

        PortConnection config;
        OBID.FedmIscReader reader = null;
        bool running = false;
        long count = 0;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BRMSample());
        }

        //constructor
        public BRMSample()
        {
            try
            {
                reader = new FedmIscReader();
                reader.SetTableSize(FedmIscReaderConst.BRM_TABLE, 255);
            }
            catch (FedmException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //declaration from Thread
            Thread MyThread = new Thread(new ThreadStart(ReadThread));

            config = new PortConnection();
            InitializeComponent();
            config.PortConfig(ref reader);
            running = false;
            count = 1;

            //start and reset buttons not enable
            this.buttonResetBRM.Enabled = false;
            this.buttonStartBRM.Enabled = false;
            //Thread starten in Background
            MyThread.IsBackground = true;
            MyThread.Start();
        }

        //Actualy Time propertie
        private string Time 
           {
            get
            {
                DateTime d;
                d = DateTime.Now;

                string t;

                // Get the Date
                if(d.Month.ToString().Trim().Length == 1)
                {
                    t = "0" + d.Month.ToString().Trim() + "/";
                }
                else
                {
                    t = d.Month.ToString().Trim() + "/";
                }
                if(d.Day.ToString().Trim().Length == 1)
                {
                    t += "0" + d.Day.ToString().Trim() + "/";
                }
                else
                {
                    t += d.Day.ToString().Trim() + "/";
                }
                t += d.Year.ToString().Trim() + " ";

                // Get the time
                if(d.Hour.ToString().Trim().Length == 1) 
                {
                    t += "0" + d.Hour.ToString().Trim() + ":";
                }
                else
                {
                    t += d.Hour.ToString().Trim() + ":";
                }
                if(d.Minute.ToString().Trim().Length == 1)
                {
                    t += "0" + d.Minute.ToString().Trim() + ":";
                }
                else
                {
                    t += d.Minute.ToString().Trim() + ":";
                }
                if(d.Second.ToString().Trim().Length == 1)
                {
                    t += "0" + d.Second.ToString().Trim() + ".";
                }
                else
                {
                    t += d.Second.ToString().Trim() + ".";
                }
                if (d.Millisecond.ToString().Trim().Length == 1)
                {
                    t += "00" + d.Millisecond.ToString().Trim() + ".";
                }
                else if (d.Millisecond.ToString().Trim().Length == 2)
                {
                    t += "0" + d.Millisecond.ToString().Trim() + ".";
                }
                    else
                    {
                        t += d.Millisecond.ToString().Trim() + ".";
                    }

                return t;
            }
           }

       /**************************************************Butoons**************************/
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (this.buttonConnect.Text == "Connection")
            {
                //Remove from Events send and receive
                reader.RemoveEventListener(this, FeIscListenerConst.RECEIVE_STRING_EVENT);
                reader.RemoveEventListener(this, FeIscListenerConst.SEND_STRING_EVENT);


                DialogResult reponse = config.ShowDialog();
                if (reader.Connected == true && reponse == DialogResult.Cancel)
                {
                    this.buttonConnect.Text = "Disconnection";
                    this.buttonStartBRM.Enabled = true;
                    this.buttonResetBRM.Enabled = true;
                    try
                    {
                        // read important reader properties and set reader type in reader object
                        //ReaderInfo = reader.ReadReaderInfo();

                        //Init buffer
                        InitBuffer();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    try
                    {
                        //if (ReaderInfo.ReaderType != FedmIscReaderConst.TYPE_ISCLR200)
                        if (reader.GetReaderType() != (byte)FedmIscReaderConst.TYPE_ISCLR200)
                            reader.SetProtocolFrameSupport(Fedm.PRT_FRAME_ADVANCED);

                        //Registry from Events send and receive
                        reader.AddEventListener(this, FeIscListenerConst.SEND_STRING_EVENT);
                        reader.AddEventListener(this, FeIscListenerConst.RECEIVE_STRING_EVENT);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    this.buttonStartBRM.Enabled = false;
                    this.buttonResetBRM.Enabled = false;
                }
            }
            else
            {
                if (this.buttonConnect.Text == "Disconnection")
                {
                    this.buttonConnect.Text = "Connection";
                    reader.DisConnect();
                    this.buttonStartBRM.Text = "Start BRM";
                    this.buttonStartBRM.Enabled = false;
                    this.buttonResetBRM.Enabled = false;
                    running = false;
                }
            }
        }
        
        private void buttonExit_Click(object sender, EventArgs e)
        {
            running = false;
            reader.RemoveEventListener(this, FeIscListenerConst.RECEIVE_STRING_EVENT);
            reader.RemoveEventListener(this, FeIscListenerConst.SEND_STRING_EVENT);
            config.Close();
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.textBoxData.Clear();
            count = 1;
        }

        private void buttonStartBRM_Click(object sender, EventArgs e)
        {
            if (this.buttonStartBRM.Text == "Start BRM" && reader.Connected)
            {
                // rename the button
                this.buttonStartBRM.Text = "Stop BRM";
                running = true;
            }
            else
            {
                this.buttonStartBRM.Text = "Start BRM";
                running = false;
            }

        }

        private void buttonClearProt_Click(object sender, EventArgs e)
        {
            this.textBoxProtocol.Text = "";
        }

        private void buttonResetBRM_Click(object sender, EventArgs e)
        {
            if (reader.Connected)
            {
                InitBuffer();
            }
        }
        /************************************************ENDE******************************/

        /************************************Interface(FeIscListener) Methods*****************************/
        public void OnReceiveProtocol(FedmIscReader reader, byte[] receiveProtocol)
        {
        }

        public void OnReceiveProtocol(FedmIscReader reader, string receiveProtocol)
        {
            IAsyncResult result;
            DelegateOnReceiveProtocol ReceiveProtocolMethod = new DelegateOnReceiveProtocol(DisplayReceiveProtocol);
            result = (IAsyncResult)Invoke(ReceiveProtocolMethod, receiveProtocol);

        }

        public void OnSendProtocol(FedmIscReader reader, byte[] sendProtocol)
        {
        }

        public void OnSendProtocol(FedmIscReader reader, string sendProtocol)
        {
            IAsyncResult result;
            DelegateOnSendProtocol SendProtocolMethod = new DelegateOnSendProtocol(DisplaySendProtocol);
            result = (IAsyncResult)Invoke(SendProtocolMethod, sendProtocol);
        }
        /************************************************ENDE******************************/

        /*********************************************Delegate Methods***********************************************/
        public void DisplayRecSets( int recSets,
                                    byte[] type,
                                    string[] serialNumber,
                                    string[] dataBlock,
                                    string[] time,
                                    string[] date,
                                    byte[] antennaNr,
                                    Dictionary<byte, FedmIscRssiItem>[] dicRSSI,
                                    byte[] input,
                                    byte[] state)
        {
            int i;
            string d;
            string dr = "";

            Dictionary<byte, FedmIscRssiItem> RSSIval;
            FedmIscRssiItem RSSIitem;
            bool bcheck;
            byte antNo;

            FedmBrmTableItem[] brmItems;
            brmItems = (FedmBrmTableItem[])reader.GetTable(FedmIscReaderConst.BRM_TABLE);

            dr += "-----------------------------------------------------------------" + "\r\n";
            dr += "DATE/TIME: " + Time.ToString() + "\r\n";
            dr += "-----------------------------------------------------------------" + "\r\n";
            count = 1; 
            for (i = 0; i < recSets; i++)
             {
                 
                dr += (count).ToString().Trim() + "." + "   TRANSPONDER" + "\r\n";
                count = count + 1;
                if (type[i] >= 0)
                {
                    //just the two last bit
                    d = "0x" + FeHexConvert.IntegerToHexString(type[i]).Substring(FeHexConvert.IntegerToHexString(type[i]).Length - 2, 2);
                    dr += "TR-TYPE:" + "\t" + d.ToString() + "\r\n";
                }

                // Output SeriaNo.
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_SNR))
                {
                    if (serialNumber[i] != null)
                    {
                        dr += "SNR:" + "\t\t" + serialNumber[i].ToString() + "\r\n";
                    }
                }

                // Output Data Blocks
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_RxDB))
                {
                    if (dataBlock[i] != null)
                    {
                        dr += "DB:" + "\t\t" + dataBlock[i].ToString() + "\r\n";
                    }
                }

                // Output Time
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_TIMER))
                {
                    if (time[i] != null)
                    {
                        dr += "READER TIME:" + "\t" + time[i].ToString() + "\r\n";
                    }
                }

                // Output Date
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_DATE))
                {
                    if (date[i] != null)
                    {
                        dr += "READER DATE:" + "\t" + date[i].ToString() + "\r\n";
                    }
                }

                // It is possible either to output the ANT_NR or the RSSI value (this is also important for the reader config!)
                // Output ANT_NR
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_ANT_NR))
                {
                    dr += "ANT. NR:" + "\t\t" + (antennaNr[i].ToString()).Trim() + "\r\n";
                }
                
                // It is possible either to output the ANT_NR or the RSSI value (this is also important for the reader config!) 
                // Output RSSI
                if (dicRSSI.Length > 0)
                {
                    if (dicRSSI[i] != null)
                    {
                        RSSIval = dicRSSI[i];
                        for (antNo = 1; antNo < FedmBrmTableItem.TABLE_MAX_ANTENNA; antNo++)
                        {
                            bcheck = RSSIval.TryGetValue(antNo, out RSSIitem);
                            if (!bcheck)
                                continue;

                            dr += "RSSI of AntNr. " + "\t" + antNo.ToString() + " is " + "-" + RSSIitem.RSSI.ToString() + "dBm" + "\r\n";
                        }
                    }
                }

                // Output INPUT
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_INPUT))
                {
                    dr += "INPUT:" + "\t\t" + (input[i].ToString()).Trim() + "\r\n";
                    dr += "STATE:" + "\t\t" + (state[i].ToString()).Trim() + "\r\n";
                }

                dr += "" + "\r\n";
                dr += "" + "\r\n";
         
            }
            this.textBoxData.AppendText(dr);
            dr = "";
          
        }

        public void TextBoxDataClear()
        {
            this.textBoxData.Text = "";
        }

        public void ReaderDisconnect()
        {
            reader.DisConnect();
            MessageBox.Show("Check the Working Mode of Reader!", "ERROR");
            this.buttonConnect.Text = "Connection";
            this.buttonResetBRM.Enabled = false;
            this.buttonStartBRM.Text = "Start BRM";
            this.buttonStartBRM.Enabled = false;
            running = false;
        }

        public void DisplayReceiveProtocol(string RecProtocol)
        {
            this.textBoxProtocol.Text += RecProtocol;
        }

        public void DisplaySendProtocol(string SendProtocol)
        {
            this.textBoxProtocol.Text += SendProtocol;
        }
        /**********************************************ENDE***********************************************************/
        
        /*******Thread method*****************/
        public void ReadThread()
        {
            int ReqSets;
            int status;

            //declaration of delegateobject 
            DelegateDisplayRecSets DisplayRecSetMethod = new DelegateDisplayRecSets(DisplayRecSets);
            DelegateTextBoxDataClear TextBoxDataClearMethod = new DelegateTextBoxDataClear(TextBoxDataClear);
            DelegateReaderDisconnect ReaderDisconnectMethod = new DelegateReaderDisconnect(ReaderDisconnect);
            object[] obj = new object[10];

            IAsyncResult result;

            ReqSets = 255;


            while (true)
            {
                if (!(running && reader.Connected))
                {
                    continue;
                }
                // read data from reader
                // read max. possible no. of data sets: request 255 data sets
                try
                {
                    //if (ReaderInfo.ReaderType == FedmIscReaderConst.TYPE_ISCLR200)
                    if (reader.GetReaderType() == (byte)FedmIscReaderConst.TYPE_ISCLR200)
                    {
                        reader.SetData(FedmIscReaderID.FEDM_ISCLR_TMP_BRM_SETS, ReqSets);
                        status = reader.SendProtocol(0x21); // old BRM request
                    }
                    else
                    {
                        reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_ADV_BRM_SETS, ReqSets);
                        status = reader.SendProtocol(0x22);
                    }

                    if ((status == 0x00) || (status == 0x83) || (status == 0x84) || (status == 0x85) || (status == 0x93) || (status == 0x94))
                    {
                        object[] obj1 = new object[2];
                        FedmBrmTableItem[] brmItems = new FedmBrmTableItem[ReqSets];
                        try
                        {
                            brmItems = (FedmBrmTableItem[])reader.GetTable(FedmIscReaderConst.BRM_TABLE);
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        
                        if (brmItems != null)
                        {
                            string[] serialnumber = new string[brmItems.Length];
                            string[] dataBlock = new string[brmItems.Length];
                            string[] timer = new string[brmItems.Length];
                            string[] date = new string[brmItems.Length];
                            byte[] type = new byte[brmItems.Length];
                            byte[] antennaNr = new byte[brmItems.Length];
                            byte[] input = new byte[brmItems.Length];
                            byte[] state = new byte[brmItems.Length];
                            Dictionary<byte, FedmIscRssiItem>[] dicRSSI = new Dictionary<byte, FedmIscRssiItem>[brmItems.Length];

                            byte[] dbsize = new byte[brmItems.Length];

                            string db;
                            int i;

                            for (i = 0; i < brmItems.Length; i++)
                            {
                                // Serial Number
                                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_SNR))
                                {
                                    brmItems[i].GetData(FedmIscReaderConst.DATA_SNR, out serialnumber[i]);
                                }

                                // Data Blocks
                                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_RxDB))
                                {
                                    for (int cnt = 0; cnt < brmItems[i].GetBlockCount(); cnt++)
                                    {
                                        // Note: request of [0x21] Read Buffer contains a valid block address
                                        // while request of [0x22] Read Buffer has no block address
                                        // If you need no compatibility with ID ISC.LR200 you should remove 
                                        // the term '+ brmItems[i].GetBlockAddress()' (returns always 0)
                                        brmItems[i].GetData(FedmIscReaderConst.DATA_RxDB, cnt + brmItems[i].GetBlockAddress(), out db);
                                        dataBlock[i] = dataBlock[i] + db + "\r\n" + "\t\t";
                                    }
                                }

                                // Transponder Type
                                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_TRTYPE))
                                {
                                    brmItems[i].GetData(FedmIscReaderConst.DATA_TRTYPE, out type[i]);
                                }

                                // Time
                                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_TIMER))
                                {
                                    timer[i] = brmItems[i].GetReaderTime().GetTime();

                                }

                                // Date
                                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_DATE))
                                {
                                    date[i] = brmItems[i].GetReaderTime().GetDate();
                                }

                                // Ant Nr.
                                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_ANT_NR))
                                {
                                    brmItems[i].GetData(FedmIscReaderConst.DATA_ANT_NR, out antennaNr[i]);
                                }

                                // RSSI value
                                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_ANT_RSSI))
                                {
                                    dicRSSI[i] = brmItems[i].GetRSSI();
                                }
                                else
                                {
                                    dicRSSI[i] = new Dictionary<byte, FedmIscRssiItem>();
                                }

                                // Input + State
                                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_INPUT))
                                {
                                    brmItems[i].GetData(FedmIscReaderConst.DATA_INPUT, out input[i]);
                                    brmItems[i].GetData(FedmIscReaderConst.DATA_STATE, out state[i]);
                                }
                            }

                            obj[0] = brmItems.Length;
                            obj[1] = type;
                            obj[2] = serialnumber;
                            obj[3] = dataBlock;
                            obj[4] = timer;
                            obj[5] = date;
                            obj[6] = antennaNr;
                            obj[7] = dicRSSI;
                            obj[8] = input;
                            obj[9] = state;


                            result = (IAsyncResult)Invoke(DisplayRecSetMethod, obj);
                            ClearBuffer();
                        }
                        else
                        {
                            //If not data in Table don't show this in ListView
                            result = (IAsyncResult)Invoke(TextBoxDataClearMethod);
                            EndInvoke(result);
                        }

                    }
                    else
                    {
                        //If Reader no support command 0x22
                        if ((status == 0x80) || (status == 0x81) || (status == 0x82))
                        {
                            result = (IAsyncResult)Invoke(ReaderDisconnectMethod);
                            EndInvoke(result);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                  
            }
            
        }
        /*********ENDE*****************/

        /************Methods***********/
        public void ClearBuffer()
        {
            try
            {
                reader.SendProtocol(0x32);
            }
            catch (FePortDriverException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void InitBuffer()
        {
            try
            {
                // initialize Buffered Read Mode
                reader.SendProtocol(0x33);
            }
            catch (FePortDriverException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (FeReaderDriverException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        /*************ENDE*************/

        /****************************************Interface events**********************/
        //show the last line in textbox
        private void textBoxProtocol_TextChanged(object sender, EventArgs e)
        {
            this.textBoxProtocol.SelectionStart = this.textBoxProtocol.Text.Length;
            this.textBoxProtocol.SelectionLength = this.textBoxProtocol.Text.Length;
            this.textBoxProtocol.ScrollToCaret();
            this.textBoxProtocol.Refresh();
        }

        private void BRMSample_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
            reader.RemoveEventListener(this, FeIscListenerConst.RECEIVE_STRING_EVENT);
            reader.RemoveEventListener(this, FeIscListenerConst.SEND_STRING_EVENT);
            config.Close();
        }

        /**************************************ENDE***********************************/
    }
}