using Shop.Domain.Model.Order;
using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Order.Repositories;

namespace Shop.Infrastructure.Repositories
{
    public class OrderIM : IOrderRepository
    {
        private List<Order> Orders = new List<Order>();


        public OrderIM()
        {
            Orders.Add(new Order { Id = 0, Customer = new Customer(), CreatedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") });
            Orders.Add(new Order { Id = 0, Customer = new Customer(), CreatedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") });
            Orders.Add(new Order { Id = 0, Customer = new Customer(), CreatedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") });
        }

        public void Add(Order o)
        {
            Orders.Add(o);
        }

        public void Delete(int id)
        {
            foreach (Order o in Orders)
            {
                if (o.Id == id)
                {
                    Orders.Remove(o);
                }
            }
        }

        public Order Find(int id)
        {
            foreach (Order o in Orders)
            {
                if (o.Id == id)
                {
                    return o;
                }
            }
            throw new KeyNotFoundException(id.ToString());
        }

        public IList<Order> FindAll()
        {
            return Orders;
        }

        public IList<Order> GetPage(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
