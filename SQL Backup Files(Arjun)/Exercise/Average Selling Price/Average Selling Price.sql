create table Prices(
product_id int,
start_date date,
end_date date,
price int,
primary key (product_id, start_date, end_date)
);

insert into Prices values
(1, '2019-02-17', '2019-02-28', 5),
(1, '2019-03-01', '2019-03-22', 20),
(2, '2019-02-01', '2019-02-20', 15),
(2, '2019-02-21', '2019-03-31', 30);

select * from Prices;


create table UnitsSold(
product_id int,
purchase_date date,
units int
);

insert into UnitsSold values
(1, '2019-02-25', 100),
(1, '2019-03-01', 15),
(2, '2019-02-10', 200),
(2, '2019-03-22', 30);

select * from UnitsSold;




SELECT u.product_id,
    ROUND(SUM(u.units * p.price) / SUM(u.units), 2) AS average_price
FROM UnitsSold u
JOIN Prices p
ON u.product_id = p.product_id
    AND u.purchase_date BETWEEN p.start_date AND p.end_date
GROUP BY u.product_id;