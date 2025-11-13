create table EmployeeProject(
employee_id int primary key,
name varchar(50),
experience_years int not null
);

insert into EmployeeProject values
(1, 'Khaled', 3),
(2, 'Ali', 2),
(3, 'John', 1),
(4, 'Doe', 2);

select * from EmployeeProject;


create table Project(
project_id int,
employee_id int,
primary key (project_id,employee_id),
foreign key (employee_id) references EmployeeProject(employee_id)
);

insert into Project values
(1,1),
(1,2),
(1,3),
(2,1),
(2,4);

select * from Project;



SELECT p.project_id,
ROUND(AVG(e.experience_years * 1.0), 2) AS average_years
FROM Project p
JOIN EmployeeProject e
ON p.employee_id = e.employee_id
GROUP BY p.project_id;
