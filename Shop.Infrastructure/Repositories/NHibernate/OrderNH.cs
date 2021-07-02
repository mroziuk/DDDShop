using Shop.Domain.Model.Order;
using Shop.Domain.Model.Order.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Repositories.NHibernate
{
    public class OrderNH :RepositoryShema<Order>, IOrderRepository
    {
     
    }
}
