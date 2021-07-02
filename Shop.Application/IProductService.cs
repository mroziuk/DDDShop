using Shop.Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application
{
    public interface IProductService
    {
        void AddNewProduct(Product p);
        void SetBrand(Product p, Brand b);
        //void AddProperty(Product p, Property prop);
        IList<Product> GetAllProducts();
    }
}
