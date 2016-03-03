using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OBID;

namespace BRMSample
{
    public partial class PortConnection : Form
    {
        private FedmIscReader fedm;

        public void PortConfig(ref FedmIscReader reader)
        {

            InitializeComponent();
            this.radioButtonUSB.Checked = true;
            try
            {
                int i;
                for (i = 1; i <= 4; i++)
                {
                    this.comboBoxPortnumber.Items.Add(i);
                }
                this.comboBoxPortnumber.SelectedIndex = 0;
            }
            catch (FePortDriverException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.comboBoxBaudrate.SelectedIndex = 5;
            this.comboBoxFrame.SelectedIndex = 7;
            this.Reader = reader;
        }

        public FedmIscReader Reader
        {
            set
            {
                fedm = value;
            }
        }

        private void radioButtonTCP_IP_CheckedChanged(object sender, EventArgs e)
        {
            EnableTCP(true);
            EnableSerial(false);
        }
       
        private void radioButtonSerialPort_CheckedChanged(object sender, EventArgs e)
        {
            EnableTCP(false);
            EnableSerial(true);
        }

        private void radioButtonUSB_CheckedChanged(object sender, EventArgs e)
        {
            EnableTCP(false);
            EnableSerial(false);
        }

        private void EnableTCP(bool enable)
        {
            this.labelHost.Enabled = enable;
            this.textBoxHost.Enabled = enable;
            this.labelPort.Enabled = enable;
            this.textBoxPort.Enabled = enable;
            this.labelTimeout.Enabled = enable;
            this.textBoxTimeout.Enabled = enable;
        }

        private void EnableSerial(bool enable)
        {
            this.labelPortNumber.Enabled = enable;
            this.comboBoxPortnumber.Enabled = enable;
            this.labelBaudrate.Enabled = enable;
            this.comboBoxBaudrate.Enabled = enable;
            this.labelFrame.Enabled = enable;
            this.comboBoxFrame.Enabled = enable;
            this.labelTimeoutSP.Enabled = enable;
            this.textBoxTimeoutSP.Enabled = enable;
        }

        private void OpenSerialPort()
        {

            try
            {
                fedm.ConnectCOMM((int)this.comboBoxPortnumber.SelectedItem,true);
                fedm.SetPortPara("Baud", (this.comboBoxBaudrate.SelectedItem).ToString());
                fedm.SetPortPara("frame", (this.comboBoxFrame.SelectedItem).ToString());
                fedm.SetPortPara("timeout", this.textBoxTimeoutSP.Text);
            }
            catch (FePortDriverException ex)
            {
                MessageBox.Show(ex.ToString(), "Connection Error!");
            }
        }

        private void OpenUSBPort()
        {
            try
            {
                fedm.ConnectUSB(0);
            }
            catch (FePortDriverException ex)
            {
                MessageBox.Show(ex.ToString(), "Connection Error!");
            }
        }

        private void OpenTCPConnection()
        {
            int tcpPort;
            string host;
            int timeout;

            tcpPort = Convert.ToInt32(textBoxPort.Text);
            host = this.textBoxHost.Text;
            timeout = Convert.ToInt32(this.textBoxTimeout.Text);
            try
            {
                fedm.ConnectTCP(host, tcpPort);
                fedm.SetPortPara("Timeout", timeout.ToString());
            }
            catch (FePortDriverException ex)
            {
                MessageBox.Show(ex.ToString(), "Connection Error!");
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (this.radioButtonSerialPort.Checked)
            {
                OpenSerialPort();
                if (fedm.Connected == true)
                {
                    this.Visible = false;
                }
            }
            else
            {
                if (this.radioButtonTCP_IP.Checked)
                {
                    OpenTCPConnection();
                    if (fedm.Connected == true)
                    {
                        this.Visible = false;
                    }
                }
                else
                {
                    OpenUSBPort();
                    if (fedm.Connected == true)
                    {
                        this.Visible = false;
                    }
                }
            }

        }

        private void PortConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fedm.Connected == false)
            {
                MessageBox.Show("Reader not connected!");
            }
        }
    }
}