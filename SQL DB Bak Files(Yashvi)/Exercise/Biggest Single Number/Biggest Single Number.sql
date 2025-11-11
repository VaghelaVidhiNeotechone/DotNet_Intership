use demoDB;

CREATE TABLE MyNumbers (
    num INT
);

INSERT INTO MyNumbers (num) VALUES
(8),
(8),
(3),
(3),
(1),
(4),
(5),
(6);

select *  from MyNumbers;

SELECT MAX(num) AS num FROM MyNumbers 
where num in(
select num from MyNumbers GROUP BY num HAVING COUNT(num) = 1
)
