create table Teacher(
teacher_id int,
subject_id int,
dept_id int,
primary key (subject_id, dept_id)
);

insert into Teacher values
(1,2,3),
(1,2,4),
(1,3,3),
(2,1,1),
(2,2,1),
(2,3,1),
(2,4,1);

select * from Teacher;



SELECT teacher_id,
    COUNT(DISTINCT subject_id) AS cnt
FROM Teacher
GROUP BY teacher_id;
