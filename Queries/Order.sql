drop table if exists Orders
go
drop table if exists OrderProduct
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
	OrderID int ,
	ProductID int,
)
SELECT * FROM Orders;
GO