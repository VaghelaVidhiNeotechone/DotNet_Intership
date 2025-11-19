use DBLeetCode2;

CREATE TABLE Users2 (
    user_id INT PRIMARY KEY,
    user_name VARCHAR(255)
);

CREATE TABLE Register (
    contest_id INT,
    user_id INT,
    PRIMARY KEY (contest_id, user_id)
);

INSERT INTO Users2 (user_id, user_name) VALUES
(6, 'Alice'),
(2, 'Bob'),
(3, 'Tom'),
(5, 'Jessica');

INSERT INTO Register (contest_id, user_id) VALUES
(215, 6),
(209, 2),
(209, 6),
(209, 3),
(215, 3),
(209, 5);

select * from Users2;
select * from Register;

select contest_id, 
round(count(user_id) * 100.0 / (select count(user_id) from Users2), 2) as percentage
from Register group by contest_id order by percentage desc, contest_id;