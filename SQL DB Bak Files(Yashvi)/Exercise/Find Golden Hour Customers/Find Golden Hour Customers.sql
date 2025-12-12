use DBLeetCode2;

CREATE TABLE restaurant_orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_timestamp DATETIME,
    order_amount DECIMAL(10, 2),
    payment_method VARCHAR(255) CHECK (payment_method IN ('cash', 'card', 'app')),
    order_rating INT NULL
);

INSERT INTO restaurant_orders (order_id, customer_id, order_timestamp, order_amount, payment_method, order_rating) VALUES
(1, 101, '2024-03-01 12:30:00', 25.50, 'card', 5),
(2, 101, '2024-03-02 19:15:00', 32.00, 'app', 4),
(3, 101, '2024-03-03 13:45:00', 28.75, 'card', 5),
(4, 101, '2024-03-04 20:30:00', 41.00, 'app', NULL),
(5, 102, '2024-03-01 11:30:00', 18.50, 'cash', 4),
(6, 102, '2024-03-02 12:00:00', 22.00, 'card', 3),
(7, 102, '2024-03-03 15:30:00', 19.75, 'cash', NULL),
(8, 103, '2024-03-01 19:00:00', 55.00, 'app', 5),
(9, 103, '2024-03-02 20:45:00', 48.50, 'app', 4),
(10, 103, '2024-03-03 18:30:00', 62.00, 'card', 5),
(11, 104, '2024-03-01 10:00:00', 15.00, 'cash', 3),
(12, 104, '2024-03-02 09:30:00', 18.00, 'cash', 2),
(13, 104, '2024-03-03 16:00:00', 20.00, 'card', 3),
(14, 105, '2024-03-01 12:15:00', 30.00, 'app', 4),
(15, 105, '2024-03-02 13:00:00', 35.50, 'app', 5),
(16, 105, '2024-03-03 11:45:00', 28.00, 'card', 4);

select * from restaurant_orders;

SELECT customer_id,
    COUNT(order_id) AS total_orders,
    CAST(SUM(CASE 
        WHEN DATEPART(HOUR, order_timestamp) BETWEEN 11 AND 13 THEN 1 
        WHEN DATEPART(HOUR, order_timestamp) BETWEEN 18 AND 20 THEN 1
        ELSE 0 
    END) AS DECIMAL(5,2)) * 100.0 / COUNT(order_id) AS peak_hour_percentage,
    ROUND(AVG(CAST(order_rating AS FLOAT)), 2) AS average_rating
FROM  restaurant_orders
GROUP BY customer_id
HAVING
    COUNT(order_id) >= 3
    AND (
        CAST(SUM(CASE 
            WHEN DATEPART(HOUR, order_timestamp) BETWEEN 11 AND 13 THEN 1 
            WHEN DATEPART(HOUR, order_timestamp) BETWEEN 18 AND 20 THEN 1 
            ELSE 0 
        END) AS DECIMAL(5,2)) * 100.0 / COUNT(order_id)
    ) >= 60.0
    AND AVG(CAST(order_rating AS FLOAT)) >= 4.0
     AND (
        CAST(SUM(CASE WHEN order_rating IS NOT NULL THEN 1 ELSE 0 END) AS DECIMAL(5,2)) * 100.0 / COUNT(order_id)
    ) >= 50.0
ORDER BY average_rating DESC, customer_id DESC;
