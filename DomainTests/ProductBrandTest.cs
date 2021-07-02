using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using Shop.Domain.Model.Product;
using System;
using System.Collections.Generic;
using Shop.Infrastructure.Repositories;
using Shop.Domain.Model.Product.Repositories;
using Shop.Domain.Model.Customer;

namespace DomainTests
{
    [TestClass]
    public class ProductBrandTest
    {
        private IProductRepository productRepository = new ProductNH();
        private IBrandRepository brandRepository = new BrandNH();
        static ISession OpenSession()
        {
            return new Configuration().Configure().BuildSessionFactory().OpenSession();
        }
        [TestMethod]
        public void CreateProductWithBrand()
        {
            IList<Product> products = new List<Product>();
            IList<Brand> brands = new List<Brand>();
            using (ISession s = OpenSession())
            {
                var queryString = string.Format("from {0} ", typeof(Brand));
                IQuery q = s.CreateQuery(queryString);
                brands = q.List<Brand>();

                queryString = string.Format("from {0} ", typeof(Product));
                q = s.CreateQuery(queryString);
                products = q.List<Product>();
            }
            using (var s = OpenSession())
            {
                Brand b = new Brand {Name = "brand1", Description="some text" };
                Product p1 = new Product { Name = "product1",Color = "black", Category="cat1", Description="desc", Size="M", Price = 323 };
                Product p2 = new Product { Name = "product1",Color = "black", Category="cat1", Description = "desc", Size="M", Price = 323 };
                p1.Brand = b;
                p2.Brand = b;
                s.SaveOrUpdate(p1);
                s.SaveOrUpdate(p2);
                s.Save(b);
                s.Flush();
                
            }
            using (var s = OpenSession())
            {
                var result = from e in s.Query<Brand>() select e;
                Console.WriteLine(result);
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddBrandToProduct()
        {
            //Address a = new Address { City = "city1", Country = "country1", Street = "street1", Number = 1 };
            //Customer c1 = new Customer { FullName = "customer1", Email = "email1" };
            //Customer c2 = new Customer { FullName = "customer2", Email = "email2" };
            
        }
    }
}
