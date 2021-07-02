using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Repositories.NHibernate
{
    public class CustomerNH : RepositoryShema<Customer>, ICustomerRepository
    {
    }
}
