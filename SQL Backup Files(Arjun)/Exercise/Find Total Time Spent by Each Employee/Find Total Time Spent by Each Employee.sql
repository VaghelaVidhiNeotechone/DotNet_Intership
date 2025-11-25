create table EmployeesFind(
emp_id int,
event_day date,
in_time int,
out_time int,
primary key (emp_id, event_day, in_time)
);

insert into EmployeesFind values
(1, '2020-11-28', 4, 32),
(1, '2020-11-28', 55, 200),
(1, '2020-12-03', 1, 42),
(2, '2020-11-28', 3, 33),
(2, '2020-12-09', 47, 74);

select * from EmployeesFind;


SELECT event_day AS day, emp_id,
    SUM(out_time - in_time) AS total_time
FROM EmployeesFind
GROUP BY event_day, emp_id
ORDER BY day, emp_id;
