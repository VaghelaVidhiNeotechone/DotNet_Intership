--create table Customers
--(
--id int primary key,
--name varchar(50)
--);

--insert into Customers values 
--(1,'Joe'),
--(2,'Henry'),
--(3,'Sam'),
--(4,'Max');

--select * from Customers;


--create table Orders
--(
--id int primary key,
--customerId int
--);

--insert into Orders values
--(1,3),
--(2,1);

--select * from Orders;

SELECT c.name AS Customers
FROM Customers c
LEFT JOIN Orders o 
  ON c.id = o.customerId
WHERE o.customerId IS NULL;