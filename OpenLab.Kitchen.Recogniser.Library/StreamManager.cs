using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenLab.Kitchen.Recogniser.Library.Interfaces;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public class StreamManager<T, S> : IStreamManager where T : DataModel where S : DataModel
    {
        private const int TICKPERIOD = 100;

        private readonly IRecieveRepository<T> _recieveRepository;
        private readonly ISendRepository<S> _sendRepository;
        private readonly IRecogniser<T, S> _recogniser;

        private Timer Timer { get; set; }

        public StreamManager(IRecieveRepository<T> recieveRepository, ISendRepository<S> sendRepository, IRecogniser<T, S> recogniser)
        {
            _recieveRepository = recieveRepository;
            _sendRepository = sendRepository;
            _recogniser = recogniser;
        }

        public void Start()
        {
            _recieveRepository.Subscribe(DataRecieved);
            _recogniser.StateChanged += StateChanged;

            var timer = new Timer((state) =>
            {
                _recogniser.UpdateClock(DateTime.Now);
            }, null, TICKPERIOD, Timeout.Infinite);
        }

        private void StateChanged(object sender, S state)
        {
            _sendRepository.Send(state);
        }

        public void Stop()
        {
            _recieveRepository.UnSubscribe();
        }

        private void DataRecieved(T data)
        {
            _recogniser.Update(data);
        }
    }
}
