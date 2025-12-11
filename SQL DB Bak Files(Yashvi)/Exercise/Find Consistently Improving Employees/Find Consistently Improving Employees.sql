use DBLeetCode2;

-- Solution for SQL Server (SSMS)

-- Create the employees table
CREATE TABLE employees7 (
    employee_id INT PRIMARY KEY,
    name VARCHAR(255)
);

-- Create the performance_reviews table
CREATE TABLE performance_reviews (
    review_id INT PRIMARY KEY,
    employee_id INT,
    review_date DATE,
    rating INT,
    FOREIGN KEY (employee_id) REFERENCES employees7(employee_id)
);

-- Insert sample data into employees
INSERT INTO employees7 (employee_id, name) VALUES
(1, 'Alice Johnson'),
(2, 'Bob Smith'),
(3, 'Carol Davis'),
(4, 'David Wilson'),
(5, 'Emma Brown');

-- Insert sample data into performance_reviews
INSERT INTO performance_reviews (review_id, employee_id, review_date, rating) VALUES
(1, 1, '2023-01-15', 2),
(2, 1, '2023-04-15', 3),
(3, 1, '2023-07-15', 4),
(4, 1, '2023-10-15', 5),
(5, 2, '2023-02-01', 3),
(6, 2, '2023-05-01', 2),
(7, 2, '2023-08-01', 4),
(8, 2, '2023-11-01', 5),
(9, 3, '2023-03-10', 1),
(10, 3, '2023-06-10', 2),
(11, 3, '2023-09-10', 3),
(12, 3, '2023-12-10', 4),
(13, 4, '2023-01-20', 4),
(14, 4, '2023-04-20', 4),
(15, 4, '2023-07-20', 4),
(16, 5, '2023-02-15', 3),
(17, 5, '2023-05-15', 2);

select* from employees7;
select * from performance_reviews;

WITH cte AS(
    SELECT employee_id, review_date, rating, 
        LEAD(rating) OVER(PARTITION BY employee_id ORDER BY review_date) AS next_rating,
        LEAD(rating) OVER(PARTITION BY employee_id ORDER BY review_date) - rating  AS diff,
        ROW_NUMBER() OVER (PARTITION BY employee_id  ORDER BY review_date DESC) AS rank
    FROM performance_reviews)
 SELECT c.employee_id, e.name,
    SUM(c.diff) AS improvement_score
FROM cte c
INNER JOIN employees7 e ON c.employee_id = e.employee_id
WHERE c.rank <=3 AND c.diff > 0
GROUP BY  c.employee_id, e.name
HAVING MAX(rank) >= 3 AND SUM(c.diff) > 1
ORDER BY improvement_score DESC, name ASC
 
