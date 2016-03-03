//TODO:
//  remove the comment from code line 217 after SetTimeout() is implemented in ISamCrypto 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OBID;
using OBID.TagHandler;
using System.IO.Ports;

namespace TagHandlerDemo_DESFire_C3
{
    public partial class Form_MainWindow : Form, FeIscListener
    {
        public FedmIscReader Reader;
        public string Uid;
        public FedmIscTagHandler_ISO14443_4_MIFARE_DESFire DESFire;

        public delegate void DelegateOnSendProtocol(string sendprotocol);
        public delegate void DelegateOnReceiveProtocol(string receiveprotocol);

        public Form_MainWindow()
        {
            InitializeComponent();
            try
            {
                Reader = new FedmIscReader();
                Reader.SetTableSize(FedmIscReaderConst.ISO_TABLE, 128);

                Reader.AddEventListener(this, FeIscListenerConst.SEND_STRING_EVENT);
                Reader.AddEventListener(this, FeIscListenerConst.RECEIVE_STRING_EVENT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Initialization Error");
            }
            radioButton_C1USB.Checked = true;
            comboBox_COMPort.Items.Clear();
            for (int i = 0; i < System.IO.Ports.SerialPort.GetPortNames().Length; i++)
            {
                comboBox_COMPort.Items.Add(i + 1);
            }
            comboBox_COMPort.SelectedIndex = 0;
            radioButton_C2FlexSoftCrypto.Checked = true;
            
        }

        public void OnReceiveProtocol(FedmIscReader reader, byte[] receiveProtocol)
        {
        }
        public void OnReceiveProtocol(FedmIscReader reader, String receiveProtocol)
        {
            richTextBox_ProtocolWindow.Text += receiveProtocol;
        }

        public void OnSendProtocol(FedmIscReader reader, byte[] sendProtocol)
        {
        }
        public void OnSendProtocol(FedmIscReader reader, String sendProtocol)
        {
            richTextBox_ProtocolWindow.Text += sendProtocol;
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            int Back = 0;
            FedmIscReaderInfo ReaderInfo;

            if (radioButton_C1USB.Checked)
            {
                try
                {
                    Reader.ConnectUSB(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "Connection Error");
                    try
                    {
                        Reader.DisConnect();
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(this, ex2.ToString(), "Connection Error");
                    }

                    return;
                }
            }
            else if(radioButton_C1Serial.Checked)
            {
                try
                {
                    Reader.ConnectCOMM((int)comboBox_COMPort.SelectedItem, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "Connection Error");
                    try
                    {
                        Reader.DisConnect();
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(this, ex2.ToString(), "Connection Error");
                    }

                    return;
                }
            }

            ReaderInfo = Reader.ReadReaderInfo();
	        if(ReaderInfo == null)
	        {
		        Back = Reader.GetLastError();
		        if(Back < 0)
			        Reader.GetErrorText(Back);
		        else
			        Reader.GetStatusText((byte)Back);
                try
                {
		            Reader.DisConnect();
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(this, ex2.ToString(), "Connection Error");
                }
		        return;		
	        }

            if (Reader.Connected)
            {
                button_Connect.Enabled = false;
                button_Disconnect.Enabled = true;
                button_InventorySelect.Enabled = true;
                radioButton_C1USB.Enabled = false;
                radioButton_C1Serial.Enabled = false;
                comboBox_COMPort.Enabled = false;
                label2.Enabled = false;
                radioButton_C2FlexSoftCrypto.Enabled = false;
                radioButton_C2SamCrypto.Enabled = false;
            }
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                Reader.DisConnect();
                button_Connect.Enabled = true;
                button_Disconnect.Enabled = false;
                button_InventorySelect.Enabled = false;
                radioButton_C1USB.Enabled = true;
                radioButton_C1Serial.Enabled = true;
                comboBox_COMPort.Enabled = true;
                label2.Enabled = true;
                radioButton_C2FlexSoftCrypto.Enabled = true;
                radioButton_C2SamCrypto.Enabled = true;

                button_Personalization.Enabled = false;
                button_ReadStandartData.Enabled = false;
                button_WriteStandartData.Enabled = false;
                button_FormatCard.Enabled = false;
            }
            catch (Exception ex2)
            {
                MessageBox.Show(this, ex2.ToString(), "Connection Error");
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            try
            {
                if (Reader.Connected)
                {
                    Reader.DisConnect();
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(this, ex2.ToString(), "Connection Error");
            }
            this.Close();
        }

        private void button_InventorySelect_Click(object sender, EventArgs e)
        {
            Dictionary<string, FedmIscTagHandler> TagList;
            FedmIscTagHandler TagHandler = null;

            //---

            // Inventory command

            TagList = Reader.TagInventory(true, 0x00, 1);

            if (TagList.Count != 1)
            {
                //No or more than one transponder detected
                button_Personalization.Enabled = false;
                button_ReadStandartData.Enabled = false;
                button_WriteStandartData.Enabled = false;
                button_FormatCard.Enabled = false;
                return;
            }


            // tag found
			Dictionary<string, FedmIscTagHandler>.ValueCollection listTagHandler = TagList.Values;

			foreach (FedmIscTagHandler tagHandler in listTagHandler)
			{
				if (tagHandler != null)
				{
					TagHandler = tagHandler;
					break;
				}
			}

            // Select Transponder
            TagHandler = Reader.TagSelect(TagHandler, 9);	// Try to select tranponder as Mifare DESFire

			// Check if transponder could be selected as Mifare DESFire
			//byte[] respData = null;
			if (TagHandler is FedmIscTagHandler_ISO14443_4_MIFARE_DESFire)
            {
                DESFire = (FedmIscTagHandler_ISO14443_4_MIFARE_DESFire)TagHandler;
				//DESFire.IFlexSoftCrypto.GetVersion((byte)0, out respData);
            }
            else
            {
                button_Personalization.Enabled = false;
                button_ReadStandartData.Enabled = false;
                button_WriteStandartData.Enabled = false;
                button_FormatCard.Enabled = false;
                return;
            }


            if (radioButton_C2FlexSoftCrypto.Checked == false)
            {
                // SAM Crypto -> Activate Card in Slot 1 with T=1 protocol
                int Back = ActivateSamT1(0x00, false);
                //int Back = ActivateSamT1(0xB7, true);
                if (Back != 0)
                {
                    if (Back < 0)
                    {
                        MessageBox.Show(Reader.GetErrorText(Back));
                    }
                    else if (Back > 0)
                    {
                        MessageBox.Show(Reader.GetErrorText(Back));
                    }
                    return;
                }
                // Set communication timoeut for 0xC3 - Mode 0x01 commands


                //DESFire.ISamCrypto.SetTimeout(50);	// in steps of 100ms: 50* 100ms = 5 seconds
                DESFire.ISamCrypto.SetTimeout(50);
            }

                button_Personalization.Enabled = true;
                button_ReadStandartData.Enabled = true;
                button_WriteStandartData.Enabled = true;
                button_FormatCard.Enabled = true;
        }

        private void button_Personalization_Click(object sender, EventArgs e)
        {
            int Back = 0;
	        //uint Start = 0, End = 0;
	        //---

            //Start = GetTickCount();
	        if(radioButton_C2FlexSoftCrypto.Checked == true)	// Fast Soft Crypto
	        {
		        Back = DESFire_FlexSoftCrypt_0xC3_Personalization();
	        }
	        else					//	SAM Crypto
	        {
		        Back = DESFire_SamCrypt_0xC3_Personalization();
	        }
            //End = GetTickCount();
	        if(Back != 0)
	        {
                button_Personalization.Enabled = false;
                button_ReadStandartData.Enabled = false;
                button_WriteStandartData.Enabled = false;
                button_FormatCard.Enabled = false;	
	        }
	        else
	        {
                //string cMsg = "Personalization process takes %ld ms\n" + (End - Start);
		        //MessageBox(cMsg, 0, MB_OK | MB_ICONINFORMATION);
                
	        }
        }

        private void button_ReadStandartData_Click(object sender, EventArgs e)
        {
            int Back = 0;
            
	        //uint Start = 0, End = 0;
	        //---

	        //Start = GetTickCount();
            if (radioButton_C2FlexSoftCrypto.Checked == true)	// Fast Soft Crypto
	        {
		        Back = DESFire_FlexSoftCrypt_0xC3_ReadStdData();
	        }
	        else					//	SAM Crypto
	        {
		        Back = DESFire_SamCrypt_0xC3_ReadStdData();
	        }
	        //End = GetTickCount();
	        if(Back != 0)
	        {
                button_Personalization.Enabled = false;
                button_ReadStandartData.Enabled = false;
                button_WriteStandartData.Enabled = false;
                button_FormatCard.Enabled = false;
	        }
	        else
	        {
                //string cMsg = "Read process takes %ld ms\n" + (End - Start);
		        //MessageBox(cMsg, 0, MB_OK | MB_ICONINFORMATION);
	        }
        }

        private void button_WriteStandartData_Click(object sender, EventArgs e)
        {
            int Back = 0;
	        //uint Start = 0, End = 0;
	        //---

	        //Start = GetTickCount();
            if (radioButton_C2FlexSoftCrypto.Checked == true)	// Fast Soft Crypto
	        {
		        Back = DESFire_FlexSoftCrypt_0xC3_WriteStdData();
	        }
	        else					//	SAM Crypto
	        {
		        Back = DESFire_SamCrypt_0xC3_WriteStdData();
	        }
	        //End = GetTickCount();
	        if(Back != 0)
	        {
                button_Personalization.Enabled = false;
                button_ReadStandartData.Enabled = false;
                button_WriteStandartData.Enabled = false;
                button_FormatCard.Enabled = false;	
	        }
	        else
	        {
                //string cMsg = "Write process takes %ld ms\n" + (End - Start);
		        //MessageBox(cMsg, 0, MB_OK | MB_ICONINFORMATION);	
	        }
        }

        private void button_FormatCard_Click(object sender, EventArgs e)
        {
            int Back = 0;
	        //uint Start = 0, End = 0;
	        //---

	        //Start = GetTickCount();
	        if(radioButton_C2FlexSoftCrypto.Checked == true)	// Fast Soft Crypto
	        {
		        Back = DESFire_FlexSoftCrypt_0xC3_FormatCard();
	        }
	        else					//	SAM Crypto
	        {
		        Back = DESFire_SamCrypt_0xC3_FormatCard();
	        }
	        //End = GetTickCount();
	        if(Back != 0)
	        {
                button_Personalization.Enabled = false;
                button_ReadStandartData.Enabled = false;
                button_WriteStandartData.Enabled = false;
                button_FormatCard.Enabled = false;	
	        }
	        else
	        {
                //string cMsg = "Format process takes %ld ms\n" + (End - Start);
		        //MessageBox(cMsg, 0, MB_OK | MB_ICONINFORMATION);	
	        }
        }

        /********************************************************************************************************
        *																										*
        *						FAST SOFT CRYPTO [0xC3] - Mode 0x00												*
        *																										*
        /*******************************************************************************************************/
        /***************************************************************************
          Begin        		:	08.11.2010 / M. Sahm
          
          Version       	:	01.00.00 / 08.11.2010 / M. Sahm

          Function			:	Write of keys for authentication int reader

          Parameters		:	string			Key					-	[in]	Key (8/16/24 Bytes)	
					            uint	iIndex					-	[in]	Reader Key Table Index (0...3)
					            uint	AuthenticationMode	-	[in]	Authentication Mode (AES, TDES, NativeDES, ...[0...5])	
					            bool			EEPROM					-	[in]	true: write key into EEPROM; false: write key into ram

          Return value		:	FEDM_OK(=0) or error code (<0)
        ***************************************************************************/
        private int WriteAuthentKeys(string Key, uint Index, uint AuthenticationMode, bool EEPROM)
        {
            int Back = 0;
            //---

            // check parameters
            if((Index > 3) || (AuthenticationMode > 5))
            {
                return Fedm.ERROR_PARAMETER;
            }
            else if((Key.Length != 16) && (Key.Length != 32) && (Key.Length != 48))
            {
                return Fedm.ERROR_PARAMETER;
            }

            // Write Key into Reader
            byte ucMode = 0;
            if(EEPROM)
            {
                ucMode = 1;
            }
            else
            {
                ucMode = 0;
            }
            Reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_0xA3_MODE, (byte)ucMode);							// RAM or EEPROM
            Reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_0xA3_KEY_INDEX, (byte)Index);						// Index
            Reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_0xA3_AUTHENTICATE_MODE, (byte)AuthenticationMode);	// Authentication Mode (AES, TDES, Native DES, ...)
            Reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_0xA3_KEY_LEN, (uint)Key.Length >> 1);	//:2		// Length of the Key
            Reader.SetData(FedmIscReaderID.FEDM_ISC_TMP_0xA3_KEY, Key);												// Key

