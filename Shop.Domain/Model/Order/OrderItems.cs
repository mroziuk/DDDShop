using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Model.Product;

namespace Shop.Domain.Model.Order
{
    public class OrderItems
    {
        public int Id { get; set; }
        public Product.Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
