using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Gpio;
using OpenLab.Kitchen.Service.Models.Streaming;
using OpenLab.Kitchen.StreamingRepository;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OpenLab.Kitchen.Receiver.FlowMeter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly WaterFlowStreamer _flowStreamer;
        private GpioPin Pin { get; set; }
        private int CurrentCount { get; set; }
        private DispatcherTimer Timeout { get; }
        private DateTime StartTime { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            _flowStreamer = new WaterFlowStreamer();

            CurrentCount = 0;

            Timeout = new DispatcherTimer();
            Timeout.Tick += (sender, o) =>
            {
                _flowStreamer.Send(new WaterFlow
                {
                    LocationId = 1,
                    DataTimeStamp = DateTime.Now,
                    DeviceId = 1.ToString(),
                    WaterUsed = CurrentCount * 2.25f,
                    Time = StartTime.TimeOfDay
                });

                CurrentCount = 0;
            };

            SetupGpio();
        }

        public void SetupGpio()
        {
            var gpio = GpioController.GetDefault();
            
            if (gpio == null)
            {
                return;
            }

            Pin = gpio.OpenPin(22);
            Pin.SetDriveMode(GpioPinDriveMode.InputPullUp);
            Pin.ValueChanged += (sender, args) =>
            {
                if (args.Edge == GpioPinEdge.RisingEdge)
                {
                    if (CurrentCount < 1)
                    {
                        StartTime = DateTime.Now;
                    }

                    Timeout.Stop();
                    Timeout.Start();

                    CurrentCount++;
                }
            };
        }
    }
}
