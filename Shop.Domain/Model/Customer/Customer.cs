using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Model.Customer
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAccount { get; set; }
        public Address Address { get; set; }
        public Customer(int id, string fullName, string email, DateTime createdAccount)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            CreatedAccount = createdAccount;
        }
        public Customer()
        {
        }
    }
}
