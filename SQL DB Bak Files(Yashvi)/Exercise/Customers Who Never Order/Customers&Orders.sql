use EmployeeManagementDB;

select * from Customers;
select * from Orders;
select name as Customers from Customers where id not in (select customerId from orders);