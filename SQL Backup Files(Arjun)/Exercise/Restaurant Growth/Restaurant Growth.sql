create table CustomerRestaurant(
customer_id int,
name varchar(100),
visited_on date,
amount int,
primary key (customer_id, visited_on)
);

insert into CustomerRestaurant values
(1, 'Jhon', '2019-01-01', 100),
(2, 'Daniel', '2019-01-02', 110),
(3, 'Jade', '2019-01-03', 120),
(4, 'Khaled', '2019-01-04', 130),
(5, 'Winston', '2019-01-05', 110),
(6, 'Elvis', '2019-01-06', 140),
(7, 'Anna', '2019-01-07', 150),
(8, 'Maria', '2019-01-08', 80),
(9, 'Jaze', '2019-01-09', 110),
(1, 'Jhon', '2019-01-10', 130),
(3, 'Jade', '2019-01-10', 150);

select * from CustomerRestaurant;




WITH daily AS (
    SELECT 
        visited_on,
        SUM(amount) AS amount
    FROM CustomerRestaurant
    GROUP BY visited_on
),
windowed AS (
    SELECT 
        d1.visited_on,
        (
            SELECT SUM(d2.amount)
            FROM daily d2
            WHERE d2.visited_on BETWEEN DATEADD(day, -6, d1.visited_on)
                                   AND d1.visited_on
        ) AS amount,
        (
            SELECT CAST(AVG(CAST(d2.amount AS FLOAT)) AS DECIMAL(10,2))
            FROM daily d2
            WHERE d2.visited_on BETWEEN DATEADD(day, -6, d1.visited_on)
                                   AND d1.visited_on
        ) AS average_amount
    FROM daily d1
)
SELECT *
FROM windowed
WHERE visited_on >= 
      DATEADD(day, 6, (SELECT MIN(visited_on) FROM daily))
ORDER BY visited_on;
