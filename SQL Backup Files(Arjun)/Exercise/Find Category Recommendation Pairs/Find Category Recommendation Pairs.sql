create table ProductPurchas (
    user_id int,
    product_id int,
    quantity int,
    primary key (user_id, product_id)
);

insert into ProductPurchas values
(1, 101, 2),
(1, 102, 1),
(1, 201, 3),
(1, 301, 1),

(2, 101, 1),
(2, 102, 2),
(2, 103, 1),
(2, 201, 5),

(3, 101, 2),
(3, 103, 1),
(3, 301, 4),
(3, 401, 2),

(4, 101, 1),
(4, 201, 3),
(4, 301, 1),
(4, 401, 2),

(5, 102, 2),
(5, 103, 1),
(5, 201, 2),
(5, 202, 3);

select * from ProductPurchas;


create table Info (
    product_id int primary key,
    category varchar(50),
    price decimal(10,2)
);

insert into Info values
(101, 'Electronics', 100),
(102, 'Books', 20),
(103, 'Books', 35),
(201, 'Clothing', 45),
(202, 'Clothing', 60),
(301, 'Sports', 75),
(401, 'Kitchen', 50);

select * from Info;



WITH UserCategories AS (
    SELECT DISTINCT
        p.user_id,
        i.category
    FROM ProductPurchas p
    JOIN Info i 
        ON p.product_id = i.product_id
),
CategoryPairs AS (
    SELECT 
        c1.user_id,
        c1.category AS category1,
        c2.category AS category2
    FROM UserCategories c1
    JOIN UserCategories c2
        ON c1.user_id = c2.user_id
        AND c1.category < c2.category 
)
SELECT
    category1,
    category2,
    COUNT(*) AS customer_count
FROM CategoryPairs
GROUP BY category1, category2
HAVING COUNT(*) >= 3
ORDER BY customer_count DESC;