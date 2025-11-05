use EmployeeManagementDB;

create table Employees (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(50),
    DeptID INT,
    Salary INT
);

ALTER TABLE Employees ADD Score DECIMAL(5,2);


create table Departments (
    DeptID INT PRIMARY KEY,
    DeptName VARCHAR(50)
);

insert into Employees values
(1, 'Yashvi', 101, 50000),
(2, 'jahi', 102, 60000),
(3, 'arya', 101, 55000),
(4, 'shivani', 103, 45000),
(5, 'xyz', NULL, 40000);

UPDATE Employees SET Score = 7.5 WHERE EmpID = 1;
UPDATE Employees SET Score = 7.5 WHERE EmpID = 2;
UPDATE Employees SET Score = 7.5 WHERE EmpID = 3;
UPDATE Employees SET Score = 6.5 WHERE EmpID = 4;
UPDATE Employees SET Score = 6.0 WHERE EmpID = 5;

Select * from Employees;

ALTER TABLE Employees ADD Score1 DECIMAL(5,2);
UPDATE Employees SET Score1 = Score;

INSERT INTO Employees (EmpID, EmpName, DeptID, Salary, Score, Score1)
VALUES (8, 'arya', 101, 50000, 7.50, 7.50);
SELECT * FROM Employees;

insert into Departments values
(101, 'IT'),
(102, 'HR'),
(104, 'Finance');

select e.EmpID,e.EmpName,e.Salary,d.DeptName from Employees e inner join Departments d on e.DeptID=d.DeptID;

select e.EmpID,e.EmpName,e.Salary,d.DeptName from Employees e left join Departments d on e.DeptID=d.DeptID;

select e.EmpID,e.EmpName,e.Salary,d.DeptName from Employees e right join Departments d on e.DeptID=d.DeptID;

select e.EmpID,e.EmpName,e.Salary,d.DeptName from Employees e full join Departments d on e.DeptID=d.DeptID;

select e1.EmpName as Employee1,e2.EmpName as Employee2,e1.DeptID from Employees e1 join Employees e2 on e1.DeptID=e2.DeptID
where e1.EmpID<>e2.EmpID;

select DeptID from Employees union select DeptID from Departments;

select DeptID from Employees union all select DeptID from Departments;

select  DeptID,sum(Salary) as TotalSalary from Employees Group by DeptID having sum(Salary)>90000;

select EmpName from Employees e where exists (select 1 from Departments d where e.DeptID=d.DeptID);

select EmpName,Salary from Employees where Salary>any(select Salary from Employees where DeptID=101);

select EmpName, Salary from Employees where Salary > ALL (select Salary from Employees where DeptID = 101);

SELECT 
    e.EmpName,
    d.DeptName,
    e.Salary
FROM Employees e
LEFT JOIN Departments d
ON e.DeptID = d.DeptID;

GO
CREATE FUNCTION getNthHighestSalary (@N INT)
RETURNS INT
AS
BEGIN
    DECLARE @result INT;

    SELECT @result = Salary
    FROM (
        SELECT Salary,
               DENSE_RANK() OVER (ORDER BY Salary DESC) AS ranked
        FROM Employees
    ) AS temp_table
    WHERE ranked = @N;

    RETURN @result;
END;
GO

select COUNT(*) as TotalEmployees,MAX(Salary) AS SecondHighestSalary FROM Employees;

SELECT dbo.getNthHighestSalary(1) AS FirstHighestSalary;
SELECT dbo.getNthHighestSalary(2) AS SecondHighestSalary;
SELECT dbo.getNthHighestSalary(3) AS ThirdHighestSalary;

select * from Employees ;

select Score, DENSE_RANK() OVER(ORDER BY score DESC) AS 'rank' from Employees;