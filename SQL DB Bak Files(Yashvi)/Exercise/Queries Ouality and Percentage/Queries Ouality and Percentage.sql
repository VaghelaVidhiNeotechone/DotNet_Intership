use DBLeetCode;

CREATE TABLE Queries (
    query_name VARCHAR(255),
    result VARCHAR(255),
    position INT,
    rating INT
);

INSERT INTO Queries (query_name, result, position, rating) VALUES
('Dog', 'Golden Retriever', 1, 5),
('Dog', 'German Shepherd', 2, 5),
('Dog', 'Corgi', 3, 5),
('Bird', 'White Necked Raven', 1, 3),
('Bird', 'Bald Eagle', 2, 4),
('Bird', 'House Sparrow', 3, 1);

select * from Queries;

SELECT query_name, ROUND(AVG(CAST(rating AS FLOAT) / position), 2) AS quality,
    ROUND((SUM(CASE WHEN rating < 3 THEN 1 ELSE 0 END) * 100.0) / COUNT(*), 2) AS poor_query_percentage
FROM Queries GROUP BY query_name;
