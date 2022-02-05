using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Customer.Repositories;
using Shop.Infrastructure.Repositories.NHibernate;

namespace WebAppTests
{
    [TestClass]
    public class UnitTest1
    {
        AddressNH addressRepository = new AddressNH();
        [TestMethod]
        public void TestMethod1()
        {
            Address address = new Address()
            {
                Country = "Polska",
                City = "Czernica",
                Street = "Spokojna",
                Number = 2,
            };
            Assert.AreEqual(addressRepository.GetId(address), 3);
        }
    }
}
