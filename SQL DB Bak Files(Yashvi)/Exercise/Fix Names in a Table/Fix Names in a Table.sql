use DBLeetCode2;

CREATE TABLE Users3 (
    user_id INT PRIMARY KEY,
    name VARCHAR(255)
);

INSERT INTO Users3 (user_id, name) VALUES
(1, 'aLice'),
(2, 'bOB'),
(3, 'cHRistian');

select * from Users3;

SELECT user_id, UPPER(LEFT(name, 1)) + LOWER(SUBSTRING(name, 2, LEN(name) - 1)) AS name
FROM Users3 ORDER BY user_id;
