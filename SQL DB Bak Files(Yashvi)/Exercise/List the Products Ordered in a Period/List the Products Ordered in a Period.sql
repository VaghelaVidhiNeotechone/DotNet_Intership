use DBLeetCode;

CREATE TABLE Products2 (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(255),
    product_category VARCHAR(255)
);

CREATE TABLE Orders2 (
    product_id INT FOREIGN KEY REFERENCES Products2(product_id),
    order_date DATE,
    unit INT
);

INSERT INTO Products2 (product_id, product_name, product_category) VALUES
(1, 'Leetcode Solutions', 'Book'),
(2, 'Excel for Dummies', 'Book'),
(3, 'Computer', 'Electronics'),
(4, 'TV', 'Electronics');

INSERT INTO Orders2 (product_id, order_date, unit) VALUES
(1, '2020-02-01', 50),
(1, '2020-02-04', 60),
(1, '2020-01-01', 30),

(2, '2020-02-02', 30),
(2, '2020-02-03', 60),

(3, '2020-02-05', 100),
(3, '2020-02-06', 50),
(3, '2020-03-01', 20);

select * from Products2;
select * from Orders2;

SELECT p.product_name, SUM(o.unit) AS unit
FROM Products2 p JOIN Orders2 o ON p.product_id = o.product_id
WHERE YEAR(o.order_date) = 2020 AND MONTH(o.order_date) = 2
GROUP BY p.product_id, p.product_name
HAVING SUM(o.unit) >= 100;
