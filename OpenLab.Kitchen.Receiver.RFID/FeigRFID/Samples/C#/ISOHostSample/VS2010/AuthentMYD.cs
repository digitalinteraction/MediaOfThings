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
    public partial class AuthentMYD : Form
    {
        private FedmIscReader fedm;
        private int mode;

        public AuthentMYD(FedmIscReader reader)
        {
            InitializeComponent();

            // Init Reader Object
            this.fedm = reader;
            this.mode = 0;

            // Init Values
            this.comboBox_AuthSequence.SelectedIndex = 0;
            this.numericUpDown_AuthCntAdr.Value = 0x03; // Default value

        }

        public void setMode(int mode)
        {
            this.mode = mode;
        }

        private void button_AuthMYD_Click(object sender, EventArgs e)
        {
            int keyAddressTag = (int)this.numericUpDown_KeyAdrTAG.Value;
            int keyAddressSam = (int)this.numericUpDown_KeyAdrSAM.Value;
            int authCntAddress = (int)this.numericUpDown_AuthCntAdr.Value;

            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_KEY_ADR_TAG, keyAddressTag);
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_KEY_ADR_SAM, keyAddressSam);
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_AUTH_COUNTER_ADR, authCntAddress);
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_REQ_KEY_AUTH_SEQUENCE, this.comboBox_AuthSequence.SelectedIndex);
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_MODE_ADR, mode); // addressed(for ISO15693) or selected(for ISO14443) Mode
            fedm.SetData(FedmIscReaderID.FEDM_ISC_TMP_B2_CMD, 0xB1);

            try
            {
                fedm.SendProtocol((byte)0xB2);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Error");
                return;
            }

            //Close Dialog
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}