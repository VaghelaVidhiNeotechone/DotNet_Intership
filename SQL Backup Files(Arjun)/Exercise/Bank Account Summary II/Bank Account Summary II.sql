create table UsersAccount(
account int primary key,
name varchar(50)
);

insert into UsersAccount values
(900001, 'Alice'),
(900002, 'Bob'),
(900003, 'Charlie');

select * from UsersAccount;


create table TransactionsAccount(
trans_id int primary key,
account int,
amount int,
transacted_on date
);

insert into TransactionsAccount values
(1, 900001, 7000, '2020-08-01'),
(2, 900001, 7000, '2020-09-01'),
(3, 900001, -3000, '2020-09-02'),
(4, 900002, 1000, '2020-09-12'),
(5, 900003, 6000, '2020-08-07'),
(6, 900003, 6000, '2020-09-07'),
(7, 900003, -4000, '2020-09-11');

select * from TransactionsAccount;




SELECT TOP 1 u.name,
    SUM(t.amount) AS balance
FROM UsersAccount u
JOIN TransactionsAccount t
ON u.account = t.account
GROUP BY u.name
ORDER BY  balance DESC;
