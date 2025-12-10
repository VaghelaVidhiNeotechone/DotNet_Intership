use DBLeetCode2;

CREATE TABLE ProductPurchases (
    user_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY (user_id, product_id)
);

CREATE TABLE ProductInfo (
    product_id INT PRIMARY KEY,
    category VARCHAR(255),
    price DECIMAL(10, 2)
);

INSERT INTO ProductPurchases (user_id, product_id, quantity) VALUES
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

INSERT INTO ProductInfo (product_id, category, price) VALUES
(101, 'Electronics', 100.00),
(102, 'Books', 20.00),
(103, 'Clothing', 35.00),
(104, 'Kitchen', 50.00),
(105, 'Sports', 75.00);

select * from ProductPurchases;
select * from ProductInfo;

SELECT PP1.product_id AS product1_id, PP2.product_id AS product2_id, PI1.category AS product1_category,
    PI2.category AS product2_category, COUNT(PP1.user_id) AS customer_count
FROM ProductPurchases PP1
JOIN
    ProductPurchases PP2 
    ON PP1.user_id = PP2.user_id         
    AND PP1.product_id < PP2.product_id    
JOIN
    ProductInfo PI1 ON PP1.product_id = PI1.product_id
JOIN
    ProductInfo PI2 ON PP2.product_id = PI2.product_id
GROUP BY PP1.product_id, PP2.product_id, PI1.category, PI2.category
HAVING COUNT(PP1.user_id) >= 3 -- Filter for pairs purchased by at least 3 customers
ORDER BY customer_count DESC, product1_id ASC, product2_id ASC;
