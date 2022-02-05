using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Mapping.ByCode;
using Shop.Domain.Model;
using Shop.Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Repositories
{
    public class RepositoryShema<T> : IRepository<T> where T : class
    {
        protected static ISession OpenSession()
        {
            return new Configuration().Configure().BuildSessionFactory().OpenSession();
        }
        public void Add(T p)
        {
            using (var s = OpenSession())
            {
                s.SaveOrUpdate(p);
                s.Flush();
            }
        }
        public void Delete(int id)
        {
            using (var s = OpenSession())
            {
                var queryString = string.Format("delete {0} where Id = :id",
                                        typeof(T));
                s.CreateQuery(queryString)
                       .SetParameter("id", id)
                       .ExecuteUpdate();
            }
        }

        public T Find(int id)
        {
            using (ISession s = OpenSession())
            {
                return s.Get<T>(id);
            }
        }
        public IList<T> FindAll()
        {
            using (ISession s = OpenSession())
            {
                var queryString = string.Format("from {0} ",typeof(T));
                IQuery q = s.CreateQuery(queryString);
                IList<T> result = q.List<T>();
                return result;
            }
        }

        public IList<T> GetPage(int pageNumber, int pageSize)
        {
            using (ISession s = OpenSession())
            {
                return s.CreateCriteria<T> ()
                .AddOrder(Order.Asc("Id"))
                .SetFirstResult((pageNumber - 1) * pageSize)
                .SetMaxResults(pageSize)
                .List<T>();
            }
        }
    }
}
