use DBLeetCode2;

CREATE TABLE Employees6 (
    employee_id INT PRIMARY KEY,
    employee_name VARCHAR(255),
    manager_id INT NULL,
    salary INT,
    department VARCHAR(255),
    FOREIGN KEY (manager_id) REFERENCES Employees6(employee_id)
);

INSERT INTO Employees6 (employee_id, employee_name, manager_id, salary, department) VALUES
(1, 'yashvi', NULL, 12000, 'Executive'),
(2, 'arya', 1, 10000, 'Sales'),
(3, 'jahi', 1, 10000, 'Engineering'),
(4, 'jiya', 2, 7500, 'Sales'),
(5, 'hetv', 2, 7500, 'Sales'),
(6, 'dev', 3, 9000, 'Engineering'),
(7, 'priya', 3, 8500, 'Engineering'),
(8, 'nency', 4, 6000, 'Sales'),
(9, 'tyla', 6, 7000, 'Engineering'),
(10, 'shivu', 6, 7000, 'Engineering');

select * from Employees6;

WITH levelCTE AS (
    SELECT employee_id, employee_name, 1 AS level, salary
    FROM Employees6 
    WHERE manager_id  IS NULL
    UNION ALL 
    SELECT  E.employee_id, E.employee_name, level + 1 AS level, e.salary
    FROM levelCTE C
    INNER JOIN Employees6 E
    ON C.employee_id = E.manager_id 
),
teamSizeCTE AS 
(
    SELECT employee_id AS root, employee_id AS subordinate, salary
    FROM Employees6
    UNION ALL 
    SELECT T.root, E.employee_id, E.salary
    FROM teamSizeCTE T
    INNER JOIN Employees6 E
    ON E.manager_id = t.subordinate
)
SELECT l.employee_id, l.employee_name, l.level, COUNT(T.subordinate) - 1 AS team_size, SUM(T.salary) AS budget
FROM levelCTE AS L
INNER JOIN teamSizeCTE T
ON T.root = L.employee_id
GROUP BY l.employee_id, l.employee_name, l.level
ORDER BY l.level ASC, budget DESC, l.employee_name ASC;