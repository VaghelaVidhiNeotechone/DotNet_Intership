use DBLeetCode2;

CREATE TABLE customer_transactions (
    transaction_id INT PRIMARY KEY,
    customer_id INT,
    transaction_date DATE,
    amount DECIMAL(10, 2),
    transaction_type VARCHAR(255) CHECK (transaction_type IN ('purchase', 'refund'))
);

INSERT INTO customer_transactions (transaction_id, customer_id, transaction_date, amount, transaction_type) VALUES
(1, 101, '2024-01-05', 150.00, 'purchase'),
(2, 101, '2024-01-15', 200.00, 'purchase'),
(3, 101, '2024-02-10', 180.00, 'purchase'),
(4, 101, '2024-02-20', 250.00, 'purchase'),
(5, 102, '2024-01-10', 100.00, 'purchase'),
(6, 102, '2024-01-12', 120.00, 'purchase'),
(7, 102, '2024-01-15', 80.00, 'refund'),
(8, 102, '2024-01-18', 90.00, 'refund'),
(9, 102, '2024-02-15', 130.00, 'purchase'),
(10, 103, '2024-01-01', 500.00, 'purchase'),
(11, 103, '2024-01-02', 450.00, 'purchase'),
(12, 103, '2024-01-03', 400.00, 'purchase'),
(13, 104, '2024-01-01', 200.00, 'purchase'),
(14, 104, '2024-02-01', 250.00, 'purchase'),
(15, 104, '2024-02-15', 300.00, 'purchase'),
(16, 104, '2024-03-01', 350.00, 'purchase'),
(17, 104, '2024-03-10', 280.00, 'purchase'),
(18, 104, '2024-03-15', 100.00, 'refund');

select * from customer_transactions;

SELECT customer_id
FROM customer_transactions GROUP BY customer_id
HAVING
    SUM(CASE WHEN transaction_type = 'purchase' THEN 1 ELSE 0 END) >= 3
    AND DATEDIFF(DAY, MIN(transaction_date), MAX(transaction_date)) >= 30
    AND (
        CAST(SUM(CASE WHEN transaction_type = 'refund' THEN 1 ELSE 0 END) AS DECIMAL(5, 2)) /
        COUNT(transaction_id)) < 0.20
ORDER BY customer_id ASC;
