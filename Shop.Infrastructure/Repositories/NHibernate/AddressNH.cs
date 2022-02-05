using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Infrastructure.Repositories.NHibernate
{
    public class AddressNH : RepositoryShema<Address>, IAddressRepository
    {
        public int GetId(Address a)
        {
            int id;
            using(var s = OpenSession())
            {
                using(var tx = s.BeginTransaction())
                {
                    id = s.CreateQuery(string.Format(
                    @"SELECT Id
                    FROM Address
                    WHERE
                    Country = '{0}' and
                    City = '{1}' and
                    Street = '{2}' and
                    Number = {3}
                    ",
                    a.Country,
                    a.City,
                    a.Street,
                    a.Number
                    )).List<int>().FirstOrDefault();
                    tx.Commit();
                }
            }
            return id;
        }
    }
}
