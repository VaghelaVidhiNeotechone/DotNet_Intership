use DBLeetCode2;

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(255),
    location VARCHAR(255)
);

CREATE TABLE inventory (
    inventory_id INT PRIMARY KEY,
    store_id INT,
    product_name VARCHAR(255),
    quantity INT,
    price DECIMAL(10, 2),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

INSERT INTO stores (store_id, store_name, location) VALUES
(1, 'Downtown Tech', 'New York'),
(2, 'Suburb Mall', 'Chicago'),
(3, 'City Center', 'Los Angeles'),
(4, 'Corner Shop', 'Miami'),
(5, 'Plaza Store', 'Seattle');

INSERT INTO inventory (inventory_id, store_id, product_name, quantity, price) VALUES
(1, 1, 'Laptop', 5, 999.99), (2, 1, 'Mouse', 50, 19.99), (3, 1, 'Keyboard', 25, 79.99), (4, 1, 'Monitor', 15, 299.99),
(5, 2, 'Phone', 3, 699.99), (6, 2, 'Charger', 100, 25.99), (7, 2, 'Case', 75, 15.99), (8, 2, 'Headphones', 20, 149.99),
(9, 3, 'Tablet', 2, 499.99), (10, 3, 'Stylus', 80, 29.99), (11, 3, 'Cover', 60, 39.99),
(12, 4, 'Watch', 10, 299.99), (13, 4, 'Band', 25, 49.99),
(14, 5, 'Camera', 8, 599.99), (15, 5, 'Lens', 12, 199.99);

select * from stores;
select * from inventory;

WITH cte AS (
    SELECT s.store_id, s.store_name, s.location,
        MAX(i.price) AS mx_price,
        MIN(i.price) AS mn_price
    FROM inventory i
    INNER JOIN stores s 
        ON i.store_id = s.store_id
    GROUP BY s.store_id, s.store_name, s.location
    HAVING COUNT(DISTINCT i.product_name) > 2),
max_product AS (
    SELECT c.store_id, c.store_name, c.location, i.quantity, i.product_name AS most_exp_product
    FROM cte c
    INNER JOIN inventory i  
        ON c.store_id = i.store_id
        AND i.price = c.mx_price),
min_product AS (
    SELECT c.store_id, c.store_name, c.location, i.quantity, i.product_name AS cheapest_product
    FROM cte c
    INNER JOIN inventory i  
        ON c.store_id = i.store_id
        AND i.price = c.mn_price)
SELECT c2.store_id, c2.store_name, c2.location, c2.most_exp_product, c3.cheapest_product,
    ROUND(c3.quantity * 1.0 / c2.quantity, 2) AS imbalance_ratio
FROM max_product c2
INNER JOIN min_product c3 
    ON c2.store_id = c3.store_id
WHERE c2.quantity < c3.quantity
ORDER BY imbalance_ratio DESC, c2.store_name ASC;
