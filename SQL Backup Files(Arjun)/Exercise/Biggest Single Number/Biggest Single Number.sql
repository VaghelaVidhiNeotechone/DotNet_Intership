create table MyNumbers(
num int
);

insert into MyNumbers values
(8),
(8),
(3),
(3),
(1),
(4),
(5),
(6);

select * from MyNumbers;



SELECT TOP 1 num FROM MyNumbers
GROUP BY num
HAVING COUNT(num) = 1
ORDER BY num DESC;