using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateWeb.Infrastructure.MongoDB.Interfaces;

namespace TemplateWeb.Infrastructure.MongoDB
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string ConnectionString { get; set; }

        public string DataBaseName { get; set; }
    }
}
