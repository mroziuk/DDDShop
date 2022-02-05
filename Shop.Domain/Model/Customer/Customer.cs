using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Model.Customer
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAccount { get; set; }
        public Address Address { get; set; }
        public Customer(int id, string firstName, string lastName, string email, string password, DateTime createdAccount)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreatedAccount = createdAccount;
        }
        public Customer()
        {
        }
        public void Validate()
        {
        }
    }
}
