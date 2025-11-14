create table Transactions(
id int primary key,
country varchar(50),
state varchar(20),
amount int,
trans_date date
);

insert into Transactions values
(121,'US','approved',1000,'2018-12-18'),
(122,'US','declined',2000,'2018-12-19'),
(123,'US','approved',2000,'1019-01-01'),
(124,'DE','approved',2000,'2019-01-07');

select * from Transactions;



SELECT
    FORMAT(trans_date, 'yyyy-MM') AS month,
    country,
    COUNT(id) AS trans_count,
    SUM(CASE WHEN state = 'approved' THEN 1 ELSE 0 END) AS approved_count,
    SUM(amount) AS trans_total_amount,
    SUM(CASE WHEN state = 'approved' THEN amount ELSE 0 END) AS approved_total_amount
FROM Transactions
GROUP BY FORMAT(trans_date, 'yyyy-MM'), country
ORDER BY month, country;
