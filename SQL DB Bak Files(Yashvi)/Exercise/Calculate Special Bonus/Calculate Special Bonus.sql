use DBLeetCode2;

CREATE TABLE Employees3 (
    employee_id INT PRIMARY KEY,
    name VARCHAR(255),
    salary INT
);

INSERT INTO Employees3 (employee_id, name, salary) VALUES
(2, 'yashvi', 3000),
(3, 'Arya', 3800),
(7, 'jahi', 7400),
(8, 'shivu', 6100),
(9, 'dhyey', 7700);

select * from Employees3;

SELECT employee_id,
    CASE WHEN employee_id % 2 != 0 AND LEFT(name, 1) != 'M' THEN salary
        ELSE 0
    END AS bonus
FROM Employees3 ORDER BY employee_id;

