use EmployeeManagementDB;

SELECT EmpID, Score FROM Employees;

SELECT DISTINCT e1.Score AS ConsecutiveNums
FROM Employees e1
JOIN Employees e2 
    ON e1.EmpID = e2.EmpID - 1
WHERE e1.Score = e2.Score;

