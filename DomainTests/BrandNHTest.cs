using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Text;
using Shop.Infrastructure.Repositories;

namespace DomainTests 
{

    [TestClass]
    public class BrandNHTest 
    { 
        [TestMethod]
        public void FindTest()
        {
            RepositoryShema<Brand> repo = new RepositoryShema<Brand>();
            Brand nike = new Brand { Id = 1, Name = "Nike", Description = "lalalal" };
            Brand found = repo.Find(1);
            Assert.AreEqual(nike.Id, found.Id);
            Assert.AreEqual(nike.Name, found.Name);
            Assert.AreEqual(nike.Description, found.Description);
        }
        [TestMethod]
        public void AddTest()
        {
            RepositoryShema<Brand> repo = new RepositoryShema<Brand>();
            Brand BlackDiamond = new Brand { Name = "BlackDiamond", Description = "climbing gear" };
            Assert.IsNull(repo.Find(4));
            repo.Add(BlackDiamond);
            Assert.IsNotNull(repo.Find(4));
        }
        [TestMethod]
        public void DeleteTest()
        {
            RepositoryShema<Brand> repo = new RepositoryShema<Brand>();
            Brand naturhike = new Brand {Name = "NaturHike", Description = "tents" };
            repo.Add(naturhike);
            Assert.IsNotNull(repo.Find(5));
            repo.Delete(5);
            Assert.IsNull(repo.Find(5));
        }
    }
}
