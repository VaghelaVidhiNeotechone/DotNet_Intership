use EmployeeManagementDB;

select * from Employees;

SELECT E1.EmpName AS Employee
FROM Employees E1
JOIN Employees E2 ON E1.DeptID = E2.DeptID
WHERE E1.Salary > E2.Salary;