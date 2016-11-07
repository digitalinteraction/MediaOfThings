using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
using OpenLab.Kitchen.Service.Models;
using OpenLab.Kitchen.StreamingRepository;
using Windows.UI.Core;

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
        private int Count { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            _flowStreamer = new WaterFlowStreamer();
            Count = 0;
            SetupGpio();
        }

        public void SetupGpio()
        {
            var gpio = GpioController.GetDefault();
            
            if (gpio == null)
            {
                return;
            }

            Pin = gpio.OpenPin(4);
            Pin.SetDriveMode(GpioPinDriveMode.InputPullUp);
            new Timer(state => { Debug.WriteLine(Pin.Read()); }, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(1));

            /*Pin.ValueChanged += (sender, args) =>
            {
                if (args.Edge == GpioPinEdge.RisingEdge)
                {
                    Count++;
                    Debug.WriteLine(Count * 2 + "ml");
                    _flowStreamer.Send(new WaterFlow
                    {
                        LocationId = 1,
                        DataTimeStamp = DateTime.Now,
                        DeviceId = 1.ToString(),
                        WaterUsed = 2f,
                        Time = DateTime.Now
                    });
                }
            };*/
        }
    }
}
