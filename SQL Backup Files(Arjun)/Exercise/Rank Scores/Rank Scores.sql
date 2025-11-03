--create table Scores
--(
--id int,
--score decimal
--);

--insert into Scores values
--(1,3.50),
--(2,3.65),
--(3,4.00),
--(4,3.85),
--(5,4.00),
--(6,3.65);

--select * from Scores;

SELECT 
    score,
    RANK() OVER (ORDER BY score DESC) AS rank
FROM Scores;
