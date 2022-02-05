using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.WebApplication.Models
{
    public class Cart
    {
        public Order order;
        public Address addressFrom;
        public Address addressTo;
        public int addressToId;
        public Cart()
        {
            order = new Order();
            addressTo = new Address();
            addressFrom = new Address()
            {
                Country = "cudowny kraj",
                City = "Najwspanialsze miasto",
                Street = "Ulica ze sklepem",
                Number = 420,
            };
        }
    }
}
