create table Salary(
id int primary key,
name varchar(100),
sex char(1),
salary int
);

insert into Salary values
(1, 'A', 'M', 2500),
(2, 'B', 'F', 1500),
(3, 'C', 'M', 5500),
(4, 'D', 'F', 500);

select * from Salary;




UPDATE Salary
SET sex = CASE
WHEN sex = 'M' THEN 'F'
WHEN sex = 'F' THEN 'M' END;