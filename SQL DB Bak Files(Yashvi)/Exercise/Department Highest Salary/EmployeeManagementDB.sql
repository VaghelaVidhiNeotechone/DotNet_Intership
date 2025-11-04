use EmployeeManagementDB;

select * from Employees;

select * from Departments;

select dp.DeptName as Department, em.EmpName as Employee, em.Salary
from Employees as em join Departments as dp 
on em.DeptID = dp.DeptID 
where em.salary = ( select max(salary) from Employees where DeptID = dp.DeptID )