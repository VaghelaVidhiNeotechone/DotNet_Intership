create table books(
book_id int primary key,
title varchar(200),
author varchar(100),
genre varchar(100),
pages int
);

insert into books values
(1, 'The Great Gatsby', 'F. Scott', 'Fiction', 180),
(2, 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', 281),
(3, '1984', 'George Orwell', 'Dystopian', 328),
(4, 'Pride and Prejudice', 'Jane Austen', 'Romance', 432),
(5, 'The Catcher in the Rye', 'J.D. Salinger', 'Fiction', 277);

select * from books;


create table reading_sessions(
session_id int primary key,
book_id int,
reader_name varchar(100),
pages_read int,
session_rating int,
foreign key (book_id) references books(book_id)
);

insert into reading_sessions values
(1, 1, 'Alice', 50, 5),
(2, 1, 'Bob', 60, 1),
(3, 1, 'Carol', 40, 4),
(4, 1, 'David', 30, 2),
(5, 1, 'Emma', 45, 5),
(6, 2, 'Frank', 80, 4),
(7, 2, 'Grace', 70, 4),
(8, 2, 'Henry', 90, 5),
(9, 2, 'Ivy', 60, 4),
(10, 2, 'Jack', 75, 4),
(11, 3, 'Kate', 100, 2),
(12, 3, 'Liam', 120, 1),
(13, 3, 'Mia', 80, 2),
(14, 3, 'Noah', 90, 1),
(15, 3, 'Olivia', 110, 4),
(16, 3, 'Paul', 95, 5),
(17, 4, 'Quinn', 150, 3),
(18, 4, 'Ruby', 140, 3),
(19, 5, 'Sam', 80, 1),
(20, 5, 'Tara', 70, 2);

select * from reading_sessions;




WITH session_stats AS (
    SELECT 
        book_id,
        COUNT(*) AS total_sessions,
        MIN(session_rating) AS lowest_rating,
        MAX(session_rating) AS highest_rating,
        SUM(CASE WHEN session_rating <= 2 OR session_rating >= 4 THEN 1 ELSE 0 END) AS extreme_ratings,
        SUM(CASE WHEN session_rating >= 4 THEN 1 ELSE 0 END) AS high_ratings,
        SUM(CASE WHEN session_rating <= 2 THEN 1 ELSE 0 END) AS low_ratings
    FROM reading_sessions
    GROUP BY book_id
),

qualified_books AS (
    SELECT 
        book_id,
        total_sessions,
        lowest_rating,
        highest_rating,
        extreme_ratings,
        CAST(extreme_ratings AS FLOAT) / total_sessions AS polarization_score
    FROM session_stats
    WHERE 
        total_sessions >= 5
        AND high_ratings > 0
        AND low_ratings > 0
        AND (CAST(extreme_ratings AS FLOAT) / total_sessions) >= 0.6
)

SELECT 
    b.book_id,
    b.title,
    b.author,
    b.genre,
    b.pages,
    (qb.highest_rating - qb.lowest_rating) AS rating_spread,
    ROUND(qb.polarization_score, 2) AS polarization_score
FROM qualified_books qb
JOIN books b ON b.book_id = qb.book_id
ORDER BY 
    polarization_score DESC,
    b.title DESC;
