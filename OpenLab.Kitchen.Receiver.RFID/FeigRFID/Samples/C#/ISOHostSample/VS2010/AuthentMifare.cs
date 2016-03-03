using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OBID;

namespace ISOHostSample
{
    public partial class AuthentMifare : Form
    {
        private FedmIscReader fedm;

        public AuthentMifare(FedmIscReader reader)
        {
            InitializeComponent();
            // Init Reader Object
            this.fedm = reader;

            // set components
            this.comboBoxKeyLoc.Enabled = true;
            this.comboBoxKeyLoc.SelectedIndex = 1; // Key from Reader

            this.comboBoxKeyType.Enabled = true;
            this.comboBoxKeyType.SelectedIndex = 0; // Key A 

            this.numericUpDown_DBAdr.Enabled = true;
            this.numericUpDown_KeyAdr.Enabled = true;

            this.textBox_Key1.Enabled = false;
            this.textBox_Key1.Text = "00";

            this.textBox_Key2.Enabled = false;
            this.textBox_Key2.Text = "00";

            this.textBox_Key3.Enabled = false;
            this.textBox_Key3.Text = "00";

            this.textBox_Key4.Enabled = false;
            this.textBox_Key4.Text = "00";
            
            this.textBox_Key5.Enabled = false;
            this.textBox_Key5.Text = "00";

            this.textBox_Key6.Enabled = false;
            this.textBox_Key6.Text = "00";

        }

        private void comboBoxKeyLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if "Key from Protocol" enable controls
            if((int)this.comboBoxKeyLoc.SelectedIndex == 0)
            {
                this.comboBoxKeyType.Enabled = true;
                this.numericUpDown_DBAdr.Enabled = true;
                this.numericUpDown_KeyAdr.Enabled = false;
                this.textBox_Key1.Enabled = true;
                this.textBox_Key2.Enabled = true;
                this.textBox_Key3.Enabled = true;
                this.textBox_Key4.Enabled = true;
                this.textBox_Key5.Enabled = true;
                this.textBox_Key6.Enabled = true;
            }
            else
            {
                this.comboBoxKeyType.Enabled = true;
                this.numericUpDown_DBAdr.Enabled = true;
                this.numericUpDown_KeyAdr.Enabled = true;
                this.textBox_Key1.Enabled = false;
                this.textBox_Key2.Enabled = false;
                this.textBox_Key3.Enabled = false;
                this.textBox_Key4.Enabled = false;
                this.textBox_Key5.Enabled = false;
                this.textBox_Key6.Enabled = false;
            }
        }

