use DBLeetCode2;

CREATE TABLE Tweets (
    tweet_id INT PRIMARY KEY,
    content VARCHAR(255)
);

INSERT INTO Tweets (tweet_id, content) VALUES
(1, 'Vote for Biden'),
(3, 'Let us make India great again!');

select * from Tweets;
	
SELECT tweet_id FROM Tweets WHERE LEN(content) > 15;
