/*
drop table if exists Brand;
go

create table Brand
(
	ID int primary key identity,
	Name varchar(30),
	Description varchar(50)
)
go
INSERT INTO Brand (Name, Description)
VALUES	('Nike', 'lalalal'),
		('Adidas', 'bububu'),
		('Puma', 'pupupup');

SELECT * FROM Brand;
GO
 */


using NHibernate;
using NHibernate.Cfg;
using Shop.Domain.Model.Product;
using Shop.Domain.Model.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure.Hibernate
{
    public class BrandNH : IBrandRepository
    {
        private ISession session;
        static ISession OpenSession()
        {
            return new Configuration().Configure().BuildSessionFactory().OpenSession();
        }
        public BrandNH()
        {
            session = new Configuration().Configure().BuildSessionFactory().OpenSession();
        }
        public void Add(Brand p)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Brand Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Brand> FindAll()
        {
            //return new List<Brand>();
            using (ISession s = OpenSession())
            {
                IQuery q = s.CreateQuery("from Brand as b order by b.Name");
                IList<Brand> result = q.List<Brand>();
                //Console.WriteLine("Znaleziono {0}", result.Count);
                //foreach (var j in result)
                //    Console.WriteLine(j.ToString());
                return result;
            }
        }
    }
}
