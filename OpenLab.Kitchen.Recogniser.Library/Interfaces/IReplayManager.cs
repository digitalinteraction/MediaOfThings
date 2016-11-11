using System.Collections.Generic;

namespace OpenLab.Kitchen.Recogniser.Library.Interfaces
{
    public interface IReplayManager<S>
    {
        void Process();
        IEnumerable<S> GetStates();
    }
}
