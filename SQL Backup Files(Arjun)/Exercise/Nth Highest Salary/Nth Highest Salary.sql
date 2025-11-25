--create table employee
--(
--id int,
--salary int
--);

--insert into employee values
--(1,100),
--(2,200),
--(3,300);

--select * from employee;



--SELECT MAX(salary) AS SecondHighestSalary
--FROM employee
--WHERE salary < (SELECT MAX(salary) FROM employee);


DECLARE @N INT = 2;

WITH SalaryRank AS (
    SELECT salary,
           DENSE_RANK() OVER (ORDER BY salary DESC) AS rnk
    FROM Employee
)
SELECT salary AS getNthHighestSalary
FROM SalaryRank
WHERE rnk = @N;