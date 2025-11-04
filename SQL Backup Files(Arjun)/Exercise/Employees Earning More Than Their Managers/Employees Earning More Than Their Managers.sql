--CREATE TABLE Employees (
--    id INT PRIMARY KEY,
--    name VARCHAR(50),
--    salary INT,
--    managerId INT
--);

--INSERT INTO Employees (id, name, salary, managerId) VALUES
--(1, 'Joe', 70000, 3),
--(2, 'Henry', 80000, 4),
--(3, 'Sam', 60000, NULL),
--(4, 'Max', 90000, NULL);

--select * from employees;


SELECT e.name AS Employees
FROM Employees e
JOIN Employees m ON e.managerId = m.id
WHERE e.salary > m.salary;