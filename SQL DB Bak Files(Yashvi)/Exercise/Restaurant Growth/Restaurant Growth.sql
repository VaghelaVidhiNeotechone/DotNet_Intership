use DBLeetCode;

CREATE TABLE Customer (
    customer_id INT,
    name VARCHAR(255),
    visited_on DATE,
    amount INT,
    PRIMARY KEY (customer_id, visited_on)
);

INSERT INTO Customer (customer_id, name, visited_on, amount) VALUES
(1, 'Jhon', '2019-01-01', 100),
(2, 'Daniel', '2019-01-02', 110),
(3, 'James', '2019-01-03', 120),
(4, 'River', '2019-01-04', 130),
(5, 'Cooper', '2019-01-05', 140),
(6, 'Liam', '2019-01-06', 150),
(7, 'Noah', '2019-01-07', 160),
(8, 'Oliver', '2019-01-08', 170),
(9, 'Isabella', '2019-01-09', 180),
(10, 'Emma', '2019-01-10', 190),
(11, 'Emily', '2019-01-11', 200),
(12, 'Mia', '2019-01-12', 210),
(13, 'Sophia', '2019-01-13', 220);

select * from Customer;

SELECT   visited_on, 
         SUM(SUM(amount)) OVER(ORDER BY visited_on ROWS BETWEEN 6 PRECEDING AND CURRENT ROW)   AS'amount',
         ROUND(CAST(SUM(SUM(amount)) OVER(ORDER BY visited_on ROWS BETWEEN 6 PRECEDING AND CURRENT ROW) AS FLOAT)/7.0 ,2) AS'average_amount' 
FROM     Customer 
GROUP BY visited_on
ORDER BY visited_on
OFFSET 6 ROWS  