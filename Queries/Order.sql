drop table if exists OrderProduct
go
drop table if exists Orders
go

create table Orders
(
	ID int primary key identity,
	CustomerId int,
	CreatedTime	DateTime,
	DeliveryType int,
	PaymentType varchar(30)
)
go


create table OrderProduct
(
	OrderID int references Orders(ID),
	ProductID int references Product(ID),
)
SELECT * FROM Product;
SELECT * FROM Orders;
SELECT * FROM OrderProduct
GO

DELETE
FROM Orders