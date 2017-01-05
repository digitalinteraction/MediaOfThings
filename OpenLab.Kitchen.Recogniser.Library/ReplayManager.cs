using System.Collections.Generic;
using System.Linq;
using OpenLab.Kitchen.Recogniser.Library.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public class ReplayManager<T, S> : IReplayManager<S> where T : TimeModel where S : TimeModel
    {
        private readonly IRecogniser<T, S> _recogniser;
        private readonly IQueryable<T> _dataset;

        public ICollection<S> States { get; }

        public ReplayManager(IRecogniser<T, S> recogniser, IQueryable<T> dataset)
        {
            _recogniser = recogniser;
            _dataset = dataset;

            States = new List<S>();
        }

        public void Process()
        {
            _recogniser.StateChanged += (sender, state) =>
            {
                States.Add(state);
            };

            foreach (var d in _dataset.OrderBy(d => d.Timestamp))
            {
                _recogniser.UpdateClock(d.Timestamp);
                _recogniser.Update(d);
            }
        }

        public IEnumerable<S> GetStates()
        {
            return States;
        }
    }
}
