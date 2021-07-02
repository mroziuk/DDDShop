using Shop.Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Specification
{
    public interface IProductFiltering
    {
        public IList<Product> FilterProductsCategory(string _category);
        public IList<Product> FilterProductsBrand(string _brand);
        public IList<Product> FilterProductsPriceGreaterThat(int _price);
        public IList<Product> FilterProductsPriceLessThat(int _price);
    }
}
