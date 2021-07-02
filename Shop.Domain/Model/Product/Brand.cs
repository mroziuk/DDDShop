using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Model.Product
{
    public class Brand
    {
        public Brand(int id, string name) : base()
        {
            Id = id;
            Name = name;
        }
        public Brand() { Products = new HashSet<Product>(); }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ISet<Product> Products { get; set; }
    }
}
