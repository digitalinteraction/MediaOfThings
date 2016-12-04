using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;
using OpenLab.Kitchen.StreamingRepository;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OpenLab.Kitchen.Receiver.Bluetooth
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const string ScaleName = "Drop Weighing Scale";

        private readonly Guid _scalesServiceGuid = GattDeviceService.ConvertShortIdToUuid(0xADA3);
        private readonly Guid _weightGuid = GattDeviceService.ConvertShortIdToUuid(0xFF03);

        private readonly ISendRepository<ScalesData> _scalesStreamer;

        private BluetoothLEAdvertisementWatcher ScalesWatcher { get; }
        private DeviceWatcher ScalesDeviceWatcher { get; }
        private bool ScalesConnected { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            _scalesStreamer = new RabbitMqStreamer<ScalesData>("amqp://streamer@192.68.1.102", "kitchen");

            ScalesWatcher = new BluetoothLEAdvertisementWatcher { ScanningMode = BluetoothLEScanningMode.Active };
            ScalesWatcher.Received += ScaleFound;

            ScalesDeviceWatcher = DeviceInformation.CreateWatcher();
            ScalesDeviceWatcher.Added += ScaleAdded;
            ScalesDeviceWatcher.Updated += ScaleUpdated;

            StartScanning();
        }

        private void StartScanning()
        {
            ScalesWatcher.Start();
            ScalesDeviceWatcher.Start();
        }

        private async void ScaleFound(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs btAdv)
        {
            Debug.WriteLine(btAdv.Advertisement.LocalName);
            if (!ScalesConnected && btAdv.Advertisement.LocalName == ScaleName)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Low, async () =>
                {
                    var device = await BluetoothLEDevice.FromBluetoothAddressAsync(btAdv.BluetoothAddress);
                    if (device.GattServices.Any())
                    {
                        ScalesConnected = true;
                        device.ConnectionStatusChanged += (sender, args) =>
                        {
                            if (sender.ConnectionStatus == BluetoothConnectionStatus.Disconnected)
                            {
                                ScalesConnected = false;
                            }
                        };
                        SetupScalesStream(device);
                    }
                    else if (device.DeviceInformation.Pairing.CanPair && !device.DeviceInformation.Pairing.IsPaired)
                    {
                        await device.DeviceInformation.Pairing.PairAsync(DevicePairingProtectionLevel.None);
                    }
                });
            }
        }

        private async void ScaleAdded(DeviceWatcher watcher, DeviceInformation device)
        {
            if (device.Name == ScaleName)
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

        private async void ScaleUpdated(DeviceWatcher watcher, DeviceInformationUpdate update)
        {
            var device = await DeviceInformation.CreateFromIdAsync(update.Id);
            if (device.Name == ScaleName)
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

        private async void SetupScalesStream(BluetoothLEDevice device)
        {
            try
            {
                var service = device.GetGattService(_scalesServiceGuid);

                var weightCharac = service.GetAllCharacteristics().Single(c => c.Uuid == _weightGuid);
                await weightCharac.WriteClientCharacteristicConfigurationDescriptorAsync(
                    GattClientCharacteristicConfigurationDescriptorValue.Notify);
                weightCharac.ValueChanged += (sender, args) =>
                {
                    Debug.WriteLine(args.CharacteristicValue);
                    
                    double weight = (BitConverter.ToInt32(args.CharacteristicValue.ToArray().Reverse().ToArray(), 0)/10.0) -
                                   500;
                    _scalesStreamer.Send(new ScalesData
                    {
                        DeviceId = 1,
                        Timestamp = DateTime.Now,
                        Weight = (float) weight
                    });
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Unable to connect to Scales: {e}");
            }
        }
    }
}
