create table customer_transactions(
transaction_id int primary key,
customer_id int,
transaction_date date,
amount decimal(10,2),
transaction_type varchar(20)
);

insert into customer_transactions values
(1, 101, '2024-01-05', 150.00, 'purchase'),
(2, 101, '2024-01-15', 200.00, 'purchase'),
(3, 101, '2024-02-10', 180.00, 'purchase'),
(4, 101, '2024-02-20', 250.00, 'purchase'),
(5, 102, '2024-01-10', 100.00, 'purchase'),
(6, 102, '2024-01-12', 120.00, 'purchase'),
(7, 102, '2024-01-15', 80.00,  'refund'),
(8, 102, '2024-01-18', 90.00,  'refund'),
(9, 102, '2024-02-15', 130.00, 'purchase'),
(10,103, '2024-01-01', 500.00, 'purchase'),
(11,103, '2024-01-02', 450.00, 'purchase'),
(12,103, '2024-01-03', 400.00, 'purchase'),
(13,104, '2024-01-01', 200.00, 'purchase'),
(14,104, '2024-02-01', 250.00, 'purchase'),
(15,104, '2024-02-15', 300.00, 'purchase'),
(16,104, '2024-03-01', 350.00, 'purchase'),
(17,104, '2024-03-10', 280.00, 'purchase'),
(18,104, '2024-03-15', 100.00, 'refund');

select * from customer_transactions;




WITH stats AS (
    SELECT 
        customer_id,
        SUM(CASE WHEN transaction_type = 'purchase' THEN 1 ELSE 0 END) AS purchase_count,
        SUM(CASE WHEN transaction_type = 'refund' THEN 1 ELSE 0 END) AS refund_count,
        COUNT(*) AS total_transactions,
        DATEDIFF(DAY, MIN(transaction_date), MAX(transaction_date)) AS active_days
    FROM customer_transactions
    GROUP BY customer_id
),

filtered AS (
    SELECT 
        customer_id,
        purchase_count,
        refund_count,
        total_transactions,
        active_days,
        (CAST(refund_count AS DECIMAL(10,2)) / total_transactions) AS refund_rate
    FROM stats
    WHERE 
        purchase_count >= 3             
        AND active_days >= 30          
)

SELECT customer_id
FROM filtered
WHERE refund_rate < 0.20                   
ORDER BY customer_id ASC;
