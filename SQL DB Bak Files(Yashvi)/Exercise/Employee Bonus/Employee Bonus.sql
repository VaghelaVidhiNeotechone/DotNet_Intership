use demoDB;

CREATE TABLE Employees (
    empId INT PRIMARY KEY,
    name VARCHAR(255),
    supervisor INT,
    salary INT
);

CREATE TABLE Bonus (
    empId INT PRIMARY KEY,
    bonus INT,
    FOREIGN KEY (empId) REFERENCES Employees(empId)
);

select * from Employees;
select * from Bonus;

SELECT E.name, B.bonus FROM Employees E LEFT JOIN Bonus B ON E.empId = B.empId WHERE B.bonus < 1000 OR B.bonus IS NULL;
