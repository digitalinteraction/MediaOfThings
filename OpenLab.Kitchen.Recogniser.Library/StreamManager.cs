using System;
using System.Collections.Generic;
using System.Text;
using OpenLab.Kitchen.Recogniser.Library.Interfaces;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public class StreamManager<T, I, S> : IStreamManager where T : DataModel
    {
        private readonly IRecieveRepository<T> _recieveRepository;
        private readonly IRecogniser<T, I, S> _recogniser;

        public StreamManager(IRecieveRepository<T> recieveRepository, IRecogniser<T, I, S> recogniser, string queueName)
        {
            _recieveRepository = recieveRepository;
            _recogniser = recogniser;
        }

        public void Start()
        {
            _recieveRepository.Subscribe(DataRecieved);
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
