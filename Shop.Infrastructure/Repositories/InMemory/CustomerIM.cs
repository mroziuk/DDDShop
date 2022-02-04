using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Repositories
{
    public class CustomerIM : ICustomerRepository
    {
        private List<Customer> customers = new List<Customer>();
        public CustomerIM()
        {
            customers.Add(new Customer(0, "Marek", "Markowski", "marek@gmail.com","1234", DateTime.Now));
            customers.Add(new Customer(1, "Wacław","Wacławski", "waclaw@gmail.com","1234", DateTime.Now));
            customers.Add(new Customer(2, "Kuba","Kubacki", "jakub@gmail.com","1234", DateTime.Now));
        }
        public IList<Customer> FindAll()
        {
            return customers;
        }

        public void Add(Customer c)
        {
            customers.Add(c);
        }

        public void Delete(int id)
        {
            foreach (Customer c in customers)
            {
                if (c.Id == id)
                {
                    customers.Remove(c);
                    return;
                }
            }
        }

        public Customer Find(int id)
        {
            foreach (var c in customers)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            //throw new KeyNotFoundException(id.ToString());
            return null;
        }
    }
}
