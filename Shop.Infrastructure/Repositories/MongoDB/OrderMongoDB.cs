using MongoDB.Bson;
using MongoDB.Driver;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.Order.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Repositories
{
    class OrderMongoDB : IOrderRepository
    {
        private MongoClient dbClient;
        private IMongoDatabase database;
        private IMongoCollection<Order> collection;
        public OrderMongoDB()
        {
            dbClient = new MongoClient("mongodb://127.0.0.1:27017/?compressors=disabled&gssapiServiceName=mongodb");
            //dbClient.DropDatabase("DDDshop");
            database = dbClient.GetDatabase("DDDshop");
            database.DropCollection("products");
            collection = database.GetCollection<Order>("orders");
        }

        public void Add(Order o)
        {
            collection.InsertOne(o);
        }

        public void Delete(int id)
        {
            collection.DeleteOne(order => order.Id == id);
        }

        public Order Find(int id)
        {
            return collection.Find<Order>(order => order.Id == id).FirstOrDefault();
        }

        public IList<Order> FindAll()
        {
            return collection.Find<Order>(order => true).ToList<Order>();
        }

        public IList<Order> GetPage(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
