use DBLeetCode2;

CREATE TABLE Employees2 (
    employee_id INT PRIMARY KEY,
    name VARCHAR(255),
    reports_to INT NULL,
    age INT
);

INSERT INTO Employees2 (employee_id, name, reports_to, age) VALUES
(9, 'Hercules', NULL, 43),
(6, 'Quasimodo', 9, 15),
(3, 'Godzilla', 9, 41),
(5, 'Esmeralda', 9, 21),
(1, 'Alice', 6, 61),
(4, 'Bob', 6, 23),
(2, 'Marie', 1, 55),
(7, 'Monsters', 1, 24);

select * from Employees2

select e1.employee_id,e1.name,count(e2.reports_to) reports_count,round(avg(e2.age*1.00),0) average_age
from employees2 e1 inner join employees2 e2 on e2.reports_to=e1.employee_id
group by e1.employee_id,e1.name order by e1.employee_id