using System;
using System.Linq;
using System.Linq.Expressions;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Service.Interfaces
{
    public interface IReadOnlyRepository<T, I>
    {
        T GetById(I id);
        IQueryable<T> GetAll();
    }
}
