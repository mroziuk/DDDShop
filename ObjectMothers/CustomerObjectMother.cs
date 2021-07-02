using Shop.Domain.Model.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectMothers
{
    public class CustomerObjectMother
    {
        public static Customer CreateCustomer()
        {
            Customer c = new Customer
            {
                Id = 99,
                FullName = "fulltestname",
                Email = "email.gmail.com",
                CreatedAccount = DateTime.Now
            };
            return c;
        }
        public static Customer CreateCustomerNoEmail()
        {
            Customer c = new Customer
            {
                Id = 0,
                FullName = "fulltestname",
                CreatedAccount = DateTime.Now
            };
            return c;
        }
        public static Address CreateValidAdress()
        {
            Address a = new Address(0, "City", "Street", 4, "San Escobar");
            return a;
        }
    }
}
