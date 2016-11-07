using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using OpenLab.Kitchen.Service.Models;
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

        private readonly Guid _streamServiceGuid = new Guid("00000000-0008-A8BA-E311-F48C90364D99");
        private readonly Guid _sampleRateServiceGuid = new Guid("00000005-0008-A8BA-E311-F48C90364D99");
        private readonly Guid _streamGuid = new Guid("00000001-0008-A8BA-E311-F48C90364D99");
        private readonly Guid _notifyGuid = new Guid("00000002-0008-A8BA-E311-F48C90364D99");
        private readonly Guid _sampleRateGuid = new Guid("0000000A-0008-A8BA-E311-F48C90364D99");
        private readonly string[] _devices = { "WAX9-0A27", "WAX9-0983" };

        private ObservableCollection<string> ConnectedDevices { get; }

        private readonly Wax9Streamer _wax9Streamer;
        
        private BluetoothLEAdvertisementWatcher Watcher { get; }
        private DeviceWatcher DeviceWatcher { get; }

        public MainPage()
        {
            this.InitializeComponent();

            _wax9Streamer = new Wax9Streamer();

            ConnectedDevices = new ObservableCollection<string>();

            ConnectedDevicesView.ItemsSource = ConnectedDevices;

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

        private async void DeviceFound(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs btAdv)
        {
            if (!ConnectedDevices.Contains(btAdv.Advertisement.LocalName) && _devices.Contains(btAdv.Advertisement.LocalName))
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Low, async () =>
                {
                    var device = await BluetoothLEDevice.FromBluetoothAddressAsync(btAdv.BluetoothAddress);
                    if (device.GattServices.Any())
                    {
                        ConnectedDevices.Add(device.Name);
                        device.ConnectionStatusChanged += async (sender, args) =>
                        {
                            if (sender.ConnectionStatus == BluetoothConnectionStatus.Disconnected)
                            {
                                await Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
                                {
                                    ConnectedDevices
                                        .Remove(
                                            sender
                                                .Name);
                                });
                            }
                        };
                        SetupWaxStream(device);
                    } else if (device.DeviceInformation.Pairing.CanPair && !device.DeviceInformation.Pairing.IsPaired)
                    {
                        await device.DeviceInformation.Pairing.PairAsync(DevicePairingProtectionLevel.None);
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
                    var characteristics = service.GetAllCharacteristics();
                }
                catch
                {
                    Debug.WriteLine("Failed to open service.");
                }
            }
        }

        private async void DeviceUpdated(DeviceWatcher watcher, DeviceInformationUpdate update)
        {
            var device = await DeviceInformation.CreateFromIdAsync(update.Id);
            if (_devices.Contains(device.Name))
            {
                try
                {
                    var service = await GattDeviceService.FromIdAsync(device.Id);
                    var characteristics = service.GetAllCharacteristics();
                }
                catch
                {
                    Debug.WriteLine("Failed to open service.");
                }
            }
        }

        private async void SetupWaxStream(BluetoothLEDevice device)
        {
            try
            {
                var sampleRateService = device.GattServices.Single(s => s.Uuid == _sampleRateServiceGuid);

                byte[] sampleRate = {50};
                var sampleRateCtx = sampleRateService.GetAllCharacteristics().Single(c => c.Uuid == _sampleRateGuid);

                await sampleRateCtx.WriteValueAsync(sampleRate.AsBuffer());

                var characteristics =
                    device.GattServices.Single(s => s.Uuid == _streamServiceGuid).GetAllCharacteristics();

                byte[] stream = {1};
                var streamCharac = characteristics.Single(c => c.Uuid == _streamGuid);
                await streamCharac.WriteValueAsync(stream.AsBuffer());

                var notifyCharac = characteristics.Single(c => c.Uuid == _notifyGuid);
                await notifyCharac.WriteClientCharacteristicConfigurationDescriptorAsync(
                    GattClientCharacteristicConfigurationDescriptorValue.Notify);
                notifyCharac.ValueChanged += (sender, args) =>
                {
                    _wax9Streamer.Send(ProcessWaxData(device.Name, args.CharacteristicValue.ToArray()));
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Unable to connect to WAX: {e}");
            }
        }

        private Wax9Data ProcessWaxData(string device, byte[] data)
        {
            var sampleNumber = (ushort)((data[1] << 8) + data[0]);

            var ax = (short)((data[3] << 8) + data[2]) * AccNorm;
            var ay = (short)((data[5] << 8) + data[4]) * AccNorm;
            var az = (short)((data[7] << 8) + data[6]) * AccNorm;

            var gx = (short)((data[9] << 8) + data[8]) * GyroNorm;
            var gy = (short)((data[11] << 8) + data[10]) * GyroNorm;
            var gz = (short)((data[13] << 8) + data[12]) * GyroNorm;

            var mx = (short)((data[15] << 8) + data[14]) * MagNorm;
            var my = (short)((data[17] << 8) + data[16]) * MagNorm;
            var mz = (short)((data[19] << 8) + data[18]) * MagNorm;

            return new Wax9Data
            {
                DeviceId = device,
                TimeStamp = DateTime.Now,
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
