using NHibernate;
using Shop.Domain.Model.Product;
using Shop.Domain.Model.Product.Repositories;
using Shop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Infrastructure.Repositories
{
    public class ProductNH : RepositoryShema<Product>, IProductRepository, IProductFiltering
    {
        public IList<Product> FilterProductsBrand(string _brand)
        {
            using (ISession s = OpenSession())
            {
                IList<Product> result = s.Query<Product>()
                .Where(c => c.Brand.Name == _brand)
                .ToList();
                return result;
            }
        }

        public IList<Product> FilterProductsCategory(string _category)
        {
            using (ISession s = OpenSession())
            {
                IList<Product> result = s.Query<Product>()
                .Where(c => c.Category == _category)
                .ToList();
                return result;
            }
        }

        public IList<Product> FilterProductsPriceGreaterThat(int _price)
        {
            using (ISession s = OpenSession())
            {
                IList<Product> result = s.Query<Product>()
                .Where(c => c.Price > _price)
                .ToList();
                return result;
            }
        }

        public IList<Product> FilterProductsPriceLessThat(int _price)
        {
            using (ISession s = OpenSession())
            {
                IList<Product> result = s.Query<Product>()
                .Where(c => c.Price < _price)
                .ToList();
                return result;
            }
        }
    }
}
