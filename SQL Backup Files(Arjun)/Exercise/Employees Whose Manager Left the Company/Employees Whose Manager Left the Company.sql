create table EmployeesComp(
employee_id int primary key,
name varchar(100),
manager_id int,
salary int
);

insert into EmployeesComp values
(3,'Mila',9,60301),
(12,'Antonella',null,31000),
(13,'Emery',null,67084),
(1,'Kalel',11,21241),
(9,'Mikaela',null,50937),
(11,'Joziah',6,28485);

select * from EmployeesComp;



SELECT employee_id
FROM EmployeesComp e
WHERE e.salary < 30000
  AND e.manager_id IS NOT NULL
  AND e.manager_id NOT IN (SELECT employee_id FROM EmployeesComp);
