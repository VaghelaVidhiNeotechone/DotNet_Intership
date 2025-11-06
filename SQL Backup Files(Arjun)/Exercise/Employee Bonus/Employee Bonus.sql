create table EmpBonus(
empId INT PRIMARY KEY,
name VARCHAR(50),
supervisor INT,
salary INT
);

insert into EmpBonus values
(3, 'Brad', NULL, 4000),
(1, 'John', 3, 1000),
(2, 'Dan', 3, 2000),
(4, 'Thomas', 3, 4000);

select * from EmpBonus;


create table Bonus(
empId INT PRIMARY KEY,
bonus INT,
FOREIGN KEY (empId) REFERENCES EmpBonus(empId)
);

insert into Bonus values
(2, 500),
(4, 2000);

select * from Bonus;



SELECT e.name, b.bonus
FROM EmpBonus e
LEFT JOIN Bonus b
ON e.empId = b.empId
WHERE b.bonus < 1000 OR b.bonus IS NULL;
