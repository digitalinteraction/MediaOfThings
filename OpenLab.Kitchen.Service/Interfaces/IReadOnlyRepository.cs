using System;
using System.Linq;
using System.Linq.Expressions;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Service.Interfaces
{
    public interface IReadOnlyRepository<T>
    {
        T GetById(int id);
        IQueryable<T> Search(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
    }
}
