create table EmployeePrimary(
employee_id int,
department_id int,
primary_flag char(1),
primary key (employee_id, department_id)
);

insert into EmployeePrimary values
(1, 1, 'N'),
(2, 1, 'Y'),
(2, 2, 'N'),
(3, 3, 'N'),
(4, 2, 'N'),
(4, 3, 'Y'),
(4, 4, 'N');

select * from EmployeePrimary;




WITH ranked AS (
    SELECT
        employee_id,
        department_id,
        primary_flag,
        ROW_NUMBER() OVER (
            PARTITION BY employee_id
            ORDER BY 
                CASE WHEN primary_flag = 'Y' THEN 0 ELSE 1 END,
                department_id
        ) AS rn
    FROM EmployeePrimary
)
SELECT employee_id, department_id
FROM ranked
WHERE rn = 1
ORDER BY employee_id;