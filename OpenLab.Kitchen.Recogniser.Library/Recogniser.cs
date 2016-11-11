using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using OpenLab.Kitchen.Recogniser.Library.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public abstract class Recogniser<T, S> : IRecogniser<T, S> where T : DataModel where S : DataModel
    {
        protected DateTime Clock { get; set; }
        protected IDictionary<string, S> States { get; }

        public event StateChangedEventHandler<S> StateChanged;

        public Recogniser(DateTime startTime)
        {
            Clock = startTime;
            States = new Dictionary<string, S>();
        }

        public virtual void UpdateClock(DateTime newClock)
        {
            Clock = newClock;
        }

        public virtual void Update(T data)
        {
            if (Clock < data.Timestamp)
            {
                Clock = data.Timestamp;
            }
        }

        protected void OnStateChanged(object sender, S updatedState)
        {
            StateChanged?.Invoke(sender, updatedState);
        }
    }
}
