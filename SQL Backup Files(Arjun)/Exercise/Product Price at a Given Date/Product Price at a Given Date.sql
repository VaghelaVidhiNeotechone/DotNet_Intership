create table Products(
product_id int,
new_price int,
change_date date,
primary key (product_id, change_date)
);

insert into Products values
(1,20,'2019-08-14'),
(2,50,'2019-08-14'),
(1,30,'2019-08-15'),
(1,35,'2019-08-16'),
(2,65,'2019-08-17'),
(3,20,'2019-08-18');

select * from Products;



SELECT p1.product_id,
ISNULL((
SELECT TOP 1 p2.new_price
FROM Products p2
WHERE p2.product_id = p1.product_id
AND p2.change_date <= '2019-08-16'
ORDER BY p2.change_date DESC
), 10) AS price
FROM (SELECT DISTINCT product_id FROM Products) AS p1
ORDER BY p1.product_id;