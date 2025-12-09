create table empBooked(
employee_id int primary key,
employee_name varchar(100),
department varchar(50)
);

insert into empBooked values
(1, 'Alice Johnson', 'Engineering'),
(2, 'Bob Smith', 'Marketing'),
(3, 'Carol Davis', 'Sales'),
(4, 'David Wilson', 'Engineering'),
(5, 'Emma Brown', 'HR');

select * from emp;


create table meetings(
meeting_id int primary key,
employee_id int,
meeting_date date,
meeting_type varchar(20),
duration_hours decimal(5,2),
foreign key (employee_id) references empBooked(employee_id)
);

insert into meetings values
(1, 1, '2023-06-05', 'Team', 8.0),
(2, 1, '2023-06-06', 'Client', 6.0),
(3, 1, '2023-06-07', 'Training', 7.0),
(4, 1, '2023-06-12', 'Team', 12.0),
(5, 1, '2023-06-13', 'Client', 9.0),
(6, 2, '2023-06-05', 'Team', 15.0),
(7, 2, '2023-06-06', 'Client', 8.0),
(8, 2, '2023-06-12', 'Training', 10.0),
(9, 3, '2023-06-05', 'Team', 4.0),
(10, 3, '2023-06-06', 'Client', 3.0),
(11, 4, '2023-06-05', 'Team', 25.0),
(12, 4, '2023-06-19', 'Client', 22.0),
(13, 5, '2023-06-05', 'Training', 2.0);

select * from meetings;




WITH weekly_hours AS (
    SELECT 
        m.employee_id,
        DATEADD(WEEK, DATEDIFF(WEEK, 0, m.meeting_date), 0) AS week_start,
        SUM(m.duration_hours) AS total_meeting_hours
    FROM meetings m
    GROUP BY 
        m.employee_id,
        DATEADD(WEEK, DATEDIFF(WEEK, 0, m.meeting_date), 0)
),

meeting_heavy_weeks AS (
    SELECT 
        employee_id,
        week_start,
        total_meeting_hours
    FROM weekly_hours
    WHERE total_meeting_hours > 20  
),

count_heavy_weeks AS (
    SELECT 
        employee_id,
        COUNT(*) AS meeting_heavy_weeks
    FROM meeting_heavy_weeks
    GROUP BY employee_id
    HAVING COUNT(*) >= 2   
)

SELECT 
    e.employee_id,
    e.employee_name,
    e.department,
    c.meeting_heavy_weeks
FROM count_heavy_weeks c
JOIN empBooked e ON e.employee_id = c.employee_id
ORDER BY 
    c.meeting_heavy_weeks DESC,
    e.employee_name ASC;
