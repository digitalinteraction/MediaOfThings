using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OBID;

namespace NotificationSample
{
    public partial class NotificationSample : Form,FedmTaskListener
    {
        FedmIscReader reader;
	    FedmTaskOption taskOpt;
        long count=1; 

         //declaration from delegatetyp
        public delegate void DelegateDisplayRecSets(int recSets,
                                                    byte[] type,
                                                    string[] serialNumber,
                                                    string[] dataBlock,
                                                    string[] date,
                                                    string[] time,
                                                    byte[] antennaNr,
                                                    Dictionary<byte, FedmIscRssiItem>[] dicRSSI,
                                                    byte[] input,
                                                    byte[] state,
                                                    string ip);
        
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NotificationSample());
        }
        
        //Constructor
        public  NotificationSample()
        {
            InitializeComponent();
            try
            {
			    reader = new FedmIscReader();
			    reader.SetTableSize(FedmIscReaderConst.BRM_TABLE, 255); // max 255 tag with each notification
			    taskOpt = new FedmTaskOption();
            }
		    catch(FedmException ex)
            {
                MessageBox.Show(ex.ToString()); 
                return;
		    }
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
                if (d.Month.ToString().Trim().Length == 1)
                {
                    t = "0" + d.Month.ToString().Trim() + "/";
                }
                else
                {
                    t = d.Month.ToString().Trim() + "/";
                }
                if (d.Day.ToString().Trim().Length == 1)
                {
                    t += "0" + d.Day.ToString().Trim() + "/";
                }
                else
                {
                    t += d.Day.ToString().Trim() + "/";
                }
                t += d.Year.ToString().Trim() + " ";

                // Get the time
                if (d.Hour.ToString().Trim().Length == 1)
                {
                    t += "0" + d.Hour.ToString().Trim() + ":";
                }
                else
                {
                    t += d.Hour.ToString().Trim() + ":";
                }
                if (d.Minute.ToString().Trim().Length == 1)
                {
                    t += "0" + d.Minute.ToString().Trim() + ":";
                }
                else
                {
                    t += d.Minute.ToString().Trim() + ":";
                }
                if (d.Second.ToString().Trim().Length == 1)
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

        /*****************************Methods from interface FedmTaskListener*******************/
        public void OnNewNotification(int iError,string IP,uint PortNr) 
        {
	        int i;
	        FedmBrmTableItem[] brmItems;
            brmItems = (FedmBrmTableItem[])reader.GetTable(FedmIscReaderConst.BRM_TABLE);

            //declaration from delegateobject 
            DelegateDisplayRecSets DisplayRecSetMethod = new DelegateDisplayRecSets(DisplayRecSets);

        	object[] obj = new object[11];
	        IAsyncResult result; 

	        if(brmItems == null)
            {
                return;
            }
	        string[] serialnumber = new string[brmItems.Length];
            string[] dataBlock = new string[brmItems.Length];
            string[] date = new string[brmItems.Length];
            string[] time = new string[brmItems.Length];
            byte[] type = new byte[brmItems.Length];
            byte[] antennaNr = new byte[brmItems.Length];
            byte[] input = new byte[brmItems.Length];
            byte[] state = new byte[brmItems.Length];
            byte[] dbsize = new byte[brmItems.Length];
            Dictionary<byte, FedmIscRssiItem>[] dicRSSI = new Dictionary<byte, FedmIscRssiItem>[brmItems.Length];

            long dbn;
            byte dbadr;
            string db;
            
            for (i = 0; i < brmItems.Length; i++)
            {   // serial number
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_SNR))
                {
                    brmItems[i].GetData(FedmIscReaderConst.DATA_SNR, out serialnumber[i]);
                }
                // data blocks
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_RxDB))
                {
                    brmItems[i].GetData(FedmIscReaderConst.DATA_DBN, out dbn);
                    brmItems[i].GetData(FedmIscReaderConst.DATA_DB_ADR, out dbadr);
                    int j;
                    for (j = dbadr; j < dbn; j++)
                    {
                        brmItems[i].GetData(FedmIscReaderConst.DATA_RxDB, j, out db);
                        dataBlock[i] = dataBlock[i] + db + "\r\n"+"\t\t";
                    }
                }
                // Transponder Type
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_TRTYPE))
                {
                    brmItems[i].GetData(FedmIscReaderConst.DATA_TRTYPE, out type[i]);
                }
                // Date
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_DATE))
                {
                    date[i] = brmItems[i].GetReaderTime().GetDate();
                }

                // Time
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_TIMER))
                {
                    time[i] = brmItems[i].GetReaderTime().GetTime();
                }

                // Antenna number
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
                // Input
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
            obj[4] = date;
            obj[5] = time;
            obj[6] = antennaNr;
            obj[7] = dicRSSI;
            obj[8] = input;
            obj[9] = state;
            obj[10] = IP;

            result = (IAsyncResult)Invoke(DisplayRecSetMethod, obj);
           
        }

        public void OnNewApduResponse(int iError)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void OnNewQueueResponse(int iError)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void OnNewSAMResponse(int iError, byte[] responseData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

	    public void OnNewReaderDiagnostic(int iError,string IP,uint PortNr) 
        {
		   
        }

        public int OnNewMaxAccessEvent(int iError, string maxEvent, string ip, uint portNr)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int OnNewMaxKeepAliveEvent(int iError, uint uiErrorFlags, uint TableSize, uint uiTableLength, string ip, uint portNr)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void OnNewTag(int iError)
        {

        }

        public void onNewPeopleCounterEvent(uint counter1, uint counter2, uint counter3, uint counter4, string ip, uint portNr, uint busAddress)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /************************************ENDE***********************************************/
        
        /******************************************************Asynchrone method*****************************************************************************************************/
        public void DisplayRecSets( int recSets,
                                    byte[] type,
                                    string[] serialNumber,
                                    string[] dataBlock,
                                    string[] date,
                                    string[] time,
                                    byte[] antennaNr,
                                    Dictionary<byte, FedmIscRssiItem>[] dicRSSI,
                                    byte[] input,
                                    byte[] state,
                                    string ip)
		{
            Dictionary<byte, FedmIscRssiItem> RSSIval;
            FedmIscRssiItem RSSIitem;
            int i;
            bool bcheck;
            byte antNo;
            string dr;
            string tr = "";

            FedmBrmTableItem[] brmItems;
            brmItems = (FedmBrmTableItem[])reader.GetTable(FedmIscReaderConst.BRM_TABLE);

            tr += "-----------------------------------------------------------------" + "\r\n";
            tr += "DATE/TIME: " + Time.ToString() + "\r\n";
            tr += "-----------------------------------------------------------------" + "\r\n";
            count = 1;
            for (i = 0; i < recSets; i++)
            {
                tr += (count).ToString().Trim() + "." + "   TRANSPONDER" + "\r\n";
                count = count + 1;
                if (type[i] >= 0)
                {
                    //just the two last bit
                    dr = "0x" + FeHexConvert.IntegerToHexString(type[i]).Substring(FeHexConvert.IntegerToHexString(type[i]).Length - 2, 2);
                    tr += "TR-TYPE:" + "\t" + dr.ToString() + "\r\n";
                }

                // Output SeriaNo.
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_SNR))
                {
                    if (serialNumber[i] != null)
                    {
                        tr += "SNR:" + "\t\t" + serialNumber[i].ToString() + "\r\n";
                    }
                }
                // Output Data Blocks
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_RxDB))
                {
                    if (dataBlock[i] != null)
                    {
                        tr += "DB:" + "\t\t" + dataBlock[i].ToString() + "\r\n";
                    }
                }

                // Output Date
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_TIMER) || brmItems[i].IsDataValid(FedmIscReaderConst.DATA_DATE))
                {
                    if (date[i] != null)
                    {
                        tr += "DATE:" + "\t\t" + date[i].ToString() + "\r\n";
                    }
                }

                // Output Time
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_TIMER))
                {
                    if (time[i] != null)
                    {
                        tr += "TIME:" + "\t\t" + time[i].ToString() + "\r\n";
                    }
                }

                // It is possible either to output the ANT_NR or the RSSI value (this is also important for the reader config!)
                // Output ANT_NR
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_ANT_NR))
                {
                    tr += "ANT. NR:"+"\t\t" + (antennaNr[i].ToString()).Trim() + "\r\n";    
                }

                // It is possible either to output the ANT_NR or the RSSI value (this is also important for the reader config!) 
                // Output RSSI
                if (dicRSSI.Length > 0)
                {
                    if (dicRSSI[i] != null)
                    {
                        RSSIval = dicRSSI[i];
                        for(antNo = 1; antNo<FedmBrmTableItem.TABLE_MAX_ANTENNA; antNo++)
                        {
                            bcheck = RSSIval.TryGetValue(antNo, out RSSIitem);
                            if (!bcheck)
                                continue;
                           
                            tr += "RSSI of AntNr. " + "\t" + antNo.ToString() + " is " + "-" + RSSIitem.RSSI.ToString() + "dBm" + "\r\n";
                        }
                    }
                }

                // Output INPUT
                if (brmItems[i].IsDataValid(FedmIscReaderConst.DATA_INPUT))
                {
                    tr += "INPUT:" + "\t\t" + (input[i].ToString()).Trim() + "\r\n";
                    tr += "STATE:" + "\t\t" + (state[i].ToString()).Trim() + "\r\n";
                }
                
                // Output IP where notification data comes from 
                tr += "FROM:" + "\t\t" + ip + "\r\n";
                tr += "" + "\r\n";
                tr += "" + "\r\n";
            }
                this.textBoxData.AppendText(tr); 
                tr = "";
       }
        /**********************************************************ENDE***************************************************************************************************************/
       
        /**************************************************Buttons**********************************************/
        private void buttonListen_Click(object sender, EventArgs e)
        {
            
            if(this.buttonListen.Text == "Listen")
            {
                
                this.buttonListen.Text = "Cancel";
                
			    taskOpt.IPPort = Convert.ToInt16(this.textBoxPortNr.Text);
			    if(this.checkBoxAkn.Checked)
                {
				    taskOpt.NotifyWithAck = 1;
                }
			    else
                {
				    taskOpt.NotifyWithAck = 0;
			    }
                //Start from intern Thread
                try
                {
                   reader.StartAsyncTask(FedmTaskOption.ID_NOTIFICATION, this, taskOpt);
                }
                catch (FeReaderDriverException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
		    else
            {
                this.buttonListen.Text = "Listen";
                //End from intern thread
                int val;
                reader.ResetTable(FedmIscReaderConst.BRM_TABLE);
                val=reader.CancelAsyncTask(); 
                //case Deadlocks ->-4084
                if (val < 0)
                {
                   reader.CancelAsyncTask();
                }
                
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.textBoxData.Clear();
            count = 1;
        }
        /***********************************************************Ende******************************************/

        private void NotificationSample_FormClosing(object sender, FormClosingEventArgs e)
        {
            reader.CancelAsyncTask();
            Application.Exit();
        }

    }
}