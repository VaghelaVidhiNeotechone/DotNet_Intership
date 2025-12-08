create table EmployeesReport(
employee_id int primary key,
name varchar(50),
reports_to int null,
age int
);

insert into EmployeesReport values
(9,'Hercy',Null,43),
(6,'Alice',9,41),
(4,'Bon',9,36),
(2,'Winston',Null,37);

select * from EmployeesReport;



SELECT 
    e.employee_id, 
    e.name,
    COUNT(r.employee_id) AS reports_count,
    ROUND(AVG(CAST(r.age AS FLOAT)), 0) AS average_age
FROM EmployeesReport AS e
INNER JOIN EmployeesReport AS r
    ON e.employee_id = r.reports_to
GROUP BY e.employee_id, e.name
ORDER BY e.employee_id;


