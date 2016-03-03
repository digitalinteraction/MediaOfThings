using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OBID;

namespace APDUSample
{
    public partial class APDU_Sample : Form, FedmTaskListener
    {
        PortConnection config;
        FedmIscReader fedm;
        FedmCprApdu APDU_Prot;
        string serialNumber;
        byte SerialNumberLen;

        public delegate void DelegateOnReceiveAPDU(string sRespProtocol);
        
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new APDU_Sample());
        }

        public APDU_Sample()
        {
            try
            {
                fedm = new FedmIscReader();
                APDU_Prot = new FedmCprApdu(this);
                fedm.SetTableSize(FedmIscReaderConst.ISO_TABLE, 128);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Error");
            }



            config = new PortConnection();
            config.PortConfig(ref fedm);
            DialogResult reponse = config.ShowDialog();

            // Check Reader - Support of APDUs
            if (fedm.GetReaderType() == FedmIscReaderConst.TYPE_CPR02 ||
                fedm.GetReaderType() == FedmIscReaderConst.TYPE_CPR04_U ||
                fedm.GetReaderType() == FedmIscReaderConst.TYPE_CPR40_XX ||
                fedm.GetReaderType() == FedmIscReaderConst.TYPE_CPR40_XX_U ||
                fedm.GetReaderType() == FedmIscReaderConst.TYPE_CPR50_XX ||
                fedm.GetReaderType() == FedmIscReaderConst.TYPE_CPR52_XX ||
                fedm.GetReaderType() == FedmIscReaderConst.TYPE_CPR44_XX ||
                fedm.GetReaderType() == FedmIscReaderConst.TYPE_CPR30_XX ||
                fedm.GetReaderType() == FedmIscReaderConst.TYPE_CPRM02)
            {
            }
            else
            {
                MessageBox.Show(this, "Reader doesn't support APDU commands!", "Error");
            }

            InitializeComponent();
            // First send "Inventory" and select Tag before APDU Input
            this.button_sendAPDU.Enabled = false;
            this.maskedTextBox_APDU.Enabled = false;
        }

        private void OnButtonClick_Inventory(object sender, EventArgs e)
        {
            int iBack = 0;
            string[] serialNumber;
            byte[] tagType;
            
            // prepare Inventory
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_CMD, 0x01);
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, 0x00);
            try
            {
                fedm.ResetTable(FedmIscReaderConst.ISO_TABLE);
                fedm.SendProtocol(0x69); // RFReset
                iBack = fedm.SendProtocol(0xB0); // ISOCmd
                if (iBack != 0 && iBack != 0x94)
                {
                    this.textBox_status_out.Clear();
                    this.textBox_status_out.AppendText(iBack.ToString());
                }
                while (fedm.GetLastStatus() == 0x94) // more flag set?
                {
                    fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_MORE, 0x01);
                    fedm.SendProtocol(0xB0);
                }
                //new dimensiion from array serialNumber,tagtype,SeNumbLength
                serialNumber = new string[fedm.GetTableLength(FedmIscReaderConst.ISO_TABLE)];
                tagType = new byte[fedm.GetTableLength(FedmIscReaderConst.ISO_TABLE)];

                if (fedm.GetTableLength(FedmIscReaderConst.ISO_TABLE) <= 0)
                    MessageBox.Show(this, "No Tag in Reader Field", "Warning" );

                int i;
                for (i = 0; i < fedm.GetTableLength(FedmIscReaderConst.ISO_TABLE); i++)
                {
                    fedm.GetTableData(i, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_SNR, out serialNumber[i]);
                    fedm.GetTableData(i, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_TRTYPE, out tagType[i]);
                }

                // Display Tags
                this.listBox_TagList.Items.Clear();
                for (i = 0; i < serialNumber.Length; i++)
                {

                    if (this.listBox_TagList.Items.Contains(serialNumber[i]))
                    {
                    }
                    else
                    {
                        this.listBox_TagList.Items.Add(serialNumber[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Error");
                return;
            }
        }

        private void OnButtonClick_Exit(object sender, EventArgs e)
        {
            Close();
        }

        private void OnButtonClick_SendAPDU(object sender, EventArgs e)
        {
            // Example: GetVersion(1)  -> APDUSendData = 60 
            // >>  02 00 0B FF B2 BE 83 00 60 16 59 
            // <<  02 00 13 00 B2 00 02 00 00 AF 04 01 01 01 00 1A 05 83 6B   OK  

            // Variables
            byte[] APDUSendData;
            string cProtocol;
            
            cProtocol = this.maskedTextBox_APDU.Text;
            if (cProtocol.Length == 0)
            {
                this.textBox_status_out.Clear();
                this.textBox_status_out.AppendText("No or to less data in Protocol! -> use data format: 112233....");
                return;
            }

            if(cProtocol.Length%2 != 0)
            {
                    this.textBox_status_out.Clear();
                    this.textBox_status_out.AppendText("Wrong protocol format or protocol length - Length must be even\nUse data format: 112233....)!)");
                    return;
            }
             
            APDUSendData = new byte[cProtocol.Length/2];

            APDUSendData = FeHexConvert.HexStringToByteArray(cProtocol);

            try
            {
                // Set APDU data
                APDU_Prot.SetApdu(APDUSendData);
                // send APDU
                fedm.SendTclApdu(APDU_Prot);
            }
            catch(Exception ex)
            {
                MessageBox.Show(this,ex.ToString(),"Error");
            }
        }

        private void listBox_TagList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selRow;
            int mode = 0;
            byte bTagType;

            selRow = this.listBox_TagList.SelectedIndex;
            if (selRow == -1)
            {
                this.textBox_status_out.Clear();
                this.textBox_status_out.AppendText("There was no tag selected.");
                return;
            }
            else
            {   // get Tag Type
                fedm.GetTableData(selRow, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_TRTYPE, out bTagType);

                // control enable check for ISO14443 controls
                if (bTagType == FedmIscReaderConst.TR_TYPE_ISO14443A ||
                    bTagType == FedmIscReaderConst.TR_TYPE_ISO14443B)
                {
                    // for ISO14443 tags mode is fixed -> selected
                    mode = 2;
                }

                serialNumber = this.listBox_TagList.SelectedItem.ToString();
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

                        // Enable APDU Input after select Tag !
                        this.button_sendAPDU.Enabled = true;
                        this.maskedTextBox_APDU.Enabled = true;
                        // Update Status Box
                        this.textBox_status_out.Clear();
                        this.textBox_status_out.AppendText("Tag selected !");
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(this, ex.ToString(), "Error");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show(this, "Wrong Tag !", "Error");
                    return;
                }
            }
        }

        private void maskedTextBox_APDU_TextChanged(object sender, EventArgs e)
        {
            // Variables
            string cProtocol;
            int currentpos;

            currentpos = this.maskedTextBox_APDU.TextLength;
            this.maskedTextBox_APDU.GetPositionFromCharIndex(currentpos);

            if (currentpos == 0)
            {
                return;
            }
            cProtocol = this.maskedTextBox_APDU.Text;

            if (cProtocol[currentpos - 1].Equals('A') || cProtocol[currentpos - 1].Equals('B') ||
                cProtocol[currentpos - 1].Equals('C') || cProtocol[currentpos - 1].Equals('D') ||
                cProtocol[currentpos - 1].Equals('E') || cProtocol[currentpos - 1].Equals('F') ||
                cProtocol[currentpos - 1].Equals('0') || cProtocol[currentpos - 1].Equals('1') ||
                cProtocol[currentpos - 1].Equals('2') || cProtocol[currentpos - 1].Equals('3') ||
                cProtocol[currentpos - 1].Equals('4') || cProtocol[currentpos - 1].Equals('5') ||
                cProtocol[currentpos - 1].Equals('6') || cProtocol[currentpos - 1].Equals('7') ||
                cProtocol[currentpos - 1].Equals('8') || cProtocol[currentpos - 1].Equals('9'))
            {
                return;
            }
            else if (cProtocol[currentpos - 1].Equals(null))
            {
                return;
            }
            else
            {
                MessageBox.Show(this, "No valid char!\nUse 0-9 and A-F !", "Error");
            }

        }


        private void button_rfreset_Click(object sender, EventArgs e)
        {
            this.textBox_status_out.Clear();
            this.textBox_status_out.AppendText("RF-Reset sent!");

            try
            {
                // Send [0x69] RF-Reset
                fedm.SendProtocol((byte)0x69);

                // First send "Inventory" and select Tag before APDU Input
                this.button_sendAPDU.Enabled = false;
                this.maskedTextBox_APDU.Enabled = false;
                this.listBox_TagList.Items.Clear();
            }
            catch (Exception ex)
            {
                this.textBox_status_out.Clear();
                this.textBox_status_out.AppendText("RF-Reset sent - Error!");
                MessageBox.Show(this, ex.ToString(), "Error");
                return;
            }
        }


        public void DisplayReceivedAPDU(string sRespProtocol)
        {
            this.textBox_status_out.Clear();
            this.textBox_status_out.Text += sRespProtocol;
        }

        /************************************Interface(FeIscListener) Methods*****************************/
        #region FedmTaskListener Member

        public void OnNewApduResponse(int iError)
        {
            byte[] APDURespData;
            string sRespProtocol = " ";

            if (iError == 0)
            {
                APDURespData = APDU_Prot.GetLastResponseData();
                sRespProtocol = FeHexConvert.ByteArrayToHexString(APDURespData);
            }

            IAsyncResult result;
            DelegateOnReceiveAPDU ReceiveAPDUMethod = new DelegateOnReceiveAPDU(DisplayReceivedAPDU);
            result = (IAsyncResult)Invoke(ReceiveAPDUMethod, sRespProtocol);
        }

        public void OnNewNotification(int iError, string ip, uint portNr)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void OnNewQueueResponse(int iError)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void OnNewReaderDiagnostic(int iError, string ip, uint portNr)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void OnNewSAMResponse(int iError, byte[] responseData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void OnNewTag(int iError)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        
        public int OnNewMaxAccessEvent(int iError, string maxEvent, string ip, uint portNr)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int OnNewMaxKeepAliveEvent(int iError, uint uiErrorFlags, uint TableSize, uint uiTableLength, string ip, uint portNr)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void onNewPeopleCounterEvent(uint counter1, uint counter2, uint counter3, uint counter4, string ip, uint portNr, uint busAddress)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        
        #endregion

    }
}