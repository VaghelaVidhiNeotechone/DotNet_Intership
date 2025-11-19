create table UsersAttended(
user_id int primary key,
user_name varchar(100)
);

insert into UsersAttended values
(6, 'Alice'),
(2, 'Bob'),
(7, 'Alex');

select * from UsersAttended;


create table Register(
contest_id int,
user_id int,
primary key (contest_id, user_id)
);

insert into Register values
(215, 6),
(209, 2),
(208, 2),
(210, 6),
(208, 6),
(209, 7),
(209, 6),
(215, 7),
(208, 7),
(210, 2),
(207, 2),
(210, 7);

select * from Register;



SELECT r.contest_id,
    ROUND(
        COUNT(r.user_id) * 100.0 / (SELECT COUNT(*) FROM UsersAttended),
        2
    ) AS percentage
FROM Register r
GROUP BY r.contest_id
ORDER BY r.contest_id;
