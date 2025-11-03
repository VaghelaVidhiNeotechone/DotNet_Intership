use EmployeeManagementDB;


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

select * from Employees ;

SELECT dbo.getNthHighestSalary(1) AS FirstHighestSalary;
SELECT dbo.getNthHighestSalary(2) AS SecondHighestSalary;
SELECT dbo.getNthHighestSalary(3) AS ThirdHighestSalary;

