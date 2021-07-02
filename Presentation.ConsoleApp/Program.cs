using System;
using Shop.Application;
using Shop.Domain.Model.Product;
using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Product.Repositories;
using Shop.Infrastructure.Repositories;
using NHibernate;
using NHibernate.Cfg;
using System.Collections.Generic;
using Shop.Domain.Model.Order;

namespace Presentation.ConsoleApp
{
    class Program
    {
        public static void ShowResult(IList<Product> list)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            ShopService shop = new ShopService();
            ProductNH repo = new ProductNH();
            //foreach (var p in shop.GetAllProducts())
            //{
            //    Console.WriteLine(String.Format("product id {0}, product name: {1}", p.Id, p.Name));
            //}

            //shop.AddNewCustomer(new Customer { FullName = "John", CreatedAccount = new DateTime(2019,02,13, 12,35,29,123)});
            ////shop.AddNewCustomer(new Customer { FullName = "John I", Address = 2 });
            ////shop.AddNewCustomer(new Customer { FullName = "John III", Address = 1 });
            //foreach (var c in shop.GetAllCustomers())
            //{
            //    Console.WriteLine(String.Format("Customer id {0}, Customer name: {1}", c.Id, c.FullName));
            //}
            //foreach (var b in shop.GetBrands())
            //{
            //    Console.WriteLine(String.Format("Brand id {0}, Brand name: {1} {2}\n", b.Id, b.Name, b.Description));
            //}
            //for (int i = 0; i < 4; i++)
            //{
            //    foreach (var item in shop.GetProductPage(i + 1, 4))
            //    {
            //        Console.WriteLine(item);
            //    }
            //    Console.WriteLine("");
            //}
            IList<Product> result = new List<Product>();
            IList<Product> cart = new List<Product>();
            string[] query = { "", "" };
            Order order = new Order();
            //Customer customer = shop.GetAllCustomers()[0];
            while (query[0] != "exit")
            {
                query = Console.ReadLine().Split();
                switch (query[0])
                {
                    case "exit": break;
                    case "all": result = shop.GetAllProducts(); break;
                    case "brand": result = shop.productRepository.FilterProductsBrand(query[1]); break;
                    case "less": result = shop.productRepository.FilterProductsPriceLessThat(int.Parse(query[1])); break;
                    case "greater": result = shop.productRepository.FilterProductsPriceGreaterThat(int.Parse(query[1])); break;
                    case "add": cart.Add(result[int.Parse(query[1])]); break;
                    //case "push":
                    //    {
                    //        order = new Order();
                    //        shop.AddCustomerToOrder(order, customer);
                    //        foreach (var item in cart)
                    //        {
                    //            shop.AddProductToOrder(order, item);
                    //        }
                    //        shop.AddNewOrder(order);
                    //        cart.Clear();
                    //        break;
                    //    }
                    case "cart":
                        {
                            Console.WriteLine("cart:");
                            ShowResult(cart);
                            break;
                        }
                }
                Console.WriteLine("products:");
                ShowResult(result);
            }
        }
    }
}
