using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using OBID;

namespace ISOHostSample
{
    public partial class ISOHostSample : Form, FeIscListener
    {
        
        PortConnection config ;
        FedmIscReader fedm;
        AuthentMifare authmifare_config;
        AuthentMYD authmyd_config;
        bool running ;
        bool uhfTransponder = false;
        string serialNumber;
        byte SerialNumberLen;
        int BnkIdx;
        uint persistenceResetTime = 0;

        
        //declaration from delegatetyp
        public delegate void DelegateTagChanged(string[] serialNumber, byte[] tagType);
        public delegate void DelegateLastError(string err);
        public delegate void DelegateNoTag(int readerStatus);
        public delegate void DelegateOnSendProtocol(string sendprotocol);
        public delegate void DelegateOnReceiveProtocol(string receiveprotocol);
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ISOHostSample());
        
        }

        public ISOHostSample()
        {
            try
            {
                fedm = new FedmIscReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Error");
            }
            
            //declaration from Thread
            Thread MyThread = new Thread(new ThreadStart(ReadThread));
            
            fedm.SetTableSize(FedmIscReaderConst.ISO_TABLE, 128);

            config = new PortConnection();
            config.PortConfig(ref fedm);
            DialogResult reponse = config.ShowDialog();
           

            if (fedm.Connected == true)
            {
                try
                {
                    fedm.ReadCompleteConfiguration(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "Error");
                }
                // set Persistence Reset Time in Reader Configuration to zero
                // this speeds up inventory cycles
                int back = OBID.Fedm.ERROR_UNSUPPORTED_NAMESPACE;
                try
                {
                    back =fedm.TestConfigPara(OBID.ReaderConfig.Transponder.PersistenceReset.Antenna.No1.PersistenceResetTime);
                }
                catch(Exception ex)
                { // ignore Exception
                }
                // if reader supports this parameter, set it !
                if (0 == back)
                {
                    try
                    {
                        back = fedm.GetConfigPara(OBID.ReaderConfig.Transponder.PersistenceReset.Antenna.No1.PersistenceResetTime, out persistenceResetTime, false);
                        back = fedm.SetConfigPara(OBID.ReaderConfig.Transponder.PersistenceReset.Antenna.No1.PersistenceResetTime, (uint)0, false);
                        if (back == 1) // return value 1 indicates modified parameter
                            back = fedm.ApplyConfiguration(false);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(this, ex.ToString(), "Error");
                    }
                }
            }

            // Init Dialogs Authent 
            authmifare_config = new AuthentMifare(this.fedm);
            authmyd_config = new AuthentMYD(this.fedm);

            if (fedm.Connected == true && reponse == DialogResult.Cancel)
            {
                InitializeComponent();

                //set read Mode
                this.comboBoxMod.SelectedIndex = 1;

                //set bank for UHF
                this.comboBoxBank.SelectedIndex = 3;
                this.comboBoxBank.Enabled = false;

                // set blockSize
                this.numericUpDownDBS.Minimum = 1;
                this.numericUpDownDBS.Maximum = 256;
                this.numericUpDownDBS.Increment = 1;
                this.numericUpDownDBS.Value = 4;

                // set the number of blocks
                this.numericUpDownDBN.Minimum = 1;
                this.numericUpDownDBN.Maximum = 256;
                this.numericUpDownDBN.Increment = 1;
                this.numericUpDownDBN.Value = 1;

                // set status of Authent Buttons
                this.button_Authent_myd.Enabled = false;
                this.button_AuthentMifare.Enabled = false;

                this.checkBoxEnable.Checked = true;

                //Registry from Events send and receive
                fedm.AddEventListener(this, FeIscListenerConst.SEND_STRING_EVENT);
                fedm.AddEventListener(this, FeIscListenerConst.RECEIVE_STRING_EVENT);

                //Init from  TextEditor
                HexEdit.SetSize(128, 4, BnkIdx);

                //Thread starten in Background
                running = false;
                MyThread.IsBackground = true;
                MyThread.Start();
            }
            else 
            {
                config.ShowDialog();
            }
            
                      
        }

        private void ISOSample_FormClosing(object sender, FormClosingEventArgs e)
        {
            // stop reading
            running = false;

            //remove Events 
            fedm.RemoveEventListener(this, FeIscListenerConst.SEND_STRING_EVENT);
            fedm.RemoveEventListener(this, FeIscListenerConst.RECEIVE_STRING_EVENT);

            if (fedm.Connected == true)
            {
                // set Persistence Reset Time in Reader Configuration back to old value
                int back = OBID.Fedm.ERROR_UNSUPPORTED_NAMESPACE;
                try
                {
                    back = fedm.TestConfigPara(OBID.ReaderConfig.Transponder.PersistenceReset.Antenna.No1.PersistenceResetTime);
                }
                catch (Exception ex)
                { // ignore Exception
                }
                // if reader supports this parameter, set it back to old value !
                if (0 == back)
                {
                    try
                    {
                        back = fedm.SetConfigPara(OBID.ReaderConfig.Transponder.PersistenceReset.Antenna.No1.PersistenceResetTime, persistenceResetTime, false);
                        if (back == 1) // return value 1 indicates modified parameter
                            back = fedm.ApplyConfiguration(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.ToString(), "Error");
                    }
                }
            }

            // close port
            config.Close();
        }

