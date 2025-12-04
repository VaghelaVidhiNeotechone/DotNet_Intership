create table EmpAnalyze(
employee_id int primary key,
employee_name varchar(100),
manager_id int,
salary int,
department varchar(100)
);

insert into EmpAnalyze values
(1, 'Alice', NULL, 12000, 'Executive'),
(2, 'Bob', 1, 10000, 'Sales'),
(3, 'Charlie', 1, 10000, 'Engineering'),
(4, 'David', 2, 7500, 'Sales'),
(5, 'Eva', 2, 7500, 'Sales'),
(6, 'Frank', 3, 9000, 'Engineering'),
(7, 'Grace', 3, 8500, 'Engineering'),
(8, 'Hank', 4, 6000, 'Sales'),
(9, 'Ivy', 6, 7000, 'Engineering'),
(10, 'Judy', 6, 7000, 'Engineering');

select * from EmpAnalyze;




WITH Org AS (
    SELECT 
        employee_id,
        employee_name,
        manager_id,
        salary,
        1 AS level
    FROM EmpAnalyze
    WHERE manager_id IS NULL

    UNION ALL

    SELECT 
        e.employee_id,
        e.employee_name,
        e.manager_id,
        e.salary,
        o.level + 1
    FROM EmpAnalyze e
    JOIN Org o ON e.manager_id = o.employee_id
),
AllPaths AS (
    SELECT 
        employee_id AS root_emp,
        employee_id,
        salary
    FROM EmpAnalyze

    UNION ALL

    SELECT
        ap.root_emp,
        e.employee_id,
        e.salary
    FROM EmpAnalyze e
    JOIN AllPaths ap ON e.manager_id = ap.employee_id
)

SELECT 
    o.employee_id,
    o.employee_name,
    o.level,
    
    -- team size
    (SELECT COUNT(*) 
     FROM AllPaths ap 
     WHERE ap.root_emp = o.employee_id 
       AND ap.employee_id <> o.employee_id) AS team_size,

    -- total budget
    (SELECT SUM(ap.salary)
     FROM AllPaths ap
     WHERE ap.root_emp = o.employee_id) AS budget

FROM Org o
ORDER BY 
    o.level ASC,
    budget DESC,
    o.employee_id ASC;

