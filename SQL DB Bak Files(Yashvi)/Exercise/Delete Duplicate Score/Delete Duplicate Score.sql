use EmployeeManagementDB;

select * from Employees;

DELETE FROM Employees WHERE EmpID NOT IN(SELECT MIN(EmpID) FROM Employees GROUP BY Score)
