# Shop Application
Shop application with different ways of accesing database (SQL and NHibernate, LinqToSQl, MongoDB) Presentation layer in ASP.NET Core
## Structure
* Application
  * CustomerService
  * IdentityService
  * ShopService
  * ProductService
* Domain
  * Exceptions
  * Models
    * Product
    * Order
    * Customer
  * Specification
* Infrastructure
  * Repositories
    * InMemory
    * MongoDb
    * NHibernate

## Interfaces
### ConsoleApp
Simple text program to show basic shop operations. Connected to NHibernate Repository. You can show all products, filter by brand, 
### TransportApi
Tests for connecting app to Transport Application

```Get()``` gets order with customerEmail, address from and address to

```Post()``` creates Delivery Data Transfer Object and send it by api
### WebApplication
ASP.NET web app for accesing shop service.

Implemented Products presentation list for guests and logged users, editing for admins, Login and Register page, adding products to cart, selecting address and placeing order. Set up with local SQL server.

If Transport App is running orders with address and customer data are sent.

## Datebase
### Nhibernate
to connect application to local or remote sql server change ```Data Source``` to server name ane ```Initial Catalog``` to database name in ```hibernate.cfg.xml``` file
### creating tables
```sql
create table Address
(
	ID int primary key identity,
	City varchar(30),
	Street varchar(30),
	Number int,
	Country varchar(30),

)
create table Customer
(
	ID int primary key identity,
	FirstName varchar(64),
	LastName varchar(64),
	Email varchar(64),
	Password varchar(64),
	CreatedAccount datetime,
	AddressId int references Address(ID)
)
create table Brand
(
	ID int primary key identity,
	Name varchar(30),
	Description varchar(50)
)
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
create table Orders
(
	ID int primary key identity,
	CustomerId int,
	CreatedTime	DateTime,
	DeliveryType int,
	PaymentType varchar(30)
)
```
example data in folder ```Queries```
### MongoDB
to connect mongoDb change ```<<YOUR ATLAS CONNECTION STRING>>``` to your connection string in```CustomerMongoDb.cs```, ```ProductMongoDB.cs```, ```OrderMongoDb.cs``` 
