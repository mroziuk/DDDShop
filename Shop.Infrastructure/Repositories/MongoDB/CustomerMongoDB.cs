using MongoDB.Driver;
using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Repositories
{
    class CustomerMongoDB : ICustomerRepository
    {
        private MongoClient dbClient;
        private IMongoDatabase database;
        private IMongoCollection<Customer> collection;
        public CustomerMongoDB()
        {
            dbClient = new MongoClient("mongodb://127.0.0.1:27017/?compressors=disabled&gssapiServiceName=mongodb");
            //dbClient.DropDatabase("DDDshop");
            database = dbClient.GetDatabase("DDDshop");
            database.DropCollection("customers");
            collection = database.GetCollection<Customer>("customers");
            for (int i = 0; i < 5; i++)
            {
                Customer c = new Customer(i, "Customer "+i,"lastname", "email@email.email","1234", DateTime.Now);
                collection.InsertOne(c);
            };
        }
        public void Add(Customer c)
        {
            collection.InsertOne(c);
        }

        public void Delete(int id)
        {
            collection.DeleteOne(customer => customer.Id == id);
        }

        public Customer Find(int id)
        {
            return collection.Find<Customer>(customer => customer.Id == id).FirstOrDefault();
        }

        public IList<Customer> FindAll()
        {
            return collection.Find(customer => true).ToList<Customer>();
        }
    }
}
