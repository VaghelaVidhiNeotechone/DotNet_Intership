use DBLeetCode2;

CREATE TABLE Employees5 (
    employee_id INT PRIMARY KEY,
    name VARCHAR(255),
    manager_id INT NULL,
    salary INT
);

INSERT INTO Employees5 (employee_id, name, manager_id, salary) VALUES
(3, 'yashvi', 9, 60301),
(12, 'arya', NULL, 31000),
(13, 'Jahi', NULL, 67084),
(1, 'jiva', 11, 21241),
(9, 'shivu', NULL, 50937),
(11, 'jiya', 6, 28485);

select * from Employees5;

SELECT E.employee_id
FROM Employees5 E
LEFT JOIN Employees5 M ON E.manager_id = M.employee_id
WHERE E.salary < 30000 AND E.manager_id IS NOT NULL AND M.employee_id IS NULL
ORDER BY E.employee_id;
