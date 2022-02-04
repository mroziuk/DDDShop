using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Product;
using Shop.Domain.Model.Order.Repositories;

namespace Shop.Domain.Model.Order
{
    public class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<Product.Product>();
            DateTime myDateTime = DateTime.Now;
            CreatedTime = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
        public int Id { get; set; }
        // ISet<OrderProducts> OrderProducts { get; set; }
        public ISet<Product.Product> OrderProducts { get; set; }
        public Customer.Customer Customer { get; set; }
        public string CreatedTime { get; set; }
        public string DeliveryType { get; set; }
        public string PaymentType { get; set; }
    }
}
