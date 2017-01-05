using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Service.Interfaces
{
    public interface ISendRepository<T> where T : Model, IStreamingModel
    {
        void Send(T model);
    }
}
