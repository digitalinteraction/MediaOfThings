using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models.Streaming;
using OpenLab.Kitchen.StreamingRepository;

namespace OpenLab.Kitchen.Receiver
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly ISendRepository<Wax3Data> _waxSendRepository; 

        private List<byte> Bytes { get; }

        public MainPage()
        {
            InitializeComponent();
            Bytes = new List<byte>();
            
            ConnectToSerialPort();
            _waxSendRepository = new Wax3Streamer();
        }

        private async void ConnectToSerialPort()
        {
            DeviceInformationCollection serialDevices;

            while ((serialDevices = await DeviceInformation.FindAllAsync(SerialDevice.GetDeviceSelectorFromUsbVidPid(0x04D8, 0x000A))).Count < 1)
            {
                Debug.WriteLine("Unable to locate...");
            }

            ReceiverConnected.IsChecked = true;

            SerialDevice serialPort;

            while ((serialPort = await SerialDevice.FromIdAsync(serialDevices[0].Id)) == null)
            {
                Debug.WriteLine("Failed to open serial port...");
            }

            SerialPortOpen.IsChecked = true;

            serialPort.WriteTimeout = TimeSpan.FromMilliseconds(1000);
            serialPort.ReadTimeout = TimeSpan.FromMilliseconds(1000);
            serialPort.BaudRate = 9600;
            serialPort.Parity = SerialParity.None;
            serialPort.StopBits = SerialStopBitCount.One;
            serialPort.DataBits = 8;
            serialPort.Handshake = SerialHandshake.None;

            var dataReader = new DataReader(serialPort.InputStream);
            var buffer = new byte[1024];

            while (true)
            {
                var bytesRead = await dataReader.LoadAsync((uint)buffer.Length);
                if (bytesRead > 0)
                {
                    try
                    {
                        dataReader.ReadBytes(buffer);
                        Bytes.AddRange(buffer.Take((int) bytesRead));

                        byte[] slipPacket;
                        while ((slipPacket = Slip.ExtractSlipPacket(Bytes)) != null)
                        {
                            var waxPacket = WaxPacketConverter.FromBinary(slipPacket, DateTime.Now);
                            if (waxPacket != null)
                            {
                                foreach (var sample in waxPacket.Samples)
                                {
                                    await _waxSendRepository.Send(new Wax3Data
                                    {
                                        DeviceId = waxPacket.DeviceId,
                                        LocationId = 1,
                                        DataTimeStamp = sample.Timestamp,
                                        Battery = waxPacket.Battery,
                                        AccX = sample.X,
                                        AccY = sample.Y,
                                        AccZ = sample.Z
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }
            }
        }
    }
}