                if((Back=Reader.SendProtocol(0xA3))!=0) 
                {
                    //SetLastError(Back); 
                    return Back;
                } 


            return Fedm.OK;
        }


        /***************************************************************************
          Begin        		:	08.11.2010 / M. Sahm
          
          Version       	:	01.00.00 / 08.11.2010 / M. Sahm

          Function			:	Personalization of a "new" DESFire EV1 transponder

          Parameters		:	-

          Return value		:	FEDM_OK(=0), Status(>0) or error code (<0)
        ***************************************************************************/
        private int DESFire_FlexSoftCrypt_0xC3_Personalization()
        {
            int Back = 0;

            // STEP 1: Create Application on DESFire EV1 transponder
            byte PiccLevelFlags = 0x00;				// No ISO7816 File ID used; No ISO7816 DF Name used
            uint ApplicationID = 0x123456;			// Application ID
            byte KeySetting1		= 0x0F;				// Application Master Key Settings: Change Key Access Rights : 0; 
													            //									configuration changeable
													            //									free create/delete without master key
													            //									free directory list access without master key
													            //									allow change master key
            byte KeySetting2		= 0x8E;				// Key Settings 2:		AES crypto Method for this application
													            //						ISO7816 File Identifiers not used
													            //						14 keys stored for this application
            uint ISOFileID = 0;						// ISO FileID [not used, refer to PiccLevelFlags]
            string DFName = "";								// ISO7816 DF Name [not used, refer to PiccLevelFlags]
            Back = DESFire.IFlexSoftCrypto.CreateApplication(PiccLevelFlags, ApplicationID, KeySetting1, KeySetting2, ISOFileID, DFName);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 2: Select Application
            PiccLevelFlags = 0x00;							// Not used for this command (RFU)
            ApplicationID = 0x123456;							// Application ID
            Back = DESFire.IFlexSoftCrypto.SelectApplication(PiccLevelFlags, ApplicationID);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 3: Create Std. data file
            byte ApplicationLevelFlags		= 0x00;	// No ISO7816 File ID used
            byte FileNo						= 0x05;	// File ID
            ISOFileID									= 0;	// ISO File ID [not used, refer to ApplicationLevelFlags]
            byte FileCommSettings			= 0x03;	// Fully enciphred data
            byte FileReadAccessRights		= 0x01;	// Read Access Rights (DF KeyNo with Read access rights)
            byte FileWriteAccessRights		= 0x02;	// Write Access Rights (DF KeyNo with Write access rights)
            byte FileReadWriteAccessRights	= 0x03;	// Read/Write Access Rights (DF KeyNo with Read/Write access rights)
            byte FileChangeAccessRights		= 0x00;	// Change Access Rights (DF KeyNo with Change access rights)
            uint FileSize						= 128;	// File Size in bytes
            Back = DESFire.IFlexSoftCrypto.CreateStdDataFile(ApplicationLevelFlags, FileNo, ISOFileID, FileCommSettings, FileReadWriteAccessRights, FileChangeAccessRights, FileReadAccessRights, FileWriteAccessRights, FileSize);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 4: Write Data to Std data file
            // STEP 4.1: Write DESFire Authent Key inside the reader (into RAM) [Default Key]
            string Key = "00000000000000000000000000000000";	// Default Key
            uint Index = 0;							// Reader Key Index 0
            uint AuthenticationMode = 5;				// AES encryption
            bool EEPROM = false;								// Write Key to RAM
            Back = WriteAuthentKeys(Key, Index, AuthenticationMode, EEPROM);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }
            // STEP 4.2: Authent with Default Key to KeyNo 2
            byte ReaderKeyIdx = 0x00;				// Reader Key Index 0 (DESFire "Default Key" inside)
            byte DESFireKeyNo = 0x02;				// Authent with DESFire KeyNo 2 (DESFire "Write Key")
            Back = DESFire.IFlexSoftCrypto.Authenticate(ReaderKeyIdx, DESFireKeyNo);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }
            // STEP 4.3: Write data to std data file
            byte DataManipulationFlags = 0x00;		// Valid authentication necessary (No Free-Access to file)
            FileNo = 0x05;									// File ID
            FileCommSettings = 0x03;							// Fully enciphered data
            uint FileOffset = 0;						// File offset
            uint FileLen = 20;						// Number of bytes to write
            byte[] FileData = new byte[1024];						// Buffer with data to be written
            //memset(FileData, 0x00, sizeof(FileData));
            FileData[0]  = (byte)'F';
            FileData[1] = (byte)'E';
            FileData[2] = (byte)'I';
            FileData[3] = (byte)'G';
            FileData[4] = (byte)' ';
            FileData[5] = (byte)'E';
            FileData[6] = (byte)'L';
            FileData[7] = (byte)'E';
            FileData[8] = (byte)'C';
            FileData[9] = (byte)'T';
            FileData[10] = (byte)'R';
            FileData[11] = (byte)'O';
            FileData[12] = (byte)'N';
            FileData[13] = (byte)'I';
            FileData[14] = (byte)'C';
            FileData[15] = (byte)' ';
            FileData[16] = (byte)'G';
            FileData[17] = (byte)'m';
            FileData[18] = (byte)'b';
            FileData[19] = (byte)'H';
            Back = DESFire.IFlexSoftCrypto.WriteStandardData(DataManipulationFlags, FileNo, FileCommSettings, FileOffset, FileLen, FileData);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 5: Change Keys
            // STEP 5.1: Authent with Application Master Key (KeyNo 0)
            ReaderKeyIdx = 0x00;								// Reader Key Index 0 (DESFire "Default Key" inside)
            DESFireKeyNo = 0x00;								// Authent with DESFire KeyNo 0 (DESFire Application Master Key)
            Back = DESFire.IFlexSoftCrypto.Authenticate(ReaderKeyIdx, DESFireKeyNo);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
                    MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 5.2: Change DF KeyNo 1 (Read Key) of selected application 
            byte KeyNoToBeChanged = 0x01;			// DESFire KeyNo to be changed (Read Key)
            byte AESNewKeyVersion = 0x00;			// New AES Key Version
            string OldKey = "00000000000000000000000000000000";// Old Key
            string NewKey = "AABBCCDDEEFF00112233445566778899";// New Key
            Back = DESFire.IFlexSoftCrypto.ChangeKey(ApplicationID,ReaderKeyIdx,DESFireKeyNo,KeyNoToBeChanged, AESNewKeyVersion, OldKey, NewKey);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 5.3: Change DF KeyNo 2 (Write Key) of selected application 
            KeyNoToBeChanged = 0x02;							// DESFire KeyNo to be changed (Write Key)
            AESNewKeyVersion = 0x00;							// New AES Key Version
            OldKey = "00000000000000000000000000000000";		// Old Key
            NewKey = "1234567890ABCDEF1234567890ABCDEF";		// New Key
            Back = DESFire.IFlexSoftCrypto.ChangeKey(ApplicationID, ReaderKeyIdx, DESFireKeyNo, KeyNoToBeChanged, AESNewKeyVersion, OldKey, NewKey);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            return Back;
        }


        /***************************************************************************
          Begin        		:	08.11.2010 / M. Sahm
          
          Version       	:	01.00.00 / 08.11.2010 / M. Sahm

          Function			:	Read of data from a DESFire std data file

          Parameters		:	

          Return value		:	FEDM_OK(=0), Status (>0) or error code (<0)
        ***************************************************************************/
        private int DESFire_FlexSoftCrypt_0xC3_ReadStdData() 
        {
            int Back = 0;
            // ---

            // STEP 1: Write DESFire Authent Key inside the reader (into RAM)
            string Key = "AABBCCDDEEFF00112233445566778899";	// DESFire "Read Key" (DESFire was personalized before)
            uint Index = 0;							// Reader Key Index 0
            uint AuthenticationMode = 5;				// AES encryption
            bool EEPROM = false;								// Write Key to RAM
            Back = WriteAuthentKeys(Key, Index, AuthenticationMode, EEPROM);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
                    MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 2: Select application on DESFire transponder
            byte PiccLevelFlags = 0x00;				// Not used for this command (RFU)
            uint ApplicationID = 0x123456;			// ApplicationID
            Back = DESFire.IFlexSoftCrypto.SelectApplication(PiccLevelFlags, ApplicationID);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 3: Authent on application with DESFire KeyNo
            byte ReaderKeyIdx = 0x00;				// Reader Key Index 0 (DESFire "Read Key" inside)
            byte DESFireKeyNo = 0x01;				// Authent with DESFire KeyNo 1 (DESFire "Read Key")
            Back = DESFire.IFlexSoftCrypto.Authenticate(ReaderKeyIdx, DESFireKeyNo);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 4: Read std. sata from file
            byte DataManipulationFlags = 0x00;		// Valid authentication necessary (No Free-Access to file)
            byte FileNo = 0x05;						// File ID
            byte FileCommSettings = 0x03;			// Fully enciphered data
            uint FileOffset = 0;						// File offset
            uint FileLen = 20;						// Length of the data to be read
            byte[] FileData = new byte[1024];						// Buffer for response data
            //memset(FileData, 0x00, sizeof(FileData));
            Back = DESFire.IFlexSoftCrypto.ReadStandardData(DataManipulationFlags, FileNo, FileCommSettings, FileOffset, FileLen, out FileData);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }


            return Back;
        }


        /***************************************************************************
          Begin        		:	08.11.2010 / M. Sahm
          
          Version       	:	01.00.00 / 08.11.2010 / M. Sahm

          Function			:	Write data to a DESFire std data file

          Parameters		:	

          Return value		:	FEDM_OK(=0), Status (>0) or error code (<0)
        ***************************************************************************/
        private int DESFire_FlexSoftCrypt_0xC3_WriteStdData() 
        {
            int Back = 0;
            // ---

            // STEP 1: Write DESFire Authent Key inside the reader (into RAM)
            string Key = "1234567890ABCDEF1234567890ABCDEF";	// DESFire Write Key (DESFire was personalized before)
            uint Index = 0;							// Reader Key Index 0
            uint AuthenticationMode = 5;				// AES encryption
            bool EEPROM = false;								// Write Key to RAM
            Back = WriteAuthentKeys(Key, Index, AuthenticationMode, EEPROM);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
                    MessageBox.Show(Reader.GetStatusText((byte)Back));
	            }
	            return Back;
            }

            // STEP 2: Select application on DESFire transponder
            byte PiccLevelFlags = 0x00;				// Not used for this command (RFU)
            uint ApplicationID = 0x123456;			// ApplicationID
            Back = DESFire.IFlexSoftCrypto.SelectApplication(PiccLevelFlags, ApplicationID);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
                    MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
                    MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 3: Authent on application with DESFire KeyNo
            byte ReaderKeyIdx = 0x00;				// Reader Key Index 0 (DESFire "Write Key" inside)
            byte DESFireKeyNo = 0x02;				// Authent with DESFire KeyNo 2 (DESFire "Write Key")
            Back = DESFire.IFlexSoftCrypto.Authenticate(ReaderKeyIdx, DESFireKeyNo);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
                    MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
                    MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 4: Write Std. Data to file
            byte DataManipulationFlags = 0x00;		// Valid authentication necessary (No Free-Access to file)
            byte FileNo = 0x05;						// File ID
            byte FileCommSettings = 0x03;			// Fully enciphered data
            uint FileOffset = 0;						// File offset
            uint FileLen = 20;						// Length of the data to be written
            byte[] FileData = new byte[1024];						// Buffer for write data
            //memset(FileData, 0x00, sizeof(FileData));
            FileData[0]  = (byte)'F';
            FileData[1] = (byte)'E';
            FileData[2] = (byte)'I';
            FileData[3] = (byte)'G';
            FileData[4] = (byte)' ';
            FileData[5] = (byte)'E';
            FileData[6] = (byte)'L';
            FileData[7] = (byte)'E';
            FileData[8] = (byte)'C';
            FileData[9] = (byte)'T';
            FileData[10] = (byte)'R';
            FileData[11] = (byte)'O';
            FileData[12] = (byte)'N';
            FileData[13] = (byte)'I';
            FileData[14] = (byte)'C';
            FileData[15] = (byte)' ';
            FileData[16] = (byte)'G';
            FileData[17] = (byte)'m';
            FileData[18] = (byte)'b';
            FileData[19] = (byte)'H';
            Back = DESFire.IFlexSoftCrypto.WriteStandardData(DataManipulationFlags, FileNo, FileCommSettings, FileOffset, FileLen, FileData);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
                    MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
                    MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            return Back;
        }


        /***************************************************************************
          Begin        		:	08.11.2010 / M. Sahm
          
          Version       	:	01.00.00 / 08.11.2010 / M. Sahm

          Function			:	Formate a DESFire EV1 transponder

          Parameters		:	

          Return value		:	FEDM_OK(=0), Status (>0) or error code (<0)
        ***************************************************************************/
        private int DESFire_FlexSoftCrypt_0xC3_FormatCard()
        {
            int Back = 0;

            // STEP 1: Write DESFire Authent Key inside the reader (into RAM) [PICC Master Key]
            string Key = "00000000000000000000000000000000";	// Default PICC Master Key
            uint Index = 0;							// Reader Key Index 0
            uint AuthenticationMode = 0;				// Native TDES encryption
            bool EEPROM = false;								// Write Key to RAM
            Back = WriteAuthentKeys(Key, Index, AuthenticationMode, EEPROM);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
                    MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 2: Select master application on DESFire transponder
            byte PiccLevelFlags = 0x00;				// Not used for this command (RFU)
            uint ApplicationID = 0x00000000;			// PICC Master Application
            Back = DESFire.IFlexSoftCrypto.SelectApplication(PiccLevelFlags, ApplicationID);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 3: Authent on master application with DESFire KeyNo 0 (PiccMasterKey)
            byte ReaderKeyIdx = 0x00;				// Reader Key Index 0 (DESFire PICC Master Key inside)
            byte DESFireKeyNo = 0x00;				// Authent with DESFire KeyNo 0 (DESFire PICC Master Key)
            Back = DESFire.IFlexSoftCrypto.Authenticate(ReaderKeyIdx, DESFireKeyNo);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 4: Format Card (Whole Memory is cleared)
            PiccLevelFlags = 0x00;							// Not used for this command (RFU)
            Back = DESFire.IFlexSoftCrypto.FormatPICC(PiccLevelFlags);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            return Back;
        }


        /********************************************************************************************************
        *																										*
        *						SAM CRYPTO [0xC3] - Mode 0x01													*
        *																										*
        /*******************************************************************************************************/
        /***************************************************************************
          Begin        		:	08.11.2010 / M. Sahm
          
          Version       	:	01.00.00 / 08.11.2010 / M. Sahm

          Function			:	Personalization of a "new" DESFire EV1 transponder

          Parameters		:	-

          Return value		:	FEDM_OK(=0), Status(>0) or error code (<0)
        ***************************************************************************/
        private int ActivateSamT1(byte ucTA1, bool bExternal_TA1)
        {
            int Back = 0;

            /********************** De/Activate SAM *****************************/
            // ############## STEP 1 ######################
            // ------------ Deactivate Request ------------
            int iSlotNr						= 1;			// Use SAM slot 1
            int iSAMTimeout_Activate		= 70;			// 70* 100ms Activation Timeout
            byte[] DeactivateReq = new byte[2] {0x01, 0x00};	// Deactivate request [0x01] [0x00]
            byte[] DeactivateResp = new byte[128];				// Response buffer
            int DeactivateRespLen			= 0;			// Response len
            Back = Reader.SendSAMCommand(iSlotNr, (uint)iSAMTimeout_Activate, DeactivateReq, ref DeactivateResp, ref DeactivateRespLen);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }
        	
            // ############## STEP 2 ################################
            // ------------ Activate Request (T=1 protcol)-----------
            iSlotNr							= 1;		// Use SAM slot 1
            iSAMTimeout_Activate			= 70;		// 70* 100ms Activation Timeout
            byte[] ActivateReq = null;				// Activate request [0x01] [0xXX] [0xXX]

            if (bExternal_TA1)
                ActivateReq = new byte[3];
            else
                ActivateReq = new byte[2];

            ActivateReq[0] = 0x01;
            ActivateReq[1] = 0x03;

            byte[] AcitvateResp = new byte[128];
            int ActivateRespLen = 0;			// Response len
            // Check if external TA1 is used for activation sequence
            if(bExternal_TA1)
            {
	            ActivateReq[1] |= 0x08;
	            ActivateReq[2] = ucTA1;
           }

            Back = Reader.SendSAMCommand(iSlotNr, (uint)iSAMTimeout_Activate, ActivateReq, ref AcitvateResp, ref ActivateRespLen);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            /********************** De/Activate SAM [END]*****************************/	

            return 0;
        }
        /***************************************************************************
          Begin        		:	08.11.2010 / M. Sahm
          
          Version       	:	01.00.00 / 08.11.2010 / M. Sahm

          Function			:	Personalization of a "new" DESFire EV1 transponder

          Parameters		:	-

          Return value		:	FEDM_OK(=0), Status(>0) or error code (<0)
        ***************************************************************************/
        private int DESFire_SamCrypt_0xC3_Personalization()
        {
            int Back = 0;

            // STEP 1: Create Application on DESFire EV1 transponder
            byte SamSlotNo		= 0x01;				// Use SAM Slot 1
            byte PiccLevelFlags	= 0x00;				// No ISO7816 File ID used; No ISO7816 DF Name used
            uint ApplicationID	= 0x123456;			// Application ID
            byte KeySetting1		= 0x0F;				// Application Master Key Settings: Change Key Access Rights : 0; 
													            //									configuration changeable
													            //									free create/delete without master key
													            //									free directory list access without master key
													            //									allow change master key
            byte KeySetting2		= 0x8E;				// Key Settings 2:		AES crypto Method for this application
													            //						ISO7816 File Identifiers not used
													            //						14 keys stored for this application
            uint ISOFileID		= 0;				// ISO FileID [not used, refer to PiccLevelFlags and KeySetting2]
            string DFName					= "";				// ISO7816 DF Name [not used, refer to PiccLevelFlags]
            Back = DESFire.ISamCrypto.CreateApplication(SamSlotNo, PiccLevelFlags, ApplicationID, KeySetting1, KeySetting2, ISOFileID, DFName);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 2: Select Application
            SamSlotNo = 0x01;									// Use SAM Slot 1
            PiccLevelFlags = 0x00;							// Not used for this command (RFU)
            ApplicationID = 0x123456;							// Application ID
            Back = DESFire.ISamCrypto.SelectApplication(SamSlotNo, PiccLevelFlags, ApplicationID);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 3: Create Std. data file
            SamSlotNo						= 0x01;	// Use SAM Slot 1
            byte ApplicationLevelFlags		= 0x00;	// No ISO7816 File ID used
            byte FileNo						= 0x05;	// File ID
            ISOFileID						= 0;	// ISO File ID [not used, refer to ApplicationLevelFlags]
            byte FileCommSettings			= 0x03;	// Fully enciphred data
            byte FileReadAccessRights		= 0x01;	// Read Access Rights (DF KeyNo with Read access rights)
            byte FileWriteAccessRights		= 0x02;	// Write Access Rights (DF KeyNo with Write access rights)
            byte FileReadWriteAccessRights	= 0x03;	// Read/Write Access Rights (DF KeyNo with Read/Write access rights)
            byte FileChangeAccessRights		= 0x00;	// Change Access Rights (DF KeyNo with Change access rights)
            uint FileSize					= 512;	// File Size in bytes
            Back = DESFire.ISamCrypto.CreateStdDataFile(SamSlotNo, ApplicationLevelFlags, FileNo, ISOFileID, FileCommSettings, FileReadWriteAccessRights, FileChangeAccessRights, FileReadAccessRights, FileWriteAccessRights, FileSize);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 4: Write Data to Std data file
            // STEP 4.1: Authent with AES Default Key to DF-KeyNo 2
            SamSlotNo									= 0x01;		// Use SAM Slot 1
            byte DESFireAuthMode				= 0xAA;		// AES Authentication
            byte DESFireKeyNo				= 0x02;		// Authent with DESFire KeyNo 2 (DESFire "Write Key")
            byte SamAuthMode					= 0x00;		// No Key Diversification used
            byte SamKeyNo					= 0x01;		// Key Entry 1 in SAM [AES Key 0x00000000000000000000000000000000]
            byte SamKeyVersion				= 0x00;		// Key Version 0 in SAM key entry
            byte[] DiversificationInput		= null;		// No Diversification used

            Back = DESFire.ISamCrypto.Authenticate(SamSlotNo, DESFireAuthMode, DESFireKeyNo, SamAuthMode, SamKeyNo, SamKeyVersion, DiversificationInput);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }
            // STEP 4.2: Write data to std data file
            SamSlotNo								= 0x01;		// Use SAM Slot 1
            byte DataManipulationFlags	= 0x00;		// Valid authentication necessary (No Free-Access to file)
            FileNo								= 0x05;		// File ID
            FileCommSettings						= 0x03;		// Fully enciphered data
            uint FileOffset				= 0;		// File offset
            uint FileLen					= 20;		// Number of bytes to write
            byte[] FileData = new byte[1024];						// Buffer with data to be written
            //memset(FileData, 0x00, sizeof(FileData));
            FileData[0]  = (byte)'F';
            FileData[1] = (byte)'E';
            FileData[2] = (byte)'I';
            FileData[3] = (byte)'G';
            FileData[4] = (byte)' ';
            FileData[5] = (byte)'E';
            FileData[6] = (byte)'L';
            FileData[7] = (byte)'E';
            FileData[8] = (byte)'C';
            FileData[9] = (byte)'T';
            FileData[10] = (byte)'R';
            FileData[11] = (byte)'O';
            FileData[12] = (byte)'N';
            FileData[13] = (byte)'I';
            FileData[14] = (byte)'C';
            FileData[15] = (byte)' ';
            FileData[16] = (byte)'G';
            FileData[17] = (byte)'m';
            FileData[18] = (byte)'b';
            FileData[19] = (byte)'H';
            Back = DESFire.ISamCrypto.WriteStandardData(SamSlotNo, DataManipulationFlags, FileNo, FileCommSettings, FileOffset, FileLen, FileData);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
                    MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 5: Change Keys
            // STEP 5.1: Authent with Application Master Key (KeyNo 0)
            SamSlotNo						= 0x01;		// Use SAM Slot 1
            DESFireAuthMode				= 0xAA;		// AES Authentication
            DESFireKeyNo					= 0x00;		// Authent with DESFire KeyNo 0 (DESFire Application Master Key)
            SamAuthMode					= 0x00;		// No Key Diversification used
            SamKeyNo						= 0x01;		// Key Entry 1 in SAM [AES Key 0x00000000000000000000000000000000]
            SamKeyVersion					= 0x00;		// Key Version 0 in SAM key entry
            DiversificationInput			= null;		// No Diversification used
            Back = DESFire.ISamCrypto.Authenticate(SamSlotNo, DESFireAuthMode, DESFireKeyNo, SamAuthMode, SamKeyNo, SamKeyVersion, DiversificationInput);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 5.2: Change DF KeyNo 1 (Read Key) of selected application 
            SamSlotNo									= 0x01;		// Use SAM Slot 1
            byte SamKeyCompilationMethod		= 0x00;		//
            byte SamCfg						= 0x01;		// DF KeyNo 0x01 should be changed
            byte SamKeyNoCurrentKey			= 0x01;		// Current Key is inside SAM Key entry 1 [AES Key 0x00000000000000000000000000000000]
            byte SamKeyVersionCurrentKey		= 0x00;		// Current Key Version is 0x00
            byte SamKeyNoNewKey				= 0x02;		// New Key is inside SAM Key entry 2	 [AES Key 0xAABBCCDDEEFF00112233445566778899]
            byte SamKeyVersionNewKey			= 0x00;		// New Key Version is 0x00
            byte[] SamDiversificationInput = null;
            Back = DESFire.ISamCrypto.ChangeKey(SamSlotNo, SamKeyCompilationMethod, SamCfg, SamKeyNoCurrentKey, SamKeyVersionCurrentKey, SamKeyNoNewKey, SamKeyVersionNewKey, SamDiversificationInput);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 5.3: Change DF KeyNo 2 (Write Key) of selected application 
            SamSlotNo						= 0x01;		// Use SAM Slot 1
            SamKeyCompilationMethod		= 0x00;		//
            SamCfg						= 0x02;		// DF KeyNo 0x02 should be changed
            SamKeyNoCurrentKey			= 0x01;		// Current Key is inside SAM Key entry 1		[AES Key 0x00000000000000000000000000000000]
            SamKeyVersionCurrentKey		= 0x00;		// Current Key Version is 0x00;
            SamKeyNoNewKey				= 0x03;		// New Key is inside SAM Key entry 3			[AES Key 0x1234567890ABCDEF1234567890ABCDEF]
            SamKeyVersionNewKey			= 0x00;		// New Key Version is 0x00
            SamDiversificationInput		= null;		// No Diversification used
            Back = DESFire.ISamCrypto.ChangeKey(SamSlotNo, SamKeyCompilationMethod, SamCfg, SamKeyNoCurrentKey, SamKeyVersionCurrentKey, SamKeyNoNewKey, SamKeyVersionNewKey, SamDiversificationInput);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            return Back;
        }


        /***************************************************************************
          Begin        		:	08.11.2010 / M. Sahm
          
          Version       	:	01.00.00 / 08.11.2010 / M. Sahm

          Function			:	Read of data from a DESFire std data file

          Parameters		:	

          Return value		:	FEDM_OK(=0), Status (>0) or error code (<0)
        ***************************************************************************/
        private int DESFire_SamCrypt_0xC3_ReadStdData() 
        {
            int Back = 0;
            // ---

            // STEP 1: Select application on DESFire transponder
            byte SamSlotNo		= 0x01;				// Use SAM Slot 1
            byte PiccLevelFlags	= 0x00;				// Not used for this command (RFU)
            uint ApplicationID	= 0x123456;			// ApplicationID
            Back = DESFire.ISamCrypto.SelectApplication(SamSlotNo, PiccLevelFlags, ApplicationID);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 2: Authent on application with DESFire KeyNo
            SamSlotNo									= 0x01;		// Use SAM Slot 1
            byte DESFireAuthMode				= 0xAA;		// AES Authentication
            byte DESFireKeyNo				= 0x01;		// Authent with DESFire KeyNo 1 (DESFire "Read Key")
            byte SamAuthMode					= 0x00;		// No Key Diversification used
            byte SamKeyNo					= 0x02;		// Key Entry 2 in SAM					[AES Key 0xAABBCCDDEEFF00112233445566778899]
            byte SamKeyVersion				= 0x00;		// Key Version 0 in SAM key entry
            byte[] DiversificationInput		= null;		// No Diversification used
            Back = DESFire.ISamCrypto.Authenticate(SamSlotNo, DESFireAuthMode, DESFireKeyNo, SamAuthMode, SamKeyNo, SamKeyVersion, DiversificationInput);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 3: Read std. sata from file
            SamSlotNo								= 0x01;		// Use SAM Slot 1
            byte DataManipulationFlags	= 0x00;		// Valid authentication necessary (No Free-Access to file)
            byte FileNo					= 0x05;		// File ID
            byte FileCommSettings		= 0x03;		// Fully enciphered data
            uint FileOffset				= 0;		// File offset
            uint FileLen					= 512;		// Length of the data to be read
            byte[] FileData = new byte[1024];						// Buffer for response data
            //memset(FileData, 0x00, sizeof(FileData));
            Back = DESFire.ISamCrypto.ReadStandardData(SamSlotNo, DataManipulationFlags, FileNo, FileCommSettings, FileOffset, FileLen, out FileData);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }


            return Back;
        }


        /***************************************************************************
          Begin        		:	08.11.2010 / M. Sahm
          
          Version       	:	01.00.00 / 08.11.2010 / M. Sahm

          Function			:	Write data to a DESFire std data file

          Parameters		:	

          Return value		:	FEDM_OK(=0), Status (>0) or error code (<0)
        ***************************************************************************/
        private int DESFire_SamCrypt_0xC3_WriteStdData() 
        {
            int Back = 0;
            // ---

            // STEP 1: Select application on DESFire transponder
            byte SamSlotNo		= 0x01;				// Use SAM Slot 1
            byte PiccLevelFlags	= 0x00;				// Not used for this command (RFU)
            uint ApplicationID	= 0x123456;			// ApplicationID
            Back = DESFire.ISamCrypto.SelectApplication(SamSlotNo, PiccLevelFlags, ApplicationID);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 2: Authent on application with DESFire KeyNo
            SamSlotNo									= 0x01;		// Use SAM Slot 1
            byte DESFireAuthMode				= 0xAA;		// AES Authentication
            byte DESFireKeyNo				= 0x02;		// Authent with DESFire KeyNo 2 (DESFire "Write Key")
            byte SamAuthMode					= 0x00;		// No Key Diversification used
            byte SamKeyNo					= 0x03;		// Key Entry 3 in SAM				[AES Key 0x1234567890ABCDEF1234567890ABCDEF]
            byte SamKeyVersion				= 0x00;		// Key Version 0 in SAM key entry
            byte[] DiversificationInput		= null;		// No Diversification used
            Back = DESFire.ISamCrypto.Authenticate(SamSlotNo, DESFireAuthMode, DESFireKeyNo, SamAuthMode, SamKeyNo, SamKeyVersion, DiversificationInput);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 3: Write Std. Data to file
            SamSlotNo									= 0x01;		// Use SAM Slot 1
            byte DataManipulationFlags		= 0x00;		// Valid authentication necessary (No Free-Access to file)
            byte FileNo						= 0x05;		// File ID
            byte FileCommSettings			= 0x03;		// Fully enciphered data
            uint FileOffset					= 0;		// File offset
            uint FileLen						= 20;		// Length of the data to be written
            byte[] FileData = new byte[1024];							// Buffer for write data
            FileData[0] = (byte)'F';
            FileData[1] = (byte)'E';
            FileData[2] = (byte)'I';
            FileData[3] = (byte)'G';
            FileData[4] = (byte)' ';
            FileData[5] = (byte)'E';
            FileData[6] = (byte)'L';
            FileData[7] = (byte)'E';
            FileData[8] = (byte)'C';
            FileData[9] = (byte)'T';
            FileData[10] = (byte)'R';
            FileData[11] = (byte)'O';
            FileData[12] = (byte)'N';
            FileData[13] = (byte)'I';
            FileData[14] = (byte)'C';
            FileData[15] = (byte)' ';
            FileData[16] = (byte)'G';
            FileData[17] = (byte)'m';
            FileData[18] = (byte)'b';
            FileData[19] = (byte)'H';
            Back = DESFire.ISamCrypto.WriteStandardData(SamSlotNo, DataManipulationFlags, FileNo, FileCommSettings, FileOffset, FileLen, FileData);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            return Back;
        }


        /***************************************************************************
          Begin        		:	08.11.2010 / M. Sahm
          
          Version       	:	01.00.00 / 08.11.2010 / M. Sahm

          Function			:	Formate a DESFire EV1 transponder

          Parameters		:	

          Return value		:	FEDM_OK(=0), Status (>0) or error code (<0)
        ***************************************************************************/
        private int DESFire_SamCrypt_0xC3_FormatCard()
        {
            int Back = 0;

            // STEP 1: Select master application on DESFire transponder
            byte SamSlotNo		= 0x01;				// Use SAM Slot 1
            byte PiccLevelFlags	= 0x00;				// Not used for this command (RFU)
            uint ApplicationID	= 0x00000000;		// PICC Master Application
            Back = DESFire.ISamCrypto.SelectApplication(SamSlotNo, PiccLevelFlags, ApplicationID);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 2: Authent on master application with DESFire KeyNo 0 (PiccMasterKey)
            SamSlotNo									= 0x01;		// Use SAM Slot 1
            byte DESFireAuthMode				= 0x0A;		// DESFire Native DES Authentication
            byte DESFireKeyNo				= 0x00;		// Authent with DESFire KeyNo 0 (DESFire PICC Master Key)
            byte SamAuthMode					= 0x00;		// No Key Diversification used
            byte SamKeyNo					= 0x00;		// Key Entry 0 in SAM				[Native DES Key 0x00000000000000000000000000000000]
            byte SamKeyVersion				= 0x00;		// Key Version 0 in SAM key entry
            byte[] DiversificationInput		= null;		// No Diversification used
            Back = DESFire.ISamCrypto.Authenticate(SamSlotNo, DESFireAuthMode, DESFireKeyNo, SamAuthMode, SamKeyNo, SamKeyVersion, DiversificationInput);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

            // STEP 3: Format Card (Whole Memory is cleared)
            SamSlotNo			= 0x01;		// Use SAM Slot 1
            PiccLevelFlags	= 0x00;		// Not used for this command (RFU)
            Back = DESFire.ISamCrypto.FormatPICC(SamSlotNo, PiccLevelFlags);
            if(Back != 0)
            {
	            if(Back < 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            else if(Back > 0)
	            {
		            MessageBox.Show(Reader.GetErrorText(Back));
	            }
	            return Back;
            }

	        return Back;
        }

        private void richTextBox_ProtocolWindow_TextChanged(object sender, EventArgs e)
        {
            ((RichTextBox)sender).SelectionStart = ((RichTextBox)sender).Text.Length;
            ((RichTextBox)sender).ScrollToCaret();
        }
    }
}