using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWeb.Domain.Models
{
    public class PeopleMongo : BaseMongoDBEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Age")]
        public string Age { get; set; }
    }
}
