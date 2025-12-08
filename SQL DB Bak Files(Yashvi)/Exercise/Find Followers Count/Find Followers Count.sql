use DBLeetCode2;


CREATE TABLE Followers (
    user_id INT,
    follower_id INT,
    PRIMARY KEY (user_id, follower_id)
);

INSERT INTO Followers (user_id, follower_id) VALUES
(0, 1),
(1, 0),
(2, 0),
(2, 1);

select * from Followers;

SELECT user_id, COUNT(follower_id) AS followers_count FROM Followers
GROUP BY user_id ORDER BY user_id ASC;
