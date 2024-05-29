using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateWeb.Domain.Models;
using TemplateWeb.Domain.Repositories.Interfaces;
using TemplateWeb.Infrastructure.MongoDB.Interfaces;

namespace TemplateWeb.Infrastructure.MongoDB.Repositories
{
    public class BaseRepositoryMongoDB<T> : IBaseMongoDBRepository<T> where T : BaseMongoDBEntity
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseRepositoryMongoDB(MongoDBContext context)
        {
            _collection = context.GetCollection<T>(typeof(T).Name);
        }

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(entity => entity.Id == id).FirstOrDefaultAsync();
        }
    }
}
