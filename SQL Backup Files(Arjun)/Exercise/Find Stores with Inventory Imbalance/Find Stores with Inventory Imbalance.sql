create table stores(
store_id int primary key,
store_name varchar(100),
location varchar(100)
);

insert into stores values
(1, 'Downtown Tech', 'New York'),
(2, 'Suburb Mall', 'Chicago'),
(3, 'City Center', 'Los Angeles'),
(4, 'Corner Shop', 'Miami'),
(5, 'Plaza Store', 'Seattle');

select * from stores;


create table inventory(
inventory_id int primary key,
store_id int,
product_name varchar(100),
quantity int,
price decimal(10,2),
foreign key (store_id) references stores(store_id)
);

insert into inventory values
(1, 1, 'Laptop', 5, 999.99),
(2, 1, 'Mouse', 50, 19.99),
(3, 1, 'Keyboard', 25, 79.99),
(4, 1, 'Monitor', 15, 299.99),
(5, 2, 'Phone', 3, 699.99),
(6, 2, 'Charger', 100, 25.99),
(7, 2, 'Case', 75, 15.99),
(8, 2, 'Headphones', 20, 149.99),
(9, 3, 'Tablet', 2, 499.99),
(10, 3, 'Stylus', 80, 29.99),
(11, 3, 'Cover', 60, 39.99),
(12, 4, 'Watch', 10, 299.99),
(13, 4, 'Band', 25, 49.99),
(14, 5, 'Camera', 8, 599.99),
(15, 5, 'Lens', 12, 199.99);

select * from inventory;




WITH product_stats AS (
    SELECT 
        store_id,
        MIN(price) AS cheapest_price,
        MAX(price) AS expensive_price
    FROM inventory
    GROUP BY store_id
),

detailed_stats AS (
    SELECT 
        i.store_id,
        i.product_name AS cheapest_product,
        i.quantity AS cheapest_quantity,
        ps.cheapest_price
    FROM inventory i
    JOIN product_stats ps
        ON i.store_id = ps.store_id
        AND i.price = ps.cheapest_price
),

detailed_expensive AS (
    SELECT 
        i.store_id,
        i.product_name AS expensive_product,
        i.quantity AS expensive_quantity,
        ps.expensive_price
    FROM inventory i
    JOIN product_stats ps
        ON i.store_id = ps.store_id
        AND i.price = ps.expensive_price
),

product_count AS (
    SELECT 
        store_id,
        COUNT(*) AS total_products
    FROM inventory
    GROUP BY store_id
)

SELECT 
    s.store_id,
    s.store_name,
    s.location,
    de.expensive_product AS most_exp_product,
    ds.cheapest_product AS cheapest_product,
    ROUND(
        CAST(ds.cheapest_quantity AS FLOAT) / 
        NULLIF(de.expensive_quantity, 0), 2
    ) AS imbalance_ratio
FROM detailed_stats ds
JOIN detailed_expensive de ON ds.store_id = de.store_id
JOIN product_count pc ON ds.store_id = pc.store_id
JOIN stores s ON s.store_id = ds.store_id
WHERE 
    de.expensive_quantity < ds.cheapest_quantity
    AND pc.total_products >= 3
ORDER BY 
    imbalance_ratio DESC,
    s.store_name ASC;
