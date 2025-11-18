create table UsersTravellers(
id int primary key,
name varchar(100)
);

insert into UsersTravellers values
(1, 'Alice'),
(2, 'Bob'),
(3, 'Alex'),
(4, 'Donald'),
(7, 'Lee'),
(13, 'Jonathan'),
(19, 'Elvis');

select * from UsersTravellers;


create table Rides(
id int primary key,
user_id int,
distance int
);

insert into Rides values
(1, 1, 120),
(2, 2, 317),
(3, 3, 222),
(4, 7, 100),
(5, 13, 312),
(6, 19, 50),
(7, 7, 120),
(8, 19, 400),
(9, 7, 230);

select * from Rides;




SELECT 
    u.name,
    COALESCE(SUM(r.distance), 0) AS travelled_distance
FROM UsersTravellers u
LEFT JOIN Rides r
    ON u.id = r.user_id
GROUP BY u.id, u.name
ORDER BY travelled_distance DESC, u.name ASC;
