using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DAL.Repository
{
    public class Repository : IRepository
    {
        private readonly IMongoDatabase _db;

        public Repository(IMongoClient client, IOptions<MongoSettings> settings)
        {
            _db = client.GetDatabase(settings.Value.Database);
        }

        public async Task<bool> Create<T>(T item) where T : class, new()
        {
            try
            {
                await _db.GetCollection<T>(typeof(T).Name).InsertOneAsync(item);
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public T Read<T>(FilterDefinition<T> filter) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public T Update<T>(FilterDefinition<T> filter, T item) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public T Delete<T>(T item) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> List<T>(FilterDefinition<T> filter) where T : class, new()
        {
            throw new NotImplementedException();
        }
    }
}
