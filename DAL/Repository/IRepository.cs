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
        Task<T> Create<T>(T item) where T : class, new();
        Task<T> Read<T>(FilterDefinition<T> filter) where T : class, new();
        Task<T> Update<T>(FilterDefinition<T> filter, T item) where T : class, new();
        Task<T> Delete<T>(T item) where T : class, new();
        Task<IQueryable<T>> List<T>(FilterDefinition<T> filter)  where T : class, new ();
    }
}
