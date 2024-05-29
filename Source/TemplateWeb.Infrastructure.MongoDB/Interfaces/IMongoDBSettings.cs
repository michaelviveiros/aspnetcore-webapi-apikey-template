using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWeb.Infrastructure.MongoDB.Interfaces
{
    public interface IMongoDBSettings
    {
        public string ConnectionString { get; set; }

        public string DataBaseName { get; set; }
    }
}
