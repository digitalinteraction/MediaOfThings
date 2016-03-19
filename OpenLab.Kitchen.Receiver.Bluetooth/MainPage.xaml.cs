using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using OpenLab.Kitchen.StreamingRepository;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OpenLab.Kitchen.Receiver.Bluetooth
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly Guid _scalesServiceGuid = new Guid("ADA3");

        private readonly ScalesStreamer _scalesStreamer;

        private BluetoothLEAdvertisementWatcher Watcher { get; }

        public MainPage()
        {
            this.InitializeComponent();

            _scalesStreamer = new ScalesStreamer();

            Watcher = new BluetoothLEAdvertisementWatcher();
            Watcher.Received += ScalesFound;

            StartScanning();
        }

        private void StartScanning()
        {
            Watcher.Start();
        }

        private void StopScanning()
        {
            Watcher.Stop();
        }

        private void ScalesFound(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs btAdv)
        {
        }
    }
}
