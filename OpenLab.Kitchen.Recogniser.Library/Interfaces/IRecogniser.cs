using System;
using System.Collections.Generic;
using System.Text;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library.Interfaces
{
    public delegate void StateChangedEventHandler<S>(object sender, S state);

    public interface IRecogniser<T, S> where T : DataModel
    {
        event StateChangedEventHandler<S> StateChanged;
        void Update(T data);
        void UpdateClock(DateTime newClock);
    }
}
