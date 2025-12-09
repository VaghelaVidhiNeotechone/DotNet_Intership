
CREATE TABLE saleSea (
    sale_id INT PRIMARY KEY,
    product_id INT,
    sale_date DATE,
    quantity INT,
    price DECIMAL(10,2)
);

CREATE TABLE productsSea (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    category VARCHAR(50)
);


INSERT INTO saleSea VALUES
(1, 1, '2023-01-15', 5, 10.00),
(2, 2, '2023-01-20', 4, 15.00),
(3, 3, '2023-03-10', 3, 18.00),
(4, 4, '2023-04-05', 1, 20.00),
(5, 1, '2023-05-20', 2, 10.00),
(6, 2, '2023-06-12', 4, 15.00),
(7, 5, '2023-06-15', 5, 12.00),
(8, 3, '2023-07-24', 2, 18.00),
(9, 4, '2023-08-01', 5, 20.00),
(10, 5, '2023-09-03', 3, 12.00),
(11, 1, '2023-09-25', 6, 10.00),
(12, 2, '2023-11-10', 4, 15.00),
(13, 3, '2023-12-05', 6, 18.00),
(14, 4, '2023-12-22', 3, 20.00),
(15, 5, '2024-02-14', 2, 12.00);

INSERT INTO productsSea VALUES
(1, 'Warm Jacket', 'Apparel'),
(2, 'Designer Jeans', 'Apparel'),
(3, 'Cutting Board', 'Kitchen'),
(4, 'Smart Speaker', 'Tech'),
(5, 'Yoga Mat', 'Fitness');



WITH seasonal_sales AS (
    SELECT 
        s.*,
        p.category,
        CASE 
            WHEN MONTH(s.sale_date) IN (12,1,2) THEN 'Winter'
            WHEN MONTH(s.sale_date) IN (3,4,5) THEN 'Spring'
            WHEN MONTH(s.sale_date) IN (6,7,8) THEN 'Summer'
            WHEN MONTH(s.sale_date) IN (9,10,11) THEN 'Fall'
        END AS season
    FROM saleSea s
    JOIN productsSea p ON s.product_id = p.product_id
),
category_summary AS (
    SELECT 
        season,
        category,
        SUM(quantity) AS total_quantity,
        SUM(quantity * price) AS total_revenue
    FROM seasonal_sales
    GROUP BY season, category
),
ranked_categories AS (
    SELECT 
        season,
        category,
        total_quantity,
        total_revenue,
        ROW_NUMBER() OVER (
            PARTITION BY season 
            ORDER BY total_quantity DESC, total_revenue DESC
        ) AS rn
    FROM category_summary
)
SELECT 
    season,
    category,
    total_quantity,
    total_revenue
FROM ranked_categories
WHERE rn = 1
ORDER BY 
    CASE season
        WHEN 'Winter' THEN 1
        WHEN 'Spring' THEN 2
        WHEN 'Summer' THEN 3
        WHEN 'Fall' THEN 4
    END;
