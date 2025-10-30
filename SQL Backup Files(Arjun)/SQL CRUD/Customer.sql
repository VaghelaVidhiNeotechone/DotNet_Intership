--create database Customer;

--Drop database Customer;


--create table Person 
--(
--PersonID int,
--LastName varchar(255),
--FirstName varchar(255),
--Address varchar(255),
--City varchar(255)
--);

--select * from Person;


--insert into Person values
--(1, 'Hansen', 'Ola', 'Timoteivn 10', 'Sandnes'),
--(2, 'Svendson', 'Tove', 'Borgvn 23', 'Sandnes'),
--(3, 'Pettersen', 'Kari', 'Storgt 20', 'Stavanger');

--select * from Person;


--alter table Person
--add DateOfBirth date;

--select * from Person;


--create table student(
--studentID INT PRIMARY KEY,              
--FullName VARCHAR(100) NOT NULL,    
--Email VARCHAR(255) UNIQUE,              
--City VARCHAR(100)
--);

--select * from student;


--INSERT INTO student (studentID,FullName,Email,City)
--VALUES
--(1, 'Viraj', 'V@example.com', 'JND'),
--(2, 'Mayank', 'M@example.com', 'RJK'),
--(3, 'Rajan', 'R@example.com', 'Gandhinagar'),
--(4, 'Krishiv', 'K@example.com', 'Baroda'),
--(5, 'Arjun', 'A@example.com', 'Ahmedabad');

--select * from student;


--CREATE TABLE Orders (
--OrderID INT PRIMARY KEY,            
--OrderNumber INT NOT NULL,             
--studentID INT,                      
--FOREIGN KEY (studentID) REFERENCES student(studentID)
--);

--select * from Orders;


--INSERT INTO Orders (OrderID, OrderNumber, studentID)
--VALUES
--(101, 5001, 1),
--(102, 5002, 2),
--(103, 5003, 3);

--SELECT * FROM student;
--SELECT * FROM Orders;


--SELECT DISTINCT City
--FROM student;


--SELECT * FROM student
--WHERE City = 'JND';


--SELECT * FROM student
--ORDER BY FullName ASC;


--SELECT * FROM student
--ORDER BY City DESC;


--SELECT * FROM student
--WHERE City = 'JND' AND FullName = 'Viraj';


--SELECT DISTINCT City
--FROM student
--WHERE (City = 'RJK' OR City = 'JND')
--AND NOT FullName = 'Arjun'
--ORDER BY City ASC;




--SELECT TOP 3 * FROM student;


--SELECT MIN(OrderNumber) AS SmallestOrder,
--       MAX(OrderNumber) AS LargestOrder
--FROM Orders;


--SELECT COUNT(*) AS TotalPeople FROM student;

--SELECT SUM(OrderNumber) AS TotalOrderValue FROM Orders;

--SELECT AVG(OrderNumber) AS AverageOrderValue FROM Orders;

--SELECT * FROM student WHERE FullName LIKE 'K%';

--SELECT * FROM student WHERE FullName LIKE '_rjun';

--SELECT * FROM student
--WHERE City IN ('RJK', 'JND');

--SELECT * FROM Orders
--WHERE OrderNumber BETWEEN 5001 AND 5003;

SELECT TOP 5 
    s.City,
    COUNT(s.studentID) AS TotalPeople,
    MIN(o.OrderNumber) AS MinOrder,
    MAX(o.OrderNumber) AS MaxOrder,
    AVG(o.OrderNumber) AS AvgOrder
FROM student s
LEFT JOIN Orders o ON s.studentID = o.studentID
WHERE s.City IN ('JND', 'Gandhinagar')
GROUP BY s.City
HAVING COUNT(s.studentID) > 0
ORDER BY AvgOrder DESC;