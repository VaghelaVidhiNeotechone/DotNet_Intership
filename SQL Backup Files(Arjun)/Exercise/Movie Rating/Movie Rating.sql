create table Movies(
movie_id int primary key,
title varchar(100)
);

insert into Movies values
(1, 'Avengers'),
(2, 'Frozen 2'),
(3, 'Joker');

select * from Movies;


create table UsersRating(
user_id int primary key,
name varchar(100)
);

insert into UsersRating values
(1, 'Daniel'),
(2, 'Monica'),
(3, 'Maria'),
(4, 'James');

select * from UsersRating;


create table MovieRating(
movie_id int,
user_id int,
rating int,
created_at date,
primary key (movie_id, user_id),
foreign key (movie_id) references Movies(movie_id),
foreign key (user_id) references UsersRating(user_id)
);

insert into MovieRating values
(1, 1, 3, '2020-02-12'),
(1, 2, 4, '2020-02-11'),
(1, 3, 2, '2020-02-12'),
(1, 4, 1, '2020-01-01'),
(2, 1, 5, '2020-02-17'),
(2, 2, 2, '2020-02-01'),
(2, 3, 2, '2020-03-01'),
(3, 1, 3, '2020-02-22'),
(3, 2, 4, '2020-02-25');

select * from MovieRating;





WITH feb_user_counts AS (
    SELECT 
        user_id,
        COUNT(DISTINCT movie_id) AS movie_count
    FROM MovieRating
    WHERE created_at >= '2020-02-01'
      AND created_at <  '2020-03-01'
    GROUP BY user_id
),
best_user AS (
    SELECT TOP 1 name AS results, 1 AS ord
    FROM UsersRating u
    JOIN feb_user_counts f
        ON u.user_id = f.user_id
    WHERE f.movie_count = 3
    ORDER BY name
),
feb_movies AS (
    SELECT 
        movie_id,
        AVG(CAST(rating AS FLOAT)) AS avg_rating
    FROM MovieRating
    WHERE created_at >= '2020-02-01'
      AND created_at <  '2020-03-01'
    GROUP BY movie_id
),
max_avg AS (
    SELECT MAX(avg_rating) AS max_rating
    FROM feb_movies
),
best_movie AS (
    SELECT TOP 1 title AS results, 2 AS ord
    FROM Movies m
    JOIN feb_movies fm
        ON m.movie_id = fm.movie_id
    JOIN max_avg ma
        ON fm.avg_rating = ma.max_rating
    ORDER BY title
)
SELECT results
FROM (
    SELECT * FROM best_user
    UNION ALL
    SELECT * FROM best_movie
) x
ORDER BY ord;