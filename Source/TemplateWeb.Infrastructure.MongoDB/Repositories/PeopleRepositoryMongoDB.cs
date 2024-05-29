using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateWeb.Domain.Models;
using TemplateWeb.Domain.Repositories.Interfaces;

namespace TemplateWeb.Infrastructure.MongoDB.Repositories
{
    public class PeopleRepositoryMongoDB : BaseRepositoryMongoDB<PeopleMongo>, IPeopleMongoRepository
    {
        public PeopleRepositoryMongoDB(MongoDBContext context) : base(context)
        {
                
        }

        public async Task<PeopleMongo> GetByNameAsync(string name)
        {
            return await _collection.Find(entity => entity.Name == name).FirstOrDefaultAsync();
        }
    }
}
