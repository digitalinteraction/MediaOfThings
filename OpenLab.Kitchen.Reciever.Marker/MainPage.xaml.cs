using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Devices.Gpio;
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

namespace OpenLab.Kitchen.Reciever.Marker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MarkerStreamer _markerStreamer;
        private GpioPin Pin { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            _markerStreamer = new MarkerStreamer();
        }

        public void SetupGpio()
        {
            var gpio = GpioController.GetDefault();

            if (gpio == null)
            {
                return;
            }

            Pin = gpio.OpenPin(36);
            Pin.SetDriveMode(GpioPinDriveMode.InputPullUp);
            Pin.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            Pin.ValueChanged += async (sender, args) =>
            {
                if (args.Edge == GpioPinEdge.FallingEdge)
                {
                    await _markerStreamer.Send(new Service.Models.Streaming.Marker
                    {
                        LocationId = 1,
                        DeviceId = 1,
                        DataTimeStamp = DateTime.Now
                    });
                }
            };
        }
    }
}
