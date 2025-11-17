use DBLeetCode;

CREATE TABLE Movies (
    movie_id INT PRIMARY KEY,
    title VARCHAR(255)
);

CREATE TABLE Users2 (
    user_id INT PRIMARY KEY,
    name VARCHAR(255)
);

CREATE TABLE MovieRating (
    movie_id INT FOREIGN KEY REFERENCES Movies(movie_id),
    user_id INT FOREIGN KEY REFERENCES Users(user_id),
    rating INT,
    created_at DATE,
    PRIMARY KEY (movie_id, user_id)
);

INSERT INTO Movies (movie_id, title) VALUES
(1, 'Avengers'),
(2, 'Frozen 2'),
(3, 'Joker');

INSERT INTO Users2 (user_id, name) VALUES
(1, 'Daniel'),
(2, 'Monica'),
(3, 'Chris'),
(4, 'Alex');

INSERT INTO MovieRating (movie_id, user_id, rating, created_at) VALUES
(1, 1, 3, '2020-01-12'), 
(1, 2, 4, '2020-02-11'), 
(1, 3, 2, '2020-01-01'), 
(2, 1, 5, '2020-02-17'), 
(2, 3, 4, '2020-02-01'), 
(3, 1, 3, '2020-01-01'),
(3, 2, 4, '2020-03-01'); 

select * from Movies;
select * from Users2;
select * from MovieRating;

WITH UserWithMostRatings AS (
 SELECT TOP 1 u.name AS result FROM Users2 u
    JOIN MovieRating mr ON u.user_id = mr.user_id
    GROUP BY u.user_id, u.name ORDER BY COUNT(mr.movie_id) DESC, u.name ASC              
),
MovieWithHighestAvgRating AS (
    SELECT TOP 1 m.title AS result FROM Movies m
    JOIN MovieRating mr ON m.movie_id = mr.movie_id
    WHERE YEAR(mr.created_at) = 2020 AND MONTH(mr.created_at) = 2
    GROUP BY m.movie_id, m.title ORDER BY AVG(CAST(mr.rating AS FLOAT)) DESC, m.title ASC                       
)

SELECT result FROM UserWithMostRatings
UNION ALL
SELECT result FROM MovieWithHighestAvgRating;
