create table Activity(
player_id INT,
device_id INT,
event_date DATE,
games_played INT,
PRIMARY KEY (player_id, event_date)
);

insert into Activity values
(1, 2, '2016-03-01', 5),
(1, 2, '2016-05-02', 6),
(2, 3, '2017-06-25', 1),
(3, 1, '2016-03-02', 0),
(3, 4, '2018-07-03', 5);

select * from Activity;



SELECT 
    ISNULL(
        ROUND(
            CAST(COUNT(DISTINCT a.player_id) AS DECIMAL(5,2)) / 
            NULLIF(COUNT(DISTINCT b.player_id), 0),
            2
        ),
        0.00
    ) AS fraction
FROM Activity a
JOIN (
    SELECT player_id, MIN(event_date) AS first_login
    FROM Activity
    GROUP BY player_id
) b
ON a.player_id = b.player_id
AND DATEDIFF(DAY, b.first_login, a.event_date) = 1;