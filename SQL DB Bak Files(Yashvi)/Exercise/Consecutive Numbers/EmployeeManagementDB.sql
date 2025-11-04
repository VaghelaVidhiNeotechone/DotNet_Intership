use EmployeeManagementDB;

SELECT EmpID, Score FROM Employees;

SELECT DISTINCT l1.Score AS CONSECUTIVENUMS FROM Employees l1
JOIN Employees l2 ON l2.EmpID = l1.EmpID+1
JOIN Employees l3 ON l3.EmpID = l2.EmpID+1 
WHERE l1.Score =l2.Score AND l2.Score = l3.Score;
