use EmployeeManagementDB;

select * from Employees;

SELECT 
    e.EmpName,
    d.DeptName,
    e.Salary
FROM Employees e
LEFT JOIN Departments d
ON e.DeptID = d.DeptID;

