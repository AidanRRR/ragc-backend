using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DAL.Repository
{
    public interface IRepository
    {
        Task<bool> Create<T>(T item) where T : class, new();
        T Read<T>(FilterDefinition<T> filter) where T : class, new();
        T Update<T>(FilterDefinition<T> filter, T item) where T : class, new();
        T Delete<T>(T item) where T : class, new();
        IQueryable<T> List<T>(FilterDefinition<T> filter)  where T : class, new ();
    }
}
