use DBLeetCode2;

CREATE TABLE Employees4 (
    employee_id INT PRIMARY KEY,
    name VARCHAR(255)
);

CREATE TABLE Salaries (
    employee_id INT PRIMARY KEY,
    salary INT
);

INSERT INTO Employees4 (employee_id, name) VALUES
(2, 'Crew'),
(4, 'Haven'),
(5, 'Cris');

INSERT INTO Salaries (employee_id, salary) VALUES
(5, 76000),
(1, 22000),
(4, 19000);

select * from Employees4;
select * from Salaries;

SELECT employee_id
FROM Employees4
WHERE employee_id NOT IN (SELECT employee_id FROM Salaries)
UNION
SELECT employee_id
FROM Salaries
WHERE employee_id NOT IN (SELECT employee_id FROM Employees)
ORDER BY employee_id ASC;
