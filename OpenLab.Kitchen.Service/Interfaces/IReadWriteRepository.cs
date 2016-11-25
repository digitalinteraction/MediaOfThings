using System.Collections.Generic;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Service.Interfaces
{
    public interface IReadWriteRepository<T> : IReadOnlyRepository<T> where T : Model
    {
        void Insert(T model);
        void InsertMany(IEnumerable<T> models);
        void Update(T model);
        void Delete(T model);
    }
}
