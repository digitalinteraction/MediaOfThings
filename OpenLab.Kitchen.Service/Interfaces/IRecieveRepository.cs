using System;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Service.Interfaces
{
    public interface IRecieveRepository<T> where T : Model, IStreamingModel
    {
        void Subscribe(Action<T> handler);

        void UnSubscribe();
    }
}
