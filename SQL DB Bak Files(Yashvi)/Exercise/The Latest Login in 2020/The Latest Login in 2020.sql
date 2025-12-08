use DBLeetCode2;


CREATE TABLE Logins (
    user_id INT,
    time_stamp DATETIME,
    PRIMARY KEY (user_id, time_stamp)
);

INSERT INTO Logins (user_id, time_stamp) VALUES
(6, '2020-06-30 15:00:00'),
(6, '2020-07-26 10:00:00'),
(6, '2020-07-21 09:30:00'),
(2, '2020-06-30 09:50:00'),
(2, '2020-07-25 16:30:00'),
(2, '2020-06-25 23:00:00'),
(1, '2019-07-26 20:30:00'),
(1, '2018-12-25 11:30:00'),
(1, '2020-08-30 08:30:00');

select * from Logins;

SELECT user_id,MAX(time_stamp) AS last_stamp
FROM Logins WHERE YEAR(time_stamp) = 2020 GROUP BY user_id;
