using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Model.Product;
using Shop.Domain.Model.Product.Repositories;

namespace Shop.Infrastructure.Repositories
{
    public class ProductIM : IProductRepository
    {
        private List<Product> products = new List<Product>();
        public ProductIM()
        {
            //products = new IList<Product>();
            products.Add(new Product(0, "buty"));
            products.Add(new Product(1, "kurtka"));
        }

        public void Add(Product p)
        {
            products.Add(p);
        }

        public void Delete(int id)
        {
            foreach (var p in products)
            {
                if (p.Id == id)
                {
                    products.Remove(p);
                    return;
                }
            }
        }

        public Product Find(int id)
        {
            foreach (var p in products)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            //throw new KeyNotFoundException(id.ToString());
            return null;
        }

        public IList<Product> FindAll()
        {
            return products;
        }

        public IList<Product> GetPage(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
