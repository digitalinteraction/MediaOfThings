using System;
using System.Collections.Generic;
using System.Text;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library.Interfaces
{
    public interface IRecogniser<T, I, S> where T : DataModel
    {
        S Update(T data);
        IDictionary<I, S> GetAllStates();
    }
}
