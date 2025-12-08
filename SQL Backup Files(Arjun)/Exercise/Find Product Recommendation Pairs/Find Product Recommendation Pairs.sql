create table ProductPurchases(
user_id int,
product_id int,
quantity int,
primary key(user_id, product_id)
);

insert into ProductPurchases values
(1, 101, 2),
(1, 102, 1),
(1, 103, 3),

(2, 101, 1),
(2, 102, 5),
(2, 104, 1),

(3, 101, 2),
(3, 103, 1),
(3, 105, 4),

(4, 101, 1),
(4, 102, 1),
(4, 103, 2),
(4, 104, 3),

(5, 102, 2),
(5, 104, 1);

select * from ProductPurchases;


create table ProductInfo(
product_id int primary key,
category varchar(50),
price decimal(10,2)
);

insert into ProductInfo values
(101, 'Electronics', 100),
(102, 'Books', 20),
(103, 'Clothing', 35),
(104, 'Kitchen', 50),
(105, 'Sports', 75);

select * from ProductInfo;




SELECT
    p1.product_id AS product1_id,
    p2.product_id AS product2_id,
    i1.category AS product1_category,
    i2.category AS product2_category,
    COUNT(*) AS customer_count
FROM ProductPurchases p1
JOIN ProductPurchases p2
    ON p1.user_id = p2.user_id
    AND p1.product_id < p2.product_id  
JOIN ProductInfo i1 ON p1.product_id = i1.product_id
JOIN ProductInfo i2 ON p2.product_id = i2.product_id
GROUP BY
    p1.product_id,
    p2.product_id,
    i1.category,
    i2.category
HAVING COUNT(*) >= 3 
ORDER BY customer_count DESC;