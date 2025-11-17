create table Students(
student_id int primary key,
student_name varchar(100)
);

insert into Students values
(1, 'Alice'),
(2, 'Bob'),
(13, 'John'),
(6, 'Alex');

select * from Students;


create table Subjects(
subject_name varchar(100) primary key
);

insert into Subjects values
('Math'),
('Physics'),
('Programming');

select * from Subjects;


create table Examinations(
student_id int,
subject_name varchar(100)
);

insert into Examinations values
(1, 'Math'),
(1, 'Physics'),
(1, 'Programming'),
(2, 'Programming'),
(1, 'Physics'),
(1, 'Math'),
(13, 'Math'),
(13, 'Programming'),
(13, 'Physics'),
(2, 'Math'),
(1, 'Math');

select * from Examinations;




SELECT s.student_id,s.student_name,sub.subject_name,
    COUNT(e.subject_name) AS attended_exams
FROM Students s
CROSS JOIN Subjects sub
LEFT JOIN Examinations e
ON s.student_id = e.student_id
    AND sub.subject_name = e.subject_name
GROUP BY s.student_id, s.student_name, sub.subject_name
ORDER BY s.student_id, sub.subject_name;
