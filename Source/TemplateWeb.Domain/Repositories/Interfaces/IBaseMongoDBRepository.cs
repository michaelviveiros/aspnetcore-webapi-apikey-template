using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWeb.Domain.Repositories.Interfaces
{
    public interface IBaseMongoDBRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id);

        Task AddAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();
    }
}
