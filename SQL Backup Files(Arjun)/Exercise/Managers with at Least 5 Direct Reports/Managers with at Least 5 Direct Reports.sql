create table EmpReport(
id INT PRIMARY KEY,
name VARCHAR(50),
department VARCHAR(50),
managerId INT
);



insert into EmpReport values
(101, 'John', 'A', NULL),
(102, 'Dan', 'A', 101),
(103, 'James', 'A', 101),
(104, 'Amy', 'A', 101),
(105, 'Anne', 'A', 101),
(106, 'Ron', 'B', 101);


select * from EmpReport;



SELECT e1.name
FROM EmpReport e1
JOIN EmpReport e2
  ON e1.id = e2.managerId
GROUP BY e1.id, e1.name
HAVING COUNT(e2.id) >= 5;
