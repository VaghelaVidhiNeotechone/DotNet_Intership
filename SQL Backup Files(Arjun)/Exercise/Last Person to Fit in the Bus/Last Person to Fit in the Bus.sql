create table Queue(
person_id int primary key,
person_name varchar(50),
weight int,
turn int
);

insert into Queue values
(5,'Alice',250,1),
(4,'Bob',175,5),
(3,'Alex',350,2),
(6,'John Cena',400,3),
(1,'Winston',500,6),
(2,'Marie',200,4);

select * from Queue;



WITH Boarding AS (
    SELECT
        person_name,
        turn,
        SUM(weight) OVER (ORDER BY turn ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS total_weight
    FROM Queue
)
SELECT TOP 1 person_name
FROM Boarding
WHERE total_weight <= 1000
ORDER BY total_weight DESC;
