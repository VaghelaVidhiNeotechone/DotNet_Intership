create table Visits(
visit_id int primary key,
customer_id int
);

insert into Visits values
(1,23),
(2,9),
(4,30),
(5,54),
(6,96),
(7,54),
(8,54);

select * from Visits;


create table TransactionsCustomer(
transaction_id int primary key,
visit_id int,
amount int
);

insert into TransactionsCustomer values
(2, 5, 310),
(3, 5, 300),
(9, 5, 200),
(12, 1, 910),
(13, 2, 970);

select * from TransactionsCustomer;




SELECT v.customer_id,
    COUNT(v.visit_id) AS count_no_trans
FROM Visits v
LEFT JOIN TransactionsCustomer t
ON v.visit_id = t.visit_id
WHERE t.transaction_id IS NULL
GROUP BY v.customer_id
ORDER BY v.customer_id;