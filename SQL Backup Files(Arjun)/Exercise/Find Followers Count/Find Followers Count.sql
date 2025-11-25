create table Followers(
user_id int,
follower_id int,
primary key (user_id, follower_id)
);

insert into Followers values
(0,1),
(1,0),
(2,0),
(2,1);

select * from Followers;



SELECT user_id,
    COUNT(follower_id) AS followers_count
FROM Followers
GROUP BY user_id
ORDER BY user_id;