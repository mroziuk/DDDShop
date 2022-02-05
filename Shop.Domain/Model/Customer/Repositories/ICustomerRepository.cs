using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Model.Customer.Repositories
{
    public interface ICustomerRepository
    {
        public IList<Customer> FindAll();
        public void Delete(int id);
        public Customer Find(int id);
        public Customer WithEmail(string email);
        public void Add(Customer c);
    }
}
