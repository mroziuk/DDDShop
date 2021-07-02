using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Model.Order;

namespace Shop.Domain.Model.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Brand Brand { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public ISet<Order.Order> Orders { get; set; }
        public Product(int _id, string _name) : this()
        {
            Id = _id;
            Name = _name;
        }
        public Product()
        {
            Orders = new HashSet<Order.Order>();
        }
        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}", Name, Price, Description, Category);
        }
    }
}