/******************************Buttons************************************************/
   
        private void buttonRun_Click(object sender, EventArgs e)
        {
            
            if (this.buttonRun.Text == "R&un")
            {
                running                     = true;
                this.buttonRead.Enabled     = false;
                this.buttonWrite.Enabled    = false;
                this.buttonRun.Text         = "Sto&p";
            }
            else
            {
                this.buttonRead.Enabled     = true;
                this.buttonWrite.Enabled    = true;
                this.buttonRun.Text         = "R&un";
                running                     = false;
            }
            
        }

        private void buttonClearList_Click(object sender, EventArgs e)
        {
            this.listBoxTags.Items.Clear();
            // Authent Buttons disable again
            this.button_AuthentMifare.Enabled = false;
            this.button_Authent_myd.Enabled = false;
        }

        private void buttonProtClear_Click(object sender, EventArgs e)
        {
            this.textBoxProtocol.Text = "";
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            byte[] data;
            byte blockSize;
            int idx;
            int dbn;
            int address;
            int mode;
            int bankidx;
            long datalocation = FedmIscReaderConst.DATA_RxDB;
            
            mode = this.comboBoxMod.SelectedIndex;
             
            int selRow;
            selRow = this.listBoxTags.SelectedIndex;

            if (selRow == -1 && mode > 0)
            {
                 
                 MessageBox.Show(this, "There was no tag selected.", "Error");
                 return;
            }

            // set IscTable-Parameter
            dbn = (int)this.numericUpDownDBN.Value;
            address = (int)this.numericUpDownAdr.Value;

            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, (byte)0);
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_UID, serialNumber);
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_CMD, 0x23);
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DBN, dbn);
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_ADR, mode);

            //if uhfTransponder is found 
            if (uhfTransponder == true)
            {
            
                if (mode == 2)
                {
                    MessageBox.Show(this, "UHF Transponder cannot be read in mode selected mode." , "Error");
                    return;
                }

                bankidx = this.comboBoxBank.SelectedIndex;

                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_UID_LF, true);
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_EXT_ADR, true);
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_UID_LEN, SerialNumberLen);
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_BANK, (byte)0);
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_BANK_BANK_NR, bankidx);
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_ACCESS_PW_LENGTH, (byte)0);
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DB_ADR_EXT, address);
            }
            
            
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DB_ADR, address);
            

            // Send ReadMultipleBlocks-Protocol
            try
            {
                fedm.SendProtocol(0xB0);
            }

            catch (System.Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Error");
                return;
            }

            switch (mode)
            {
                case 0:
                 idx = 0;
                 break;
                case 1:
                 idx = fedm.FindTableIndex(0, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_SNR, serialNumber);
                 break;
                case 2:
                 idx = fedm.FindTableIndex(0, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_IS_SELECTED, true);
                 break;
                default:
                 return;
            }

            // get blockSize from ISC-table, default = 4
            FedmIsoTableItem item;

            try
            {
                item = (FedmIsoTableItem)fedm.GetTableItem(idx, FedmIscReaderConst.ISO_TABLE);
                item.GetData((FedmIscReaderConst.DATA_BLOCK_SIZE), out blockSize);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Error");
                return;
            }

            if (blockSize == 0)
            {
                blockSize = 4; // default value
            }

            //set current blockSize
            this.numericUpDownDBS.Value = blockSize;

            //Set DataBlockData from ResponseBuffer to HexEdit
            int i;

            for (i = 0; i < dbn; i++)
            {
                if (uhfTransponder == true)
                {
                    bankidx = this.comboBoxBank.SelectedIndex;
                    switch(bankidx)
                    {
                        case 0:
                            datalocation = FedmIscReaderConst.DATA_RxDB_RES_BANK;
                            break;
                        case 1:
                            datalocation = FedmIscReaderConst.DATA_RxDB_EPC_BANK;
                            break;
                        case 2:
                            datalocation = FedmIscReaderConst.DATA_RxDB_TID_BANK;
                            break;
                        case 3:
                            datalocation = FedmIscReaderConst.DATA_RxDB;
                            break;
                        default:
                            break;
                    }
                }
                item.GetData(datalocation, address + i, out data);
                HexEdit.InsertData((address + i) * blockSize, data);
            }
    }
       
        private void buttonWrite_Click(object sender, EventArgs e)
        {
            byte[]data; 
            int blockSize;
            int dbn;
            int address;
            int idx;
            int mode;
            long datalocation = FedmIscReaderConst.DATA_TxDB;
            int bankidx;
            int iBack = 0;
            

            mode = this.comboBoxMod.SelectedIndex;
                  
            int selRow;
            selRow = this.listBoxTags.SelectedIndex;

            if (selRow == -1 && mode > 0)
            {
                MessageBox.Show(this, "There was no tag selected.", "Error");
                return;
            }
          
            // set IscTable-Parameter
            dbn         = (int)this.numericUpDownDBN.Value;
            address     = (int)this.numericUpDownAdr.Value;
            blockSize   = (int)this.numericUpDownDBS.Value;

            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_CMD, 0x24); // write multiple blocks
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DBN, dbn);
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DB_ADR, address);
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, mode);
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_UID, serialNumber);
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DB_SIZE, blockSize);
            //if uhfTransponder is found 
            if (uhfTransponder == true)
            {
                bankidx = this.comboBoxBank.SelectedIndex;
                iBack = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_UID_LF, true);
                iBack = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_EXT_ADR, true);
                iBack = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_UID_LEN, SerialNumberLen);
                iBack = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_BANK, (byte)0);
                iBack = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_BANK_BANK_NR, bankidx);
                iBack = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_ACCESS_PW_LENGTH, (byte)0);
                iBack = fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_DB_ADR_EXT, address);

                //fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_BANK_ACCESS_FLAG, (bool)true);
                //fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_ACCESS_PW_LENGTH, (byte)4);
                //fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_ACCESS_PW, "11112222");
            }
                     
            switch(mode)
            {
                 case 0:
                    idx = 0;
                    break;
                 case 1:
                    idx = fedm.FindTableIndex(0, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_SNR, serialNumber);
                     break;
                case 2:
                    idx = fedm.FindTableIndex(0, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_IS_SELECTED, true);
                     break;
                default:
                    return;
             }
            
            FedmTableItem item;
            try
            {
                item = fedm.GetTableItem(idx, FedmIscReaderConst.ISO_TABLE);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Error");
                return;
            }

            item.SetData(FedmIscReaderConst.DATA_BLOCK_SIZE, blockSize);
            
            int i;

            for(i = address; i<= address + (dbn - 1); i++)
            {
                data = HexEdit.GetData(i, blockSize);
                
                
                //for uhftransponder
                if (uhfTransponder == true)
                {
                    bankidx = this.comboBoxBank.SelectedIndex;
                    switch (bankidx)
                    {
                        case 0:
                            datalocation = FedmIscReaderConst.DATA_TxDB_RES_BANK;
                            break;
                        case 1:
                            datalocation = FedmIscReaderConst.DATA_TxDB_EPC_BANK;
                            break;
                        case 2:
                            datalocation = FedmIscReaderConst.DATA_TxDB_TID_BANK;
                            break;
                        case 3:
                            datalocation = FedmIscReaderConst.DATA_TxDB;
                            break;
                        default:
                            break;
                    }
                }
                item.SetData(datalocation, i, data);
            }

            try
            {
                iBack = fedm.SetTableItem(idx, item);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Error");
                return;
            }

            //Send WriteMultipleBlocks-Protocol
            try
            {
                iBack = fedm.SendProtocol(0xB0);
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Error");
                return;
            }

       }
        
        private void buttonClearB_Click(object sender, EventArgs e)
        {
            HexEdit.HexEditClean(128, (int)this.numericUpDownDBS.Value, BnkIdx);
        }

