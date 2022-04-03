using MongoDB.Bson;
using MongoDB.Driver;
using Shop.Domain.Model.Product;
using Shop.Domain.Model.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Repositories
{
    public class ProductMongoDB : IProductRepository
    {
        private MongoClient dbClient;
        private IMongoDatabase database;
        private IMongoCollection<Product> collection;
        public ProductMongoDB()
        {
            dbClient = new MongoClient("<<YOUR ATLAS CONNECTION STRING>>");
            //dbClient.DropDatabase("DDDshop");
            database = dbClient.GetDatabase("DDDshop");
            database.DropCollection("products");
            collection = database.GetCollection<Product>("products");
            for (int i = 0; i < 5; i++)
            {
                Product prod = new Product(i, "Product " + i);
                collection.InsertOne(prod);
            };
        
        }
        public void Add(Product p)
        {
            collection.InsertOne(p);
        }

        public void Delete(int id)
        {
            collection.DeleteOne(product => product.Id == id);
        }

        public Product Find(int id)
        {
            return collection.Find<Product>(product => product.Id == id).FirstOrDefault();
        }

        public IList<Product> FindAll()
        {
            return collection.Find(product => true).ToList<Product>();
        }

        public IList<Product> GetPage(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
