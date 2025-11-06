use demoDB;

CREATE TABLE Courses (
    student VARCHAR(255),
    class VARCHAR(255),
    PRIMARY KEY (student, class)
);

INSERT INTO Courses (student, class) VALUES
('A', 'Math'),
('B', 'English'),
('C', 'Math'),
('D', 'Math'),
('E', 'English'),
('F', 'Math'),
('G', 'English'),
('H', 'Math'),
('I', 'Math');

select * from Courses;

SELECT class FROM Courses GROUP BY class HAVING COUNT(student) >= 5;
