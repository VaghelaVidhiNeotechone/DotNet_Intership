use DBLeetCode2;

CREATE TABLE transactions2 (
    transaction_id INT PRIMARY KEY,
    amount INT,
    transaction_date DATE
);

INSERT INTO transactions2 (transaction_id, amount, transaction_date) VALUES
(1, 100, '2023-01-01'),
(2, 200, '2023-01-01'),
(3, 150, '2023-01-02'),
(4, 50, '2023-01-02'),
(5, 10, '2023-01-03'),
(6, 400, '2023-01-03'),
(7, 50, '2023-01-04'), 
(8, 120, '2023-01-05'); 

select * from transactions2;

SELECT
    transaction_date,
    SUM(CASE WHEN transaction_id % 2 != 0 THEN amount ELSE 0 END) AS odd_transactions_sum,
    SUM(CASE WHEN transaction_id % 2 = 0 THEN amount ELSE 0 END) AS even_transactions_sum
FROM transactions2 GROUP BY transaction_date ORDER BY transaction_date ASC;