        private void button_Authent_Click(object sender, EventArgs e)
        {
            String strKey;

            // get Key
            strKey = this.textBox_Key1.Text +
                     this.textBox_Key2.Text +
                     this.textBox_Key3.Text +
                     this.textBox_Key4.Text +
                     this.textBox_Key5.Text +
                     this.textBox_Key6.Text;

            // ------ perform Authent Mifare
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_CMD, 0xB0);  // Sub-Command
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_MODE, 0x00); // delete value Mode Byte (MODE_KL and MODE_ADR)
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_MODE_ADR, FedmIscReaderConst.ISO_MODE_SEL); // Fixed Selected Mode
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_DB_ADR, (int)this.numericUpDown_DBAdr.Value); // requested DataBlock Addr
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_KEY_TYPE, (byte)this.comboBoxKeyType.SelectedIndex); // Key type (A or B)

            byte bKeyLoc = (byte)this.comboBoxKeyLoc.SelectedIndex;
            if (bKeyLoc == 1)
            {
                // EEPROM Addr. where Key is stored
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_KEY_ADR, (byte)this.numericUpDown_KeyAdr.Value);
            }
            else
            {
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_ISO14443A_KEY, strKey);
                fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_MODE_KL, true); // choose Key Location - from Protocol
            }

            try
            {
               fedm.SendProtocol((byte)0xB2);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Error");
                return;
            }
            // Close window after authent command
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            //Close Dialog
            this.Close();
        }

        private void textBox_Key1_Leave(object sender, EventArgs e)
        {
            String strKey;
            Char[] chKeyValue;

            strKey = this.textBox_Key1.Text;
            if (strKey.Length != 2)
            {
                MessageBox.Show("Key-No. 1 has a wrong Format! \n Value must be between 00 and FF !");
            }

            chKeyValue = strKey.ToCharArray();
            for (int i = 0; i < strKey.Length; i++)
            {
                if (!((chKeyValue[i] >= '0' && chKeyValue[i] <= '9') ||
                     (chKeyValue[i] >= 'a' && chKeyValue[i] <= 'f') ||
                     (chKeyValue[i] >= 'A' && chKeyValue[i] <= 'F')))
                {
                    MessageBox.Show("Key-No. 1 has a wrong Format! \n Value must be between 00 and FF !");
                }
            }
        }

        private void textBox_Key2_Leave(object sender, EventArgs e)
        {
            String strKey;
            Char[] chKeyValue;

            strKey = this.textBox_Key2.Text;
            if (strKey.Length != 2)
            {
                MessageBox.Show("Key-No. 2 has a wrong Format! \n Value must be between 00 and FF !");
            }

            chKeyValue = strKey.ToCharArray();
            for (int i = 0; i < strKey.Length; i++)
            {
                if (!((chKeyValue[i] >= '0' && chKeyValue[i] <= '9') ||
                     (chKeyValue[i] >= 'a' && chKeyValue[i] <= 'f') ||
                     (chKeyValue[i] >= 'A' && chKeyValue[i] <= 'F')))
                {
                    MessageBox.Show("Key-No. 2 has a wrong Format! \n Value must be between 00 and FF !");
                }
            }
        }

        private void textBox_Key3_Leave(object sender, EventArgs e)
        {
            String strKey;
            Char[] chKeyValue;

            strKey = this.textBox_Key3.Text;
            if (strKey.Length != 2)
            {
                MessageBox.Show("Key-No. 3 has a wrong Format! \n Value must be between 00 and FF !");
            }

            chKeyValue = strKey.ToCharArray();
            for (int i = 0; i < strKey.Length; i++)
            {
                if (!((chKeyValue[i] >= '0' && chKeyValue[i] <= '9') ||
                     (chKeyValue[i] >= 'a' && chKeyValue[i] <= 'f') ||
                     (chKeyValue[i] >= 'A' && chKeyValue[i] <= 'F')))
                {
                    MessageBox.Show("Key-No. 3 has a wrong Format! \n Value must be between 00 and FF !");
                }
            }
        }

        private void textBox_Key4_Leave(object sender, EventArgs e)
        {
            String strKey;
            Char[] chKeyValue;

            strKey = this.textBox_Key4.Text;
            if (strKey.Length != 2)
            {
                MessageBox.Show("Key-No. 4 has a wrong Format! \n Value must be between 00 and FF !");
            }

            chKeyValue = strKey.ToCharArray();
            for (int i = 0; i < strKey.Length; i++)
            {
                if (!((chKeyValue[i] >= '0' && chKeyValue[i] <= '9') ||
                     (chKeyValue[i] >= 'a' && chKeyValue[i] <= 'f') ||
                     (chKeyValue[i] >= 'A' && chKeyValue[i] <= 'F')))
                {
                    MessageBox.Show("Key-No. 4 has a wrong Format! \n Value must be between 00 and FF !");
                }
            }
        }

        private void textBox_Key5_Leave(object sender, EventArgs e)
        {
            String strKey;
            Char[] chKeyValue;

            strKey = this.textBox_Key5.Text;
            if (strKey.Length != 2)
            {
                MessageBox.Show("Key-No. 5 has a wrong Format! \n Value must be between 00 and FF !");
            }

            chKeyValue = strKey.ToCharArray();
            for (int i = 0; i < strKey.Length; i++)
            {
                if (!((chKeyValue[i] >= '0' && chKeyValue[i] <= '9') ||
                     (chKeyValue[i] >= 'a' && chKeyValue[i] <= 'f') ||
                     (chKeyValue[i] >= 'A' && chKeyValue[i] <= 'F')))
                {
                    MessageBox.Show("Key-No. 5 has a wrong Format! \n Value must be between 00 and FF !");
                }
            }
        }

        private void textBox_Key6_Leave(object sender, EventArgs e)
        {
            String strKey;
            Char[] chKeyValue;

            strKey = this.textBox_Key6.Text;
            if (strKey.Length != 2)
            {
                MessageBox.Show("Key-No. 6 has a wrong Format! \n Value must be between 00 and FF !");
            }

            chKeyValue = strKey.ToCharArray();
            for (int i = 0; i < strKey.Length; i++)
            {
                if (!((chKeyValue[i] >= '0' && chKeyValue[i] <= '9') ||
                     (chKeyValue[i] >= 'a' && chKeyValue[i] <= 'f') ||
                     (chKeyValue[i] >= 'A' && chKeyValue[i] <= 'F')))
                {
                    MessageBox.Show("Key-No. 6 has a wrong Format! \n Value must be between 00 and FF !");
                }
            }
        }
    }
}