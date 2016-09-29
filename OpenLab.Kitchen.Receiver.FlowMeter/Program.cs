using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using OpenLab.Kitchen.Service.Models.Streaming;
using OpenLab.Kitchen.StreamingRepository;
using Raspberry.IO.GeneralPurpose;

namespace OpenLab.Kitchen.Receiver.FlowMeter
{
    class Program
    {
        private static WaterFlowStreamer _flowStreamer;
        private static Timer _timeout;
        private static int _currentCount;
        private static DateTime _startTime;

        static void Main(string[] args)
        {
            _flowStreamer = new WaterFlowStreamer();
            _currentCount = 0;

            _timeout = new Timer();
            _timeout.Interval = 5000;
            _timeout.Elapsed += (sender, o) =>
            {
                _flowStreamer.Send(new WaterFlow
                {
                    LocationId = 1,
                    DataTimeStamp = DateTime.Now,
                    DeviceId = 1.ToString(),
                    WaterUsed = _currentCount * 2.25f,
                    Time = _startTime.TimeOfDay
                });

                _currentCount = 0;
            };

            var driver = GpioConnectionSettings.DefaultDriver;
            driver.Allocate(ProcessorPin.Pin0, PinDirection.Output);
            driver.SetPinResistor(ProcessorPin.Pin0, PinResistor.PullUp);

            while (true)
            {
                driver.Wait(ProcessorPin.Pin0);
                if (_currentCount < 1)
                {
                    _startTime = DateTime.Now;
                }

                _timeout.Stop();
                _timeout.Start();

                _currentCount++;
            }
        }
    }
}
