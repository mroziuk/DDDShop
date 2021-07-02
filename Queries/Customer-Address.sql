drop table if exists Address;
go
create table Address
(
	ID int primary key identity,
	City varchar(30),
	Street varchar(30),
	Number int,
	Country varchar(30)
)
go
INSERT INTO Address (City, Street,Number,Country)
VALUES	('Wroclaw', 'Grunwaldzka',123,'Polska'),
		('Wroclaw', 'Bardzka',44,'Polska'),
		('Czernica', 'Spokojna',2,'Polska'),
		('Gdansk', 'Dmowskiego',441,'Polska'),
		('Gdansk', 'Matejki',2,'Polska');

SELECT * FROM Address;
GO
--#######################

drop table if exists Customer;
go
create table Customer
(
	ID int primary key identity,
	FullName varchar(50),
	Email varchar(50),
	CreatedAccount datetime,
	AddressId int
)
go
INSERT INTO Customer (FullName, Email,CreatedAccount,AddressId)
VALUES	('Marek Markowski', 'marek@markowski.com','2007-05-08 12:35:29.123',1),
		('Piotr Piotrowski', 'piotr.piotrowski@gmail.com','2020-05-08 12:35:29.123',2),
		('Kuba Wiatrowski', 'kwiatrowski@o2.pl','2020-05-13 12:35:29.123',4),
		('Maciej Ryba', 'mryba@rybak.com','2020-02-13 12:35:29.123',5);
		

SELECT * FROM Customer;
GO