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

namespace Shop.Infrastructure.Repositories
{
    public class BrandNH :RepositoryShema<Brand>, IBrandRepository
    {
       
    }
}
