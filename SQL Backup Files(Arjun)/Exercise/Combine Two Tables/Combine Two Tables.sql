--create database Exercise;

--DROP TABLE IF EXISTS Person;
--DROP TABLE IF EXISTS Address;

--CREATE TABLE Person (
--    personId INT,
--    lastName VARCHAR(50),
--    firstName VARCHAR(50)
--);

--INSERT INTO Person VALUES 
--(1, 'Wang', 'Allen'), 
--(2, 'Alice', 'Bob');

--select * from person


--CREATE TABLE Address (
--    addressId INT,
--    personId INT,
--    city VARCHAR(50),
--    state VARCHAR(50)
--);

--INSERT INTO Address VALUES 
--(1, 2, 'New York City', 'New York'),
--(2, 3, 'Leetcode', 'California');

--select * from address;


--SELECT p.firstName,p.lastName,a.city,a.state
--FROM Person p
--FULL JOIN Address a
--ON p.personId = a.personId;


--SELECT p.firstName,p.lastName,a.city,a.state
--FROM Person p
--LEFT JOIN Address a
--ON p.personId = a.personId;

