create table Courses (
    student VARCHAR(50),  
    class VARCHAR(50),     
    PRIMARY KEY (student, class)  
);

insert into Courses (student, class) values
('A', 'Math'),
('B', 'English'),
('C', 'Math'),
('D', 'Biology'),
('E', 'Math'),
('F', 'Computer'),
('G', 'Math'),
('H', 'Math'),
('I', 'Math');

select * from Courses;



SELECT class
FROM Courses
GROUP BY class
HAVING COUNT(student) >= 5;