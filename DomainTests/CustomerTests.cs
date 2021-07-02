using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectMothers;
using Shop.Domain.Model.Customer;
using Shop.Infrastructure.Repositories;

namespace DomainTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void InsertTest()
        {
            var customerRepository = new CustomerIM();
            Customer c = CustomerObjectMother.CreateCustomer();
            customerRepository.Add(c);
            bool result = customerRepository.Find(99) == null;

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DeleteTest()
        {
            var customerRepository = new CustomerIM();
            Customer c = CustomerObjectMother.CreateCustomer();
            customerRepository.Add(c);
            customerRepository.Delete(99);
            bool result = customerRepository.Find(99) == null;

            // Assert
            Assert.IsTrue(result);
        }
    }
}
