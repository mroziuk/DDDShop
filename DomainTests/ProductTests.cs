using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectMothers;
using Shop.Domain.Model.Product;
using Shop.Infrastructure.Repositories;

namespace DomainTests
{
    [TestClass]
    public class ProductTests
    {

        [TestMethod]
        public void InsertTest()
        {
            var productRepository = new ProductIM();
            Product p = ProductObjectMother.CreateProductWithNameOnly();
            productRepository.Add(p);
            bool result = productRepository.Find(99) == null;

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DelteTest()
        {
            var productRepository = new ProductIM();
            Product p = ProductObjectMother.CreateProductWithNameOnly();
            productRepository.Add(p);
            bool isInserted = productRepository.Find(99) != null;
            //Assert.IsTrue(isInserted);
            productRepository.Delete(99);
            isInserted = productRepository.Find(99) != null;
            Assert.IsFalse(isInserted);
        }

        [TestMethod]
        public void InsertTestMongoDB()
        {
            var productRepository = new ProductMongoDB();
            Product p = ProductObjectMother.CreateProductWithNameOnly();
            productRepository.Add(p);
            bool result = productRepository.Find(99) == null;

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DelteTestMongoDB()
        {
            var productRepository = new ProductMongoDB();
            Product p = ProductObjectMother.CreateProductWithNameOnly();
            productRepository.Add(p);
            bool isInserted = productRepository.Find(99) != null;
            //Assert.IsTrue(isInserted);
            productRepository.Delete(99);
            isInserted = productRepository.Find(99) != null;
            Assert.IsFalse(isInserted);
        }
        [TestMethod]
        public void FindAllTestsMongoDB()
        {
            var productRepository = new ProductMongoDB();
            Assert.AreEqual(productRepository.FindAll().Count, 5);
        }
        [TestMethod]
        public void PagingTest()
        {
            var repo = new ProductNH();

        }
    }
}
