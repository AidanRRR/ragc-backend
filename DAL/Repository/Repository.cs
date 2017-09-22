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

        public async Task<T> Create<T>(T item) where T : class, new()
        {

            await _db.GetCollection<T>(typeof(T).Name).InsertOneAsync(item);
            return item;
        }

        public async Task<T> Read<T>(FilterDefinition<T> filter) where T : class, new()
        {
            var result = await _db.GetCollection<T>(typeof(T).Name).Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public Task<T> Update<T>(FilterDefinition<T> filter, T item) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete<T>(T item) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<T>> List<T>(FilterDefinition<T> filter) where T : class, new()
        {
            var result = await _db.GetCollection<T>(typeof(T).Name).Find(filter).ToListAsync();
            return result.AsQueryable();
        }
    }
}
