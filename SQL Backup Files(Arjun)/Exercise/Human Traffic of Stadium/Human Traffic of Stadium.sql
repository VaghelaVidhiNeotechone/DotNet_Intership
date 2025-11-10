create table Stadium(
id int,
visit_date DATE,
people int
);

insert into Stadium values
(1, '2017-01-01', 10),
(2, '2017-01-02', 109),
(3, '2017-01-03', 150),
(4, '2017-01-04', 99),
(5, '2017-01-05', 145),
(6, '2017-01-06', 1455),
(7, '2017-01-07', 199),
(8, '2017-01-09', 188);

select * from Stadium;




WITH Flagged AS (
    SELECT *,
           CASE WHEN people >= 100 THEN 1 ELSE 0 END AS is_big
    FROM Stadium
),
Consecutive AS (
    SELECT *,
           id - ROW_NUMBER() OVER (ORDER BY id) AS grp
    FROM Flagged
    WHERE is_big = 1
),
Groups AS (
    SELECT MIN(id) AS start_id, MAX(id) AS end_id
    FROM Consecutive
    GROUP BY grp
    HAVING COUNT(*) >= 3
)
SELECT s.id, s.visit_date, s.people
FROM Stadium s
JOIN Groups g
  ON s.id BETWEEN g.start_id AND g.end_id
ORDER BY s.id;