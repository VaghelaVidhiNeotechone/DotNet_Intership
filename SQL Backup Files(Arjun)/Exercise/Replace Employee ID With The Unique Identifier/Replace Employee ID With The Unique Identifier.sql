create table EmployeesReplace(
id int primary key,
name varchar(100)
);

insert into EmployeesReplace values
(1, 'Alice'),
(7, 'Bob'),
(11, 'Meir'),
(90, 'Winston'),
(3, 'Jonathan');

select * from EmployeesReplace;


create table EmployeeUNI(
id int,
unique_id int,
primary key (id, unique_id)
);

insert into EmployeeUNI values
(3, 1),
(11, 2),
(90, 3);

select * from EmployeeUNI;




SELECT euni.unique_id,e.name
FROM EmployeesReplace e
LEFT JOIN EmployeeUNI euni
    ON e.id = euni.id
ORDER BY e.id;