/*********************************END*************************************************/

/*********************************GUI_EVENTS***********************************************/
        private void numericUpDownDBS_ValueChanged(object sender, EventArgs e)
        {
           HexEdit.SetSize(HexEdit.RowCount, (int)this.numericUpDownDBS.Value, BnkIdx);
        }

        private void checkBoxEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxEnable.Checked == false)
            {
                this.textBoxProtocol.Text = "";
                this.textBoxProtocol.Enabled = false;
            }
            else
            {
                this.textBoxProtocol.Enabled = true;
            }
        }

        private void listBoxTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selRow;
            int mode;
            byte bTagType;

           
            selRow = this.listBoxTags.SelectedIndex;
            if (selRow == -1)
            {
                MessageBox.Show(this, "There was no tag selected.", "Error");
                return;
            }
            else
            {   // get Tag Type
                fedm.GetTableData(selRow, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_TRTYPE, out bTagType);

                // control enable check for UHF controls
                if (uhfTransponder == true)
                {
                    this.comboBoxBank.Enabled = true;
                }
                else
                { 
                    this.comboBoxBank.Enabled = false; 
                }
                
                // control enable check for ISO14443 controls
                if (bTagType == FedmIscReaderConst.TR_TYPE_ISO14443A ||
                    bTagType == FedmIscReaderConst.TR_TYPE_ISO14443B)
                {
                    this.button_Authent_myd.Enabled = true;
                    this.button_AuthentMifare.Enabled = true;
                    // for ISO14443 tags mode is fixed -> selected
                    mode = FedmIscReaderConst.ISO_MODE_SEL;
                    this.comboBoxMod.SelectedIndex = FedmIscReaderConst.ISO_MODE_SEL;
                }
                else if (bTagType == FedmIscReaderConst.TR_TYPE_ISO15693)
                {
                    this.button_Authent_myd.Enabled = true;
                    this.button_AuthentMifare.Enabled = false;
                    // get Mode from comboBox (non-addr, addr, selected)
                    mode = this.comboBoxMod.SelectedIndex;
                }
                else
                {
                    this.button_Authent_myd.Enabled = false;
                    this.button_AuthentMifare.Enabled = false;
                    // get Mode from comboBox (non-addr, addr, selected)
                    mode = this.comboBoxMod.SelectedIndex;
                }

                serialNumber = this.listBoxTags.SelectedItem.ToString();
                SerialNumberLen = Convert.ToByte(serialNumber.Length / 2);
                try
                {
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_REQ_UID, serialNumber); // prepare for 0xB0 command
                    if (bTagType == FedmIscReaderConst.TR_TYPE_ISO14443A ||
                    bTagType == FedmIscReaderConst.TR_TYPE_ISO14443B)
                    {
                        fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_UID, serialNumber); // prepare for 0xB2 command
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "Error");
                    return;
                }
                if (mode == 2)//selected
                {
                   try
                    {
                        fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, 0x01);  // Mode: addressed
                        fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_CMD, 0x25);   // Select Command
                    
                        fedm.SendProtocol(0xB0);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(this, ex.ToString(), "Error");
                        return;
                    }

                }
                else 
                {
                    return;
                }
          }
        }

        private void comboBoxBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            BnkIdx = (int)this.comboBoxBank.SelectedIndex;
            HexEdit.SetSize(HexEdit.RowCount, (int)this.numericUpDownDBS.Value, BnkIdx);
        }

        //ever show the last line from textbox
        private void textBoxProtocol_TextChanged(object sender, EventArgs e)
        {
            this.textBoxProtocol.SelectionStart = this.textBoxProtocol.Text.Length;
            this.textBoxProtocol.SelectionLength = this.textBoxProtocol.Text.Length;
            this.textBoxProtocol.ScrollToCaret();
            this.textBoxProtocol.Refresh();
        }

