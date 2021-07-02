using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Model.Customer
{
    public class Address
    {
        public Address(int id, string city, string street, int number, string country)
        {
            Id = id;
            City = city;
            Street = street;
            Number = number;
            Country = country;
        }
        public Address()
        {
            Customers = new HashSet<Customer>();
        }
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Country { get; set; }
        public ISet<Customer> Customers { get; set; }
    }
}
