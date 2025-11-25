create table RequestAccepted(
requester_id INT,
accepter_id INT,
accept_date DATE,
PRIMARY KEY (requester_id, accepter_id)
);

insert into RequestAccepted values
(1, 2, '2016-06-03'),
(1, 3, '2016-06-08'),
(2, 3, '2016-06-08'),
(3, 4, '2016-06-09');

select * from RequestAccepted;




WITH Friends AS (
    SELECT requester_id AS id, accepter_id AS friend_id
    FROM RequestAccepted
    UNION ALL
    SELECT accepter_id AS id, requester_id AS friend_id
    FROM RequestAccepted
)
, FriendCounts AS (
    SELECT id, COUNT(DISTINCT friend_id) AS num
    FROM Friends
    GROUP BY id
)
SELECT TOP 1 id, num
FROM FriendCounts
ORDER BY num DESC;