/**************************************END************************************************/   

/*********************************Methode from interface FeIscListener**********************************************/
        
        public void OnReceiveProtocol(FedmIscReader reader, byte[] receiveProtocol)
        {
        }

        public void OnReceiveProtocol(FedmIscReader reader, String receiveProtocol)
        {
            IAsyncResult result;
            DelegateOnReceiveProtocol ReceiveProtocolMethod = new DelegateOnReceiveProtocol(DisplayReceiveProtocol);
            result = (IAsyncResult)Invoke(ReceiveProtocolMethod, receiveProtocol);
            
        }

        public void OnSendProtocol(FedmIscReader reader, byte[] sendProtocol)
        {
        }

        public void OnSendProtocol(FedmIscReader reader, String sendProtocol)
        {
           IAsyncResult result;
           DelegateOnSendProtocol SendProtocolMethod = new DelegateOnSendProtocol(DisplaySendProtocol);
           result = (IAsyncResult)Invoke(SendProtocolMethod, sendProtocol);
        }

/************************************************************END********************************************************/

/******************** Methode to show protocol*****************************/
        
        //show sent Protocol
        public void DisplaySendProtocol(string protocol)
        {
            if (this.checkBoxEnable.Checked)
            {
                this.textBoxProtocol.Text += protocol;
            }
        }

        //show received protocol
        public void DisplayReceiveProtocol(string protocol)
        {
            if (this.checkBoxEnable.Checked)
            {
                this.textBoxProtocol.Text += protocol;
            }
        }

