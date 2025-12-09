use DBLeetCode2;

CREATE TABLE Users4 (
    user_id INT PRIMARY KEY,
    email VARCHAR(255)
);

INSERT INTO Users4 (user_id, email) VALUES
(1, 'user1@example.com'),
(2, 'ali.ce@example.com'),
(3, 'alice@bob.com'),
(4, 'alice@bob.org'),
(5, 'alice_bob@example.com'),
(6, '@example.com'),
(7, 'user!@example.com'),
(8, 'test@.com'),
(9, 'user@domain.net');

select * from Users4;

SELECT user_id, email
FROM Users4
WHERE
    CHARINDEX('@', email) > 0 
    AND CHARINDEX('@', email) = REVERSE(CHARINDEX(REVERSE('@'), email)) 
    AND RIGHT(email, 4) = '.com'
    AND PATINDEX('%[^a-zA-Z0-9_]%', LEFT(email, CHARINDEX('@', email) - 1)) = 0
    AND LEFT(email, CHARINDEX('@', email) - 1) <> ''
    AND PATINDEX('%[^a-zA-Z]%', SUBSTRING(email, CHARINDEX('@', email) + 1, LEN(email) - CHARINDEX('@', email) - 4)) = 0
    AND SUBSTRING(email, CHARINDEX('@', email) + 1, LEN(email) - CHARINDEX('@', email) - 4) <> ''
ORDER BY user_id ASC;
