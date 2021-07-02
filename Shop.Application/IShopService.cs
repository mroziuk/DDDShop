using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application
{
    public interface IShopService
    {
        void AddNewOrder(Order o);
        //OrderProducts CreateNewOrderItem(Product p, int quantity);
        // AddPropertyToOrderItems(OrderProducts o, Property p);
        void AddProductToOrder(Order o, Product p);
        void AddCustomerToOrder(Order o, Customer c);
        //void AddOrderItemsToOrder(Order o, OrderProducts oi);
        void ChooseDeliveryType(Order o, string d);
        void ChoosePaymentType(Order o, string p);
        IList<Order> GetAllOrders();
    }
}
