create table ProductIII(
product_id int primary key,
product_name varchar(50),
unit_price int
);

insert into ProductIII values
(1, 'S8', 1000),
(2, 'G4', 800),
(3, 'iPhone', 1400);

select * from ProductIII;


create table SalesIII(
seller_id int,
product_id int,
buyer_id int,
sale_date Date,
quantity int,
price int,
foreign key (product_id) references ProductIII(product_id)
);

insert into SalesIII values
(1, 1, 1, '2019-01-21', 2, 2000),
(1, 2, 2, '2019-02-17', 1, 800),
(2, 2, 3, '2019-06-02', 1, 800),
(3, 3, 4, '2019-05-13', 2, 2800);

select * from SalesIII;



SELECT p.product_id, p.product_name FROM ProductIII p
WHERE p.product_id IN (
SELECT s.product_id
FROM SalesIII s
WHERE s.sale_date BETWEEN '2019-03-01' AND '2019-05-31'
)
AND p.product_id NOT IN (
SELECT s.product_id FROM SalesIII s
WHERE s.sale_date < '2019-03-01' OR s.sale_date > '2019-05-31'
);