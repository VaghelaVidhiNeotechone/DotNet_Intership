use DBLeetCode2;

CREATE TABLE employees8 (
    employee_id INT PRIMARY KEY,
    employee_name VARCHAR(255),
    department VARCHAR(255)
);

CREATE TABLE meetings (
    meeting_id INT PRIMARY KEY,
    employee_id INT,
    meeting_date DATE,
    meeting_type VARCHAR(255),
    duration_hours DECIMAL(5, 2),
    FOREIGN KEY (employee_id) REFERENCES employees8(employee_id)
);

INSERT INTO employees8 (employee_id, employee_name, department) VALUES
(1, 'Alice Johnson', 'Engineering'),
(2, 'Bob Smith', 'Marketing'),
(3, 'Carol Davis', 'Sales'),
(4, 'David Wilson', 'Engineering'),
(5, 'Emma Brown', 'HR');

INSERT INTO meetings (meeting_id, employee_id, meeting_date, meeting_type, duration_hours) VALUES
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

select * from employees8;
select * from meetings;

WITH WeeklyMeetings AS (
    SELECT M.employee_id, M.duration_hours,
		CAST(DATEADD(DAY, DATEDIFF(DAY, '1900-01-01', M.meeting_date) / 7 * 7, '1900-01-01') AS DATE) AS week_start_date
    FROM meetings M
),
TotalWeeklyHours AS (
    SELECT employee_id,  week_start_date, SUM(duration_hours) AS total_hours
    FROM WeeklyMeetings
    GROUP BY employee_id, week_start_date
),
MeetingHeavyWeeks AS (
    SELECT employee_id, COUNT(week_start_date) AS meeting_heavy_weeks_count
    FROM TotalWeeklyHours
    WHERE total_hours > 20.0
    GROUP BY employee_id
    HAVING COUNT(week_start_date) >= 2 
)
SELECT E.employee_id, E.employee_name, E.department,MHW.meeting_heavy_weeks_count AS meeting_heavy_weeks
FROM employees8 E
JOIN 
MeetingHeavyWeeks MHW ON E.employee_id = MHW.employee_id
ORDER BY meeting_heavy_weeks DESC, E.employee_name ASC;
