using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Service.Interfaces
{
    public interface IReadWriteRepository<T, I> : IReadOnlyRepository<T, I>
    {
        void Insert(T model);
        void Update(T model);
        void Delete(T model);
    }
}
