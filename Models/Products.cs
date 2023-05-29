using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WebApiProducts_MongoDB.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public double? Price { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Urls { get; set; }
    }
}
