using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApiProducts_MongoDB.Models;

namespace WebApiProducts_MongoDB.Service
{
    public class ProductService
    {
        private readonly IMongoCollection<Products> _products;

        //Constructor
        public ProductService(IOptions<ProductsDatabaseSettings> options){

            var mongoClient = new MongoClient(
                options.Value.ConnectionString);

            var mongoDataBase = mongoClient.GetDatabase
                (options.Value.DatabaseName);

            _products= mongoDataBase.GetCollection<Products>(
                options.Value.CollectionName ); 
}//end of constructor

        public async Task<List<Products>> get()
        {
            return await _products.Find(_ => true).ToListAsync();
        }

        public async Task<Products> getById(string id)
        {
            return await _products.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateProduct(Products product)
        {
            await _products.InsertOneAsync(product);
        }

        public async Task<bool> EditProduct(string id,Products updateProduct)
        {
            if (getById(id) is null)
            {
                return false;
            }
            await _products.ReplaceOneAsync(x => x.Id == id, updateProduct);
            return true;
        }

        public async Task<bool> RemoveProduct(string id)
        {
            if (getById(id) is null)
            {
                return false;
            }
            await _products.DeleteOneAsync(x => x.Id == id);
            return true;
        }

       
    }
}
