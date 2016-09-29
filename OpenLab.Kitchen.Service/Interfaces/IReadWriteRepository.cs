using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Service.Interfaces
{
    public interface IReadWriteRepository<T> : IReadOnlyRepository<T>
    {
        void Insert(T model);
        void Update(T model);
        void Delete(T model);
    }
}
