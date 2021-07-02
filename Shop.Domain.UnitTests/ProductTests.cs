using Shop.Application;
using Shop.Domain.Model.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Model.Product;
using Shop.Domain.Model.Product.Repositories;
using Shop.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectMothers;
namespace Shop.Domain.UnitTests
{
    [TestClass]
    class ProductTests
    {
        private IProductRepository productRepository = new ProductIM();
        [TestMethod]
        public void AddItem()
        {
            Product p = ProductObjectMother.CreateProductWithNameOnly();
            productRepository.Add(p);
            bool result = productRepository.Find(0) == null;

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DeleteItem()
        {
            Assert.AreEqual(1, 2);
        }
    }
}
