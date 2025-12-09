create table students_sessions(
student_id int primary key,
student_name varchar(100),
major varchar(100)
);

insert into students_sessions values
(1, 'Alice Chen', 'Computer Science'),
(2, 'Bob Johnson', 'Mathematics'),
(3, 'Carol Davis', 'Physics'),
(4, 'David Wilson', 'Chemistry'),
(5, 'Emma Brown', 'Biology');

select * from students_sessions;


create table study_sessions(
session_id int primary key,
student_id int,
subject varchar(100),
session_date date,
hours_studied decimal(5,2),
foreign key (student_id) references students_sessions(student_id)
);

insert into study_sessions values
(1, 1, 'Math', '2023-10-01', 2.5),
(2, 1, 'Physics', '2023-10-02', 3.0),
(3, 1, 'Chemistry', '2023-10-03', 2.0),
(4, 1, 'Math', '2023-10-04', 2.5),
(5, 1, 'Physics', '2023-10-05', 3.0),
(6, 1, 'Chemistry', '2023-10-06', 2.0),
(7, 2, 'Algebra', '2023-10-01', 4.0),
(8, 2, 'Calculus', '2023-10-02', 3.5),
(9, 2, 'Statistics', '2023-10-03', 2.5),
(10, 2, 'Geometry', '2023-10-04', 3.0),
(11, 2, 'Algebra', '2023-10-05', 4.0),
(12, 2, 'Calculus', '2023-10-06', 3.5),
(13, 2, 'Statistics', '2023-10-07', 2.5),
(14, 2, 'Geometry', '2023-10-08', 3.0),
(15, 3, 'Biology', '2023-10-01', 2.0),
(16, 3, 'Chemistry', '2023-10-02', 2.5),
(17, 3, 'Biology', '2023-10-03', 2.0),
(18, 3, 'Chemistry', '2023-10-04', 2.5),
(19, 4, 'Organic', '2023-10-01', 3.0),
(20, 4, 'Physical', '2023-10-05', 2.5);

select * from study_sessions;




WITH sorted_sessions AS (
    SELECT 
        s.student_id,
        s.subject,
        s.session_date,
        s.hours_studied,
        ROW_NUMBER() OVER (PARTITION BY s.student_id ORDER BY s.session_date) AS rn
    FROM study_sessions s
),

blocks AS (
    SELECT 
        student_id,
        subject,
        session_date,
        hours_studied,
        rn,
        CASE 
            WHEN DATEDIFF(DAY, 
                LAG(session_date) OVER (PARTITION BY student_id ORDER BY rn), 
                session_date) > 2 THEN 1
            ELSE 0
        END AS gap_flag
    FROM sorted_sessions
),

block_groups AS (
    SELECT
        student_id,
        subject,
        session_date,
        hours_studied,
        rn,
        SUM(gap_flag) OVER (PARTITION BY student_id ORDER BY rn ROWS UNBOUNDED PRECEDING) AS block_id
    FROM blocks
),

pattern_analysis AS (
    SELECT 
        student_id,
        block_id,
        COUNT(*) AS total_sessions,
        COUNT(DISTINCT subject) AS cycle_length,
        SUM(hours_studied) AS total_study_hours,
        STRING_AGG(subject, '?') WITHIN GROUP (ORDER BY rn) AS subject_sequence
    FROM block_groups
    GROUP BY student_id, block_id
),

valid_spiral AS (
    SELECT *
    FROM pattern_analysis
    WHERE 
        cycle_length >= 3     
        AND total_sessions >= cycle_length * 2 
)

SELECT 
    st.student_id,
    st.student_name,
    st.major,
    v.cycle_length,
    v.total_study_hours
FROM valid_spiral v
JOIN students_sessions st ON st.student_id = v.student_id
ORDER BY 
    v.cycle_length DESC,
    v.total_study_hours DESC;
