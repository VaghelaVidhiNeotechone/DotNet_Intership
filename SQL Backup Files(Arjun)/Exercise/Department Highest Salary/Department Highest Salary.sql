create table Department
(
id int primary key,
name varchar(50)
);

insert into Department values
(1,'IT'),
(2,'Sales');

select * from Department;


create table Emp
(
id int primary key,
name varchar(50),
Salary int,
departmentId int
);

insert into Emp values
(1,'Joe',70000,1),
(2,'Jim',90000,1),
(3,'Henry',80000,2),
(4,'Sam',60000,2),
(5,'Max',90000,1);

select * from Emp;


SELECT d.name AS Department,
       e.name AS Emp,
       e.salary AS Salary
FROM Emp e
JOIN Department d ON e.departmentId = d.id
WHERE e.salary = (
    SELECT MAX(salary)
    FROM Emp
    WHERE departmentId = e.departmentId
);