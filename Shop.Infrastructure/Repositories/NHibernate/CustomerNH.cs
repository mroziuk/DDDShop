using NHibernate;
using NHibernate.Criterion;
using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Infrastructure.Repositories.NHibernate
{
    public class CustomerNH : RepositoryShema<Customer>, ICustomerRepository
    { 
        public Customer WithEmail(string email)
        {
            using(ISession s = OpenSession())
            {
                return s.CreateCriteria<Customer>()
                    .Add(Restrictions.Eq("Email", email))
                    .SetMaxResults(1)
                    .List<Customer>()
                    .FirstOrDefault();
            }
        }
    }
}
