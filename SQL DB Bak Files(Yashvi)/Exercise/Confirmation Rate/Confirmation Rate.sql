use DBLeetCode2;

CREATE TABLE Signups (
    user_id INT PRIMARY KEY,
    time_stamp DATETIME
);

CREATE TABLE Confirmations (
    user_id INT,
    time_stamp DATETIME,
    action VARCHAR(10) CHECK (action IN ('confirmed', 'timeout')),
    PRIMARY KEY (user_id, time_stamp),
    FOREIGN KEY (user_id) REFERENCES Signups(user_id)
);

INSERT INTO Signups (user_id, time_stamp) VALUES
(3, '2020-03-21 10:16:13'),
(7, '2020-01-04 13:57:59'),
(2, '2020-07-29 23:09:44'),
(6, '2020-12-09 10:39:58');

INSERT INTO Confirmations (user_id, time_stamp, action) VALUES
(3, '2021-01-06 00:58:18', 'timeout'),
(3, '2021-07-12 12:53:10', 'confirmed'),
(7, '2021-06-12 11:57:29', 'confirmed'),
(7, '2021-06-13 12:58:28', 'confirmed'),
(7, '2021-06-14 13:59:27', 'timeout'),
(2, '2020-07-29 23:10:06', 'confirmed'),
(2, '2020-07-29 23:11:06', 'timeout');

select * from Signups;
select * from Confirmations;

SELECT s.user_id,
    COALESCE( ROUND( CAST(COUNT(CASE WHEN c.action = 'confirmed' THEN 1 END) AS FLOAT) /NULLIF(CAST(COUNT(c.action) 
	AS FLOAT), 0), 2), 0.00) AS confirmation_rate
FROM Signups s
LEFT JOIN Confirmations c ON s.user_id = c.user_id
GROUP BY s.user_id ORDER BY s.user_id;