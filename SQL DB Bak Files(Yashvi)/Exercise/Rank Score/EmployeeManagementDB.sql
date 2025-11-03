use EmployeeManagementDB;

select * from Employees ;

select Score, DENSE_RANK() OVER(ORDER BY score DESC) AS 'rank' from Employees;