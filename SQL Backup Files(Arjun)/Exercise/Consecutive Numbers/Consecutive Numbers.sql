--CREATE TABLE Logs (
--    id INT PRIMARY KEY,
--    num VARCHAR(10)
--);

--insert into Logs values
--(1,'1'),
--(2,'1'),
--(3,'1'),
--(4,'2'),
--(5,'1'),
--(6,'2'),
--(7,'2');

--select * from Logs;


SELECT DISTINCT num AS ConsecutiveNums
FROM (
    SELECT *,
           LAG(num, 1) OVER (ORDER BY id) AS prev1,
           LAG(num, 2) OVER (ORDER BY id) AS prev2,
           LEAD(num, 1) OVER (ORDER BY id) AS next1,
           LEAD(num, 2) OVER (ORDER BY id) AS next2
    FROM Logs
) t
WHERE (num = prev1 AND num = prev2) 
   OR (num = prev1 AND num = next1) 
   OR (num = next1 AND num = next2);
