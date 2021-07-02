using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Model.Product.Repositories
{
    public interface IBrandRepository
    {
        public IList<Brand> FindAll();
        public void Add(Brand p);
        public Brand Find(int id);
        public void Delete(int id);
    }
}
