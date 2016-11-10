using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using OpenLab.Kitchen.Recogniser.Library.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public abstract class Recogniser<T, I, S> : IRecogniser<T, I, S> where T : DataModel
    {
        public IDictionary<I, S> _states;

        public Recogniser()
        {
            _states = new Dictionary<I, S>();
        }

        public IDictionary<I, S> GetAllStates()
        {
            return _states;
        }
        public abstract S Update(T data);
    }
}
