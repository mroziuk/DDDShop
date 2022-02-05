using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        int id;
        public ProductNotFoundException(int _id) :base(string.Format("product of id {0} dont exist", _id))
        {
            id = _id;
        }
        
    }
}
