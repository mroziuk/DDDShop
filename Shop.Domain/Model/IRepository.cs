using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Model
{
    public interface IRepository<T>
    {
        public IList<T> FindAll();
        public void Add(T x);
        public void Delete(int id);
        public T Find(int id);
        public IList<T> GetPage(int pageNumber, int pageSize);
    }
}
