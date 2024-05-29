using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateWeb.Domain.Models;

namespace TemplateWeb.Domain.Repositories.Interfaces
{
    public interface IPeopleMongoRepository : IBaseMongoDBRepository<PeopleMongo>
    {
        Task<PeopleMongo> GetByNameAsync(string name);
    }
}
