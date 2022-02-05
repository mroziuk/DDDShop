
drop table if exists Product;
go
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
--c##############################################

drop table if exists Property;
go
--c##############################################
drop table if exists Product;
go

create table Product
(
	ID int primary key identity(1,1),
	Name varchar(30),
	Price int,
	Description varchar(50),
	Category varchar(50),
	Size varchar(50),
	Color varchar(50),
	BrandId int references Brand(ID)
)
go
INSERT INTO Product (Category,Name,Price, Description, BrandId)
VALUES	('Odzie¿','Buty',100,'turystyczne',3),
		('Odzie¿','Buty',200,'gorskie',3),
		('Odzie¿','Spodnie',300,'turystyczne',2),
		('Odzie¿','Buty',400,'turystyczne',3),
		('Odzie¿','Buty',500,'gorskie',1),
		('Odzie¿','Spodnie',600,'turystyczne',2),
		('Odzie¿','Buty',700,'turystyczne',1),
		('Odzie¿','Rêkawiczki',800,'gorskie',1),
		('Sprzet','Kije Trekingowe',900,'turystyczne',2),
		('Sprzet','Stuptuty',1000,'turystyczne',1),
		('Sprzet','Raki',1100,'gorskie',1),
		('Sprzet','Raczki',1200,'gorskie',1),
		('Sprzet','Czekan',1300,'turystyczne',2);
		
Go
SELECT * FROM Product;
GO

delete
from Product
where Price = 0