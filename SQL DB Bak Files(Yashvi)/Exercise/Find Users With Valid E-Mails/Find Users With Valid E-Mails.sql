use DBLeetCode;

CREATE TABLE Users4 (
    user_id INT PRIMARY KEY,
    name VARCHAR(255),
    mail VARCHAR(255)
);

INSERT INTO Users4 (user_id, name, mail) VALUES
(1, 'IsValid', 'isValid@leetcode.com'),
(2, 'IsNotValid', 'isNotValid'),
(3, 'IsValid2', 'is-Valid_2@leetcode.com'),
(4, 'IsInvalid', '.isInvalid@leetcode.com'), 
(5, 'IsInvalid2', 'isInvalid2@leetcodedotcom'),
(6, 'IsInvalid3', 'invalid-email@leetcode.com.');

select * from Users4;

SELECT user_id, name, mail FROM Users4
WHERE mail LIKE '%@leetcode.com' AND mail NOT LIKE '%[._-]@leetcode.com' AND mail LIKE '[a-zA-Z]%';
