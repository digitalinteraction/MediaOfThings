using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLab.Kitchen.Service.Models.Streaming;

namespace OpenLab.Kitchen.Service.Interfaces
{
    public interface ISendRepository<T> where T : StreamingModel
    {
        Task Send(T model);
    }
}
