--create database LibraryDB;


--CREATE TABLE Person (
--Person_id INT PRIMARY KEY,      
--First_Name VARCHAR(50) NOT NULL, 
--Last_Name VARCHAR(50) NOT NULL, 
--Date_Of_Birth DATE,           
--Email VARCHAR(100) UNIQUE       
--);

--select * from Person;


--INSERT INTO Person VALUES
--(1, 'John', 'Doe', '1990-05-15', 'john@example.com'),
--(2, 'Shrut', 'Solanki', '1985-08-22', 'shrut@example.com'),
--(3, 'Joy', 'Lalkiya', '1992-12-05', 'joy@example.com'),
--(4, 'dhyey', 'Sharma', '2005-03-18', 'dhyey@example.com'),
--(5, 'David', 'Patel', '2000-11-30', 'david@example.com');

--select * from Person;



--SELECT TOP 3 * FROM person;

--SELECT COUNT(*) AS TotalPeople FROM Person;

--SELECT MIN(Date_Of_Birth) AS Earliest_Birth, MAX(Date_Of_Birth) AS Latest_Birth FROM Person;

--SELECT * FROM Person
--WHERE First_Name LIKE 'J%';

--SELECT * FROM Person
--WHERE Last_Name LIKE '%i';

--SELECT * FROM Person
--WHERE Email LIKE '%example%';

--SELECT * FROM Person
--WHERE Person_id IN (1, 3, 4);

--SELECT * FROM Person
--WHERE Date_Of_Birth BETWEEN '1990-01-01' AND '2000-12-31';