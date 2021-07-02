drop table if exists Orders
go
create table Orders
(
	ID int primary key identity,
	product_id int,
	CustomerId int,
	CreatedTime	DateTime,
	DeliveryType int,
	PaymentType varchar(30)
)
go

SELECT * FROM Orders;
GO