/********************************END****************************************/
 
/*******************Methode to show asynchrone Result in GUI****************/
        
        //Show message error                                                      
        public void LastError(string err)
        {                                                                        
            this.buttonRun.Text = "R&un";                                            
            MessageBox.Show(this, err, "Error");                                
        }

        //Clear tag list
        public void ClearList(int readerStatus)
        {
            this.listBoxTags.Items.Clear();
            // disable Authent Buttons
            this.button_AuthentMifare.Enabled = false;
            this.button_Authent_myd.Enabled = false;
        }                                                                        
                                                                                 
        //Show multiple TranspondersID                                           
        public void TagChanged(string[] serialNumber, byte[] tagType)
        {
            int i;

            if (running)
            {
                this.listBoxTags.Items.Clear();
                for (i = 0; i < serialNumber.Length; i++)
                {
                   
                    if (this.listBoxTags.Items.Contains(serialNumber[i]))
                    {
                    }
                    else
                    {
                        this.listBoxTags.Items.Add(serialNumber[i]);
                    }
                }
            }
        }                         

/****************************************END*********************************/

        // methode to execute the thread 
        public void ReadThread()
        {
            int readerStatus = 0;
            string[] serialNumber;
            byte[] tagType;
           
            //declaration from delegateobject 
            DelegateTagChanged  TagChangedMethod    = new DelegateTagChanged(TagChanged);
            DelegateLastError LastErrorMethod = new DelegateLastError(LastError);
            DelegateNoTag NoTagMethod = new DelegateNoTag(ClearList);
            
            object[] obj1 = new object[2];
            object obj2 = null;
            IAsyncResult result;

            while (true)
            {
                if (running == true)
                {
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_CMD, 0x01);
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, 0x00);
                    try
                    {
                        fedm.ResetTable(FedmIscReaderConst.ISO_TABLE);
                        fedm.SendProtocol(0x69); // RFReset
                        readerStatus = fedm.SendProtocol(0xB0); // ISOCmd
                        if (readerStatus != 0 && readerStatus != 0x94)
                        {
                            obj2 = readerStatus;
                            result = BeginInvoke(NoTagMethod, obj2);
                            EndInvoke(result);
                            continue;
                        }

                        while (fedm.GetLastStatus() == 0x94) // more flag set?
                        {
                            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_MORE, 0x01);
                            fedm.SendProtocol(0xB0);
                        }
                        //new dimensiion from array serialNumber,tagtype,SeNumbLength
                        serialNumber = new string[fedm.GetTableLength(FedmIscReaderConst.ISO_TABLE)];
                        tagType      = new byte[fedm.GetTableLength(FedmIscReaderConst.ISO_TABLE)];

                        if (fedm.GetTableLength(FedmIscReaderConst.ISO_TABLE) <= 0)
                            continue;
                        
                        int i;
                        for (i = 0; i < fedm.GetTableLength(FedmIscReaderConst.ISO_TABLE); i++)
                        {
                            fedm.GetTableData(i, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_SNR, out serialNumber[i]);
                            fedm.GetTableData(i, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_TRTYPE, out tagType[i]);
                            // check, wether UHF tags are available in list
                            if (tagType[i] >= 0x80 )
                            {
                                uhfTransponder = true;
                            }
                            else
                            {
                                uhfTransponder = false;
                            }

                        }
                        obj1[0] = serialNumber;
                       
                        //asynchrone result senden
                        result = BeginInvoke(TagChangedMethod, obj1);
                        EndInvoke(result);
                                             
                    }
                    catch (Exception ex)
                    {
                        obj2 = ex.ToString();
                        //asynchrone result senden
                        result = BeginInvoke(LastErrorMethod, obj2);
                        EndInvoke(result);
                        running = false;
                        uhfTransponder = false;

                    }
                }
            }
        }

       
/*******************Methode (Dialog) to show Authent my-d procedure****************/
        private void button_Authent_myd_Click(object sender, EventArgs e)
        {
            // open extra Dialog
            authmyd_config.setMode(comboBoxMod.SelectedIndex);
            DialogResult reponse = authmyd_config.ShowDialog();
        }

/*******************Methode (Dialog) to show Authent Mifare (ISO14443 Tags)****************/
        private void button_AuthentMifare_Click(object sender, EventArgs e)
        {
            // open extra Dialog
            DialogResult reponse = authmifare_config.ShowDialog();
        }

        private void HexEdit_Load(object sender, EventArgs e)
        {

        }
      
    }
}