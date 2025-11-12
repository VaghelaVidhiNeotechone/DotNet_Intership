use DBLeetCode;

IF OBJECT_ID('Sales', 'U') IS NOT NULL
DROP TABLE Sales;

IF OBJECT_ID('Product', 'U') IS NOT NULL
DROP TABLE Product;

CREATE TABLE Product (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(255),
    unit_price INT -- Added column
);

CREATE TABLE Sales (
    sale_id INT,
    product_id INT,
    buyer_id INT,
	year int,
    sale_date DATE, 
    quantity INT,
    price INT,
	PRIMARY KEY (sale_id, year),
    FOREIGN KEY (product_id) REFERENCES Product(product_id)
);

INSERT INTO Product (product_id, product_name, unit_price) VALUES
(101, 'Laptop', 1200),
(102, 'Keyboard', 75),
(103, 'Monitor', 300);

INSERT INTO Sales (sale_id, product_id, buyer_id, year, sale_date, quantity, price) VALUES
(1, 101, 10, 2020, '2020-01-01', 1, 1200),
(2, 102, 10, 2020, '2020-01-05', 2, 150),
(3, 101, 11, 2021, '2021-03-15', 1, 1150),
(2, 103, 12, 2021, '2021-05-20', 1, 300),
(5, 103, 13, 2022, '2022-07-07', 5, 1500);

SELECT * FROM Product;
SELECT * FROM Sales;

SELECT product_id, product_name FROM Product
WHERE product_id IN
    (SELECT product_id FROM Sales GROUP BY product_id HAVING MAX(sale_date) <= '2019-03-31' AND MIN(sale_date) >= '2019-01-01')