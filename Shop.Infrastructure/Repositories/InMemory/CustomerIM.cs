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
            customers.Add(new Customer(0, "Marek", "marek@gmail.com", DateTime.Now));
            customers.Add(new Customer(1, "Wacław", "waclaw@gmail.com", DateTime.Now));
            customers.Add(new Customer(2, "Kuba", "jakub@gmail.com", DateTime.Now));
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
