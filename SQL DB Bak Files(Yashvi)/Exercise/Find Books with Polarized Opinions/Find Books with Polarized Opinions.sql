use DBLeetCode2;

CREATE TABLE books (
    book_id INT PRIMARY KEY,
    title VARCHAR(255),
    author VARCHAR(255),
    genre VARCHAR(255),
    pages INT
);

CREATE TABLE reading_sessions (
    session_id INT PRIMARY KEY,
    book_id INT,
    reader_name VARCHAR(255),
    pages_read INT,
    session_rating INT,
    FOREIGN KEY (book_id) REFERENCES books(book_id)
);

INSERT INTO books (book_id, title, author, genre, pages) VALUES
(1, 'The Great Gatsby', 'F. Scott', 'Fiction', 180),
(2, 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', 281),
(3, '1984', 'George Orwell', 'Dystopian', 328),
(4, 'Pride and Prejudice', 'Jane Austen', 'Romance', 432),
(5, 'The Catcher in the Rye', 'J.D. Salinger', 'Fiction', 277);

INSERT INTO reading_sessions (session_id, book_id, reader_name, pages_read, session_rating) VALUES
(1, 1, 'Alice', 50, 5), (2, 1, 'Bob', 60, 1), (3, 1, 'Carol', 40, 4), (4, 1, 'David', 30, 2), (5, 1, 'Emma', 45, 5),
(6, 2, 'Frank', 80, 4), (7, 2, 'Grace', 70, 4), (8, 2, 'Henry', 90, 5), (9, 2, 'Ivy', 60, 4), (10, 2, 'Jack', 75, 4),
(11, 3, 'Kate', 100, 2), (12, 3, 'Liam', 120, 1), (13, 3, 'Mia', 80, 2), (14, 3, 'Noah', 90, 1), (15, 3, 'Olivia', 110, 4), (16, 3, 'Paul', 95, 5),
(17, 4, 'Quinn', 150, 3), (18, 4, 'Ruby', 140, 3),
(19, 5, 'Sam', 80, 1), (20, 5, 'Tara', 70, 2);

-- Solution for SQL Server (SSMS) - Inserting Gujarati names into existing example data

-- Assuming the tables 'books' and 'reading_sessions' have been created as in previous examples.

-- Update existing reader names to Gujarati names for the sample data provided previously
UPDATE reading_sessions
SET reader_name = 'Riya' WHERE session_id = 1;

UPDATE reading_sessions
SET reader_name = 'Yash' WHERE session_id = 2;

UPDATE reading_sessions
SET reader_name = 'Bhoomi' WHERE session_id = 3;

UPDATE reading_sessions
SET reader_name = 'Dev' WHERE session_id = 4;

UPDATE reading_sessions
SET reader_name = 'Hiral' WHERE session_id = 5;

UPDATE reading_sessions
SET reader_name = 'Jay' WHERE session_id = 6;

UPDATE reading_sessions
SET reader_name = 'Disha' WHERE session_id = 7;

UPDATE reading_sessions
SET reader_name = 'Vatsal' WHERE session_id = 8;

UPDATE reading_sessions
SET reader_name = 'Nitya' WHERE session_id = 9;

UPDATE reading_sessions
SET reader_name = 'Mahir' WHERE session_id = 10;

UPDATE reading_sessions
SET reader_name = 'Kavya' WHERE session_id = 11;

UPDATE reading_sessions
SET reader_name = 'Kian' WHERE session_id = 12;

UPDATE reading_sessions
SET reader_name = 'Aashvi' WHERE session_id = 13;

UPDATE reading_sessions
SET reader_name = 'Naitik' WHERE session_id = 14;

UPDATE reading_sessions
SET reader_name = 'Jalsa' WHERE session_id = 15;

UPDATE reading_sessions
SET reader_name = 'Hiren' WHERE session_id = 16;

UPDATE reading_sessions
SET reader_name = 'Tithi' WHERE session_id = 17;

UPDATE reading_sessions
SET reader_name = 'Dhvanit' WHERE session_id = 18;

UPDATE reading_sessions
SET reader_name = 'Siddharth' WHERE session_id = 19;

UPDATE reading_sessions
SET reader_name = 'Moksha' WHERE session_id = 20;

-- Optional: View the updated reading_sessions table
SELECT * FROM reading_sessions ORDER BY session_id;

select * from books;
select * from reading_sessions;

WITH BookRatingsAgg AS (
    SELECT book_id,
        COUNT(session_id) AS total_sessions,
        MAX(session_rating) AS highest_rating,
        MIN(session_rating) AS lowest_rating,
        SUM(CASE WHEN session_rating <= 2 OR session_rating >= 4 THEN 1 ELSE 0 END) AS extreme_ratings_count
    FROM reading_sessions GROUP BY book_id
    HAVING COUNT(session_id) >= 5 )
SELECT B.book_id, B.title, B.author, B.genre, B.pages,
    (BRA.highest_rating - BRA.lowest_rating) AS rating_spread,
    ROUND(CAST(BRA.extreme_ratings_count AS DECIMAL(5, 2)) / BRA.total_sessions, 2) AS polarization_score
FROM books B
JOIN
    BookRatingsAgg BRA ON B.book_id = BRA.book_id
WHERE BRA.highest_rating >= 4
    AND BRA.lowest_rating <= 2
    AND ROUND(CAST(BRA.extreme_ratings_count AS DECIMAL(5, 2)) / BRA.total_sessions, 2) >= 0.6
ORDER BY polarization_score DESC, B.title DESC;
