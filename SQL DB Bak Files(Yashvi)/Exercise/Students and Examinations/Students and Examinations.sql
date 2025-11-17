use DBLeetCode;

CREATE TABLE Students (
    student_id INT PRIMARY KEY,
    student_name VARCHAR(255)
);

CREATE TABLE Subjects (
    subject_name VARCHAR(255) PRIMARY KEY
);

CREATE TABLE Examinations (
    student_id INT FOREIGN KEY REFERENCES Students(student_id),
    subject_name VARCHAR(255) FOREIGN KEY REFERENCES Subjects(subject_name)
);

INSERT INTO Students (student_id, student_name) VALUES
(1, 'Alice'),
(2, 'Bob'),
(13, 'John'),
(6, 'Alex');

INSERT INTO Subjects (subject_name) VALUES
('Math'),
('Physics'),
('Programming');

INSERT INTO Examinations (student_id, subject_name) VALUES
(1, 'Math'),
(1, 'Physics'),
(1, 'Programming'),
(2, 'Programming'),
(1, 'Physics'),
(1, 'Programming'),
(13, 'Programming'),
(13, 'Physics');

select * from Students;
select * from Subjects;
select * from Examinations;

SELECT stu.student_id, stu.student_name, sub.subject_name, COUNT(exam.subject_name) AS attended_exams
FROM students stu CROSS JOIN subjects sub
LEFT JOIN examinations exam ON stu.student_id = exam.student_id AND sub.subject_name = exam.subject_name
GROUP BY  stu.student_id, stu.student_name, sub.subject_name
ORDER BY stu.student_id, sub.subject_name;