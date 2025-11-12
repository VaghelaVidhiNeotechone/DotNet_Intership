use DBLeetCode;

CREATE TABLE Product (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(255)
);

CREATE TABLE Sales (
    sale_id INT,
    product_id INT,
    year INT,
    quantity INT,
    price INT,
    PRIMARY KEY (sale_id, year), -- Composite Primary Key
    FOREIGN KEY (product_id) REFERENCES Product(product_id)
);

INSERT INTO Product (product_id, product_name) VALUES
(101, 'Leetcode Solutions'),
(102, 'Excel Book'),
(103, 'Code Complete');

INSERT INTO Sales (sale_id, product_id, year, quantity, price) VALUES
(1, 101, 2008, 10, 5000),
(2, 102, 2009, 12, 1000),
(7, 101, 2011, 15, 9000);

select * from Product;

select * from Sales;

select p.product_name,s.year,s.price from Sales s join Product p on s.product_id = p.product_id;
 