using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Shop.Domain.Model.Product
{
    public class ProductMapping : ClassMapping<Product>
    {
        public ProductMapping()
        {
            Id(e => e.Id, g => g.Generator(Generators.Identity));
            Property(e => e.Name);
            Property(e => e.Price);
            Property(e => e.Brand);
            Property(e => e.Description);
            Property(e => e.Category);
            Property(e => e.Size);
            Property(e => e.Color);
        }
    }
}
