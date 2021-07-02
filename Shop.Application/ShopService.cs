using Shop.Domain.Model.Product;
using Shop.Domain.Model.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Shop.Infrastructure.Repositories;
using Shop.Domain.Model.Customer.Repositories;
using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Order;
using Shop.Domain.Model.Order.Repositories;
using Shop.Infrastructure.Repositories.NHibernate;
//using Shop.Infrastructure.Hibernate;

namespace Shop.Application
{
    public class ShopService : IShopService, ICustomerService, IProductService
    {
        public ProductNH productRepository;
        private IOrderRepository orderRepository;
        private IBrandRepository brandRepository;

        private ICustomerRepository customerRepository;
        private IAddressRepository addressRepository;
        public ShopService()
        {
            //productRepository = new ProductIM();
            productRepository = new ProductNH();
            orderRepository = new OrderNH();
            brandRepository = new BrandNH();

            addressRepository = new AddressNH();
            customerRepository = new CustomerNH();
        }
        public IList<Product> GetProductPage(int PageNumber, int PageSize)
        {
            return productRepository.GetPage(PageNumber, PageSize);
        }
        public void AddNewCustomer(Customer c)
        {
            customerRepository.Add(c);
        }

        public void AddNewOrder(Order o)
        {
            orderRepository.Add(o);
        }

        public void AddNewProduct(Product p)
        {
            productRepository.Add(p);
        }

        //public void AddOrderItemsToOrder(Order o, OrderItems oi)
        //{
        //    o.OrderItems.Add(oi);
        //}

        public void AddProductToOrder(Order o, Product p)
        {
            if( p != null)
                o.OrderItems.Add(p);
        }
        public void ChooseDeliveryType(Order o, string d)
        {
            o.DeliveryType = d;
        }

        public void ChoosePaymentType(Order o, string p)
        {
            o.PaymentType = p;
        }

        public OrderItems CreateNewOrderItem(Product p, int quantity)
        {
            OrderItems oi = new OrderItems();
            oi.Product = p;
            oi.Quantity = quantity;
            return oi;
        }

        public IList<Customer> GetAllCustomers()
        {
            return customerRepository.FindAll();
        }

        public IList<Order> GetAllOrders()
        {
            return orderRepository.FindAll();
        }

        public IList<Product> GetAllProducts()
        {
            return productRepository.FindAll();
        }

        public void SetBrand(Product p, Brand b)
        {
            p.Brand = b;
        }

        //public void SetCustomerAddress(Customer c, Address a)
        //{
        //    c.Address = a;
        //}

        public void SetCustomerEmail(Customer c, string e)
        {
            c.Email = e;
        }
        public IList<Brand> GetBrands()
        {
            return brandRepository.FindAll();
        }

        public void AddCustomerToOrder(Order o, Customer c)
        {
            o.Customer = c;
        }
    }
}
