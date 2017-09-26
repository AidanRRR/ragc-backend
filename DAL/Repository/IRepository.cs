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
        Task<T> Create<T>() where T : class, new();
        Task<T> Read<T>() where T : class, new();
        Task<T> Update<T>() where T : class, new();
        Task<T> Delete<T>() where T : class, new();
    }
}
