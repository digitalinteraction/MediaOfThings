using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using OpenLab.Kitchen.Service.Models.Streaming;
using OpenLab.Kitchen.StreamingRepository;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OpenLab.Kitchen.Receiver.Wax9
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const float AccNorm = 1.0f / 4096.0f;
        private const float GyroNorm = 0.07f;
        private const float MagNorm = 0.1f;

        private readonly Guid _serviceGuid = new Guid("00000000-0008-A8BA-E311-F48C90364D99");
        private readonly Guid _streamGuid = new Guid("00000001-0008-A8BA-E311-F48C90364D99");
        private readonly Guid _notifyGuid = new Guid("00000002-0008-A8BA-E311-F48C90364D99");
        private readonly Guid _sampleRateGuid = new Guid("0000000A-0008-A8BA-E311-F48C90364D99");
        private readonly string[] _devices = { "WAX9-0883", "WAX9-08C9", "WAX9-0A27", "WAX9-0983", "WAX9-095B" };

        private ICollection<BluetoothLEDevice> Devices { get; }

        private readonly Wax9Streamer _wax9Streamer;
        
        private BluetoothLEAdvertisementWatcher Watcher { get; }
        private DeviceWatcher DeviceWatcher { get; }

        public MainPage()
        {
            this.InitializeComponent();

            _wax9Streamer = new Wax9Streamer();

            Devices = new List<BluetoothLEDevice>();

            Watcher = new BluetoothLEAdvertisementWatcher { ScanningMode = BluetoothLEScanningMode.Active };
            Watcher.Received += DeviceFound;

            DeviceWatcher = DeviceInformation.CreateWatcher();
            DeviceWatcher.Added += DeviceAdded;
            DeviceWatcher.Updated += DeviceUpdated;

            StartScanning();
        }

        private void StartScanning()
        {
            Watcher.Start();
            DeviceWatcher.Start();
        }

        private void StopScanning()
        {
            Watcher.Stop();
            DeviceWatcher.Stop();
        }

        private async void DeviceFound(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs btAdv)
        {
            if (_devices.Contains(btAdv.Advertisement.LocalName))
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Low, async () =>
                {
                    Debug.WriteLine($"---------------------- {btAdv.Advertisement.LocalName} ----------------------");
                    Debug.WriteLine($"Advertisement Data: {btAdv.Advertisement.ServiceUuids.Count}");
                    var device = await BluetoothLEDevice.FromBluetoothAddressAsync(btAdv.BluetoothAddress);
                    var result = await device.DeviceInformation.Pairing.PairAsync(DevicePairingProtectionLevel.None);
                    Debug.WriteLine($"Pairing Result: {result.Status}");
                    Debug.WriteLine($"Connected Data: {device.GattServices.Count}");

                    if (device.GattServices.Any())
                    {
                        SetupWaxStream(device);
                    }
                });
            }
        }

        private async void DeviceAdded(DeviceWatcher watcher, DeviceInformation device)
        {
            if (_devices.Contains(device.Name))
            {
                try
                {
                    var service = await GattDeviceService.FromIdAsync(device.Id);
                    Debug.WriteLine("Opened Service!!");
                }
                catch
                {
                    Debug.WriteLine("Failed to open service.");
                }
            }
        }

        private void DeviceUpdated(DeviceWatcher watcher, DeviceInformationUpdate update)
        {
            Debug.WriteLine($"Device updated: {update.Id}");
        }

        private async void SetupWaxStream(BluetoothLEDevice device)
        {
            try
            {
                var service = device.GetGattService(_serviceGuid);

                byte[] sampleRate = {50};
                var sampleRateCharacs = service.GetCharacteristics(_sampleRateGuid);

                if (!sampleRateCharacs.Any())
                {
                    Debug.WriteLine("Unable to find characteristics.");
                    return;
                }

                await sampleRateCharacs.First().WriteValueAsync(sampleRate.AsBuffer());

                byte[] stream = {1};
                var streamCharac = service.GetCharacteristics(_streamGuid).First();
                await streamCharac.WriteValueAsync(stream.AsBuffer());

                var notifyCharac = service.GetCharacteristics(_notifyGuid).First();
                await notifyCharac.WriteClientCharacteristicConfigurationDescriptorAsync(
                    GattClientCharacteristicConfigurationDescriptorValue.Notify);
                notifyCharac.ValueChanged += (sender, args) =>
                {
                    _wax9Streamer.Send(ProcessWaxData(device, args.CharacteristicValue.ToArray()));
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Unable to connect to WAX: {e}");
            }
        }

        private Wax9Data ProcessWaxData(BluetoothLEDevice device, byte[] data)
        {
            var sampleNumber = (data[1] << 8 + data[0]);

            var ax = (data[3] << 8 + data[2]) * AccNorm;
            var ay = (data[5] << 8 + data[4]) * AccNorm;
            var az = (data[7] << 8 + data[6]) * AccNorm;

            var gx = (data[9] << 8 + data[8]) * GyroNorm;
            var gy = (data[11] << 8 + data[10]) * GyroNorm;
            var gz = (data[13] << 8 + data[12]) * GyroNorm;

            var mx = (data[15] << 8 + data[14]) * MagNorm;
            var my = (data[17] << 8 + data[16]) * MagNorm;
            var mz = (data[19] << 8 + data[18]) * MagNorm;

            return new Wax9Data
            {
                LocationId = 1,
                DeviceId = device.Name,
                DataTimeStamp = DateTime.Now,
                SampleNumber = sampleNumber,
                AccX = ax,
                AccY = ay,
                AccZ = az,
                GyroX = gx,
                GyroY = gy,
                GyroZ = gz,
                MagX = mx,
                MagY = my,
                MagZ = mz
            };
        }
    }
}
