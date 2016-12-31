using System;
using OpenLab.Kitchen.Recogniser.Library.Values;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library.Interfaces
{
    public interface IRecogniser<T, S> where T : TimeModel where S : TimeModel
    {
        event StateChangedEventHandler<S> StateChanged;
        void Update(T data);
        void UpdateClock(DateTime newClock);
    }
}
