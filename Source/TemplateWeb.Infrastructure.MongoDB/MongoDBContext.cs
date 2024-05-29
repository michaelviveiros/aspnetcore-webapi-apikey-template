using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateWeb.Infrastructure.MongoDB.Interfaces;

namespace TemplateWeb.Infrastructure.MongoDB
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoDBContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            if (client != null)
                _database = client.GetDatabase(settings.Value.DataBaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
