using Shop.Domain.Model.Product;
using System;

namespace ObjectMothers
{
    public class ProductObjectMother
    {
        public static Product CreateProductWithNameOnly()
        {
            Product p = new Product(99, "TestProduct");
            return p;
        }
        public  static Brand CreateBrand()
        {
            Brand b = new Brand(0, "TestBrand");
            return b;
        }
    }
}
