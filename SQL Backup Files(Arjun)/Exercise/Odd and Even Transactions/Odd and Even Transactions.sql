create table TransactionsOdd(
transaction_id int primary key,
amount int,
transaction_date date
);

insert into TransactionsOdd values
(1,150,'2024-07-01'),
(2,200,'2024-07-01'),
(3,75,'2024-07-01'),
(4,300,'2024-07-02'),
(5,50,'2024-07-02'),
(6,120,'2024-07-03');

select * from TransactionsOdd;




SELECT transaction_date,
    SUM(CASE WHEN amount % 2 = 1 THEN amount ELSE 0 END) AS odd_sum,
    SUM(CASE WHEN amount % 2 = 0 THEN amount ELSE 0 END) AS even_sum
FROM TransactionsOdd
GROUP BY transaction_date
ORDER BY transaction_date;