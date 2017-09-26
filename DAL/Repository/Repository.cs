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


        public async Task<T> Create<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        public async Task<T> Read<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }

        public async Task<T> Delete<T>() where T : class, new()
        {
            throw new NotImplementedException();
        }
    }
}
