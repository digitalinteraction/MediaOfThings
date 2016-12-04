using System;
using System.Linq;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Service.Interfaces
{
    public interface IReadOnlyRepository<T> where T : Model
    {
        T GetById(Guid id);
        IQueryable<T> GetAll();
    }
}
