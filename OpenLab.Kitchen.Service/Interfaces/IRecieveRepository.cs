using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLab.Kitchen.Service.Models.Streaming;

namespace OpenLab.Kitchen.Service.Interfaces
{
    public interface IRecieveRepository<T> where T : StreamingModel
    {
        void Subscribe(Action<T> handler);

        void UnSubscribe();
    }
}
