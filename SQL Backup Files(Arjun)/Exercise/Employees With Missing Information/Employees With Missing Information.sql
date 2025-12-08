create table EmployeesInfo(
employee_id	int primary key,
name varchar(100)
);

insert into EmployeesInfo values
(2,'Crew'),
(4,'Haven'),
(5,'Kristian');

select * from EmployeesInfo;


create table Salaries(
employee_id int primary key,
salary int
);

insert into Salaries values
(5,76071),
(1,22517),
(4,63539);

select * from Salaries;



SELECT employee_id
FROM (
    SELECT employee_id FROM EmployeesInfo
    UNION
    SELECT employee_id FROM Salaries
) AS all_emp
WHERE employee_id NOT IN (SELECT employee_id FROM EmployeesInfo)
   OR employee_id NOT IN (SELECT employee_id FROM Salaries)
ORDER BY employee_id;


