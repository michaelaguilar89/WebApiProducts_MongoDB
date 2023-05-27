using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WebApiProducts_MongoDB.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Price { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public Object? Urls { get; set; }
    }
}
