using Shop.Domain.Model.Order;
using System;
using System.Collections.Generic;
using System.Text;
using ObjectMothers;

namespace ObjectMothers
{
    class OrderObjectMother
    {
        public static OrderItems CreateOdrerItems()
        {
            OrderItems items = new OrderItems();
            items.Id = 0;
            items.Product = ProductObjectMother.CreateProductWithNameOnly();
            items.Quantity = 2;
            return items;
        }
    }
}
