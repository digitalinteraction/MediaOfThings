using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using OBID;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;
using OpenLab.Kitchen.StreamingRepository;

namespace OpenLab.Kitchen.Receiver.Rfid
{
    class Rfid : FeUsbListener
    {
        private readonly ISendRepository<RfidData> _rfidSendRepository; 
        private FeUsb UsbPort { get; set; }
        private IDictionary<int,FedmIscReader> Devices { get; }
        private Timer Interval { get; set; }

        public Rfid()
        {
            _rfidSendRepository = new RabbitMqStreamer<RfidData>("amqp://streamer@192.168.1.102", "kitchen", "rfid");
            Devices = new Dictionary<int, FedmIscReader>();
        }

        public void InitUsb()
        {
            UsbPort = new FeUsb();

            UsbPort.AddEventListener(0, this, FeUsbListenerConst.FEUSB_CONNECT_EVENT);
            UsbPort.AddEventListener(0, this, FeUsbListenerConst.FEUSB_DISCONNECT_EVENT);

            try
            {
                UsbPort.ScanAndOpen(FeUsbScanSearch.SCAN_ALL, null);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }

            for (var i = 0; i < UsbPort.ScanListSize; i++)
            {
                AddDevice(FeHexConvert.HexStringToInteger(UsbPort.GetScanListPara(i, "Device-ID")));
            }

            Interval = new Timer();
            Interval.Interval = 1000;
            Interval.Elapsed += (s,e) => { ReadDevices(); };
            Interval.AutoReset = false;

            ReadDevices();
        }

        void AddDevice(int deviceId)
        {
            var device = new FedmIscReader();

            device.SetTableSize(FedmIscReaderConst.ISO_TABLE, 128);

            try
            {
                device.ConnectUSB(deviceId);
                Devices.Add(deviceId, device);
                device.ReadReaderInfo();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }

        void RemoveDevice(int deviceId)
        {
            Devices.Remove(deviceId);
        }

        void ReadDevices()
        {
            var devices = new Dictionary<int, FedmIscReader>(Devices);
            foreach (var d in devices)
            {
                ReadDevice(d.Key, d.Value);
            }

            Interval.Start();
        }

        void ReadDevice(int deviceId, FedmIscReader device)
        {
            device.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_CMD, 0x01);
            device.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE, 0x00);

            try
            {
                device.ResetTable(FedmIscReaderConst.ISO_TABLE);

                device.SendProtocol(0x69);
                device.SendProtocol(0xB0);

                while (device.GetLastStatus() == 0x94)
                {
                    device.SetData(FedmIscReaderID.FEDM_ISC_TMP_B0_MODE_MORE, 0x01);
                    device.SendProtocol(0xB0);
                }

                var transponders = new string[device.GetTableLength(FedmIscReaderConst.ISO_TABLE)];

                if (transponders.Length > 0)
                {
                    for (var i = 0; i < transponders.Length; i++)
                    {
                        device.GetTableData(i, FedmIscReaderConst.ISO_TABLE, FedmIscReaderConst.DATA_SNR,
                            out transponders[i]);
                    }
                }

                _rfidSendRepository.Send(new Service.Models.RfidData { DeviceId = deviceId.ToString(), Timestamp = DateTime.Now, Transponders = transponders });
                Console.WriteLine($"Device {deviceId} read tags: {string.Join(",", transponders)}");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }

        public void OnConnectReader(int deviceHandle, long deviceId)
        {
            AddDevice((int) deviceId);
        }

        public void OnDisConnectReader(int deviceHandle, long deviceId)
        {
            RemoveDevice((int) deviceId);
        }
    }
}
