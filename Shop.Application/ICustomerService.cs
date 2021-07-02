using Shop.Domain.Model.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application
{
    public interface ICustomerService
    {
        void AddNewCustomer(Customer c);
        //void SetCustomerAddress(Customer c, Address a);
        void SetCustomerEmail(Customer c, string e);
        IList<Customer> GetAllCustomers();
    }
}
