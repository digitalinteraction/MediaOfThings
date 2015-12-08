using System;
using System.Diagnostics;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.UI.Xaml.Controls;

namespace OpenLab.Kitchen.Receiver
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ConnectToSerialPort()
        {
            try
            {
                var serialDevices = await DeviceInformation.FindAllAsync(SerialDevice.GetDeviceSelector());
                var serialPort = await SerialDevice.FromIdAsync(serialDevices[0].Id);
                serialPort.WriteTimeout = TimeSpan.FromMilliseconds(1000);
                serialPort.ReadTimeout = TimeSpan.FromMilliseconds(1000);
                serialPort.BaudRate = 9600;
                serialPort.Parity = SerialParity.None;
                serialPort.StopBits = SerialStopBitCount.One;
                serialPort.DataBits = 8;
                serialPort.Handshake = SerialHandshake.None;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
