use demoDB;

CREATE TABLE Product (
    product_key INT PRIMARY KEY
);

CREATE TABLE Customers (
    customer_id INT,
    product_key INT,
    FOREIGN KEY (product_key) REFERENCES Product(product_key)
);

INSERT INTO Product (product_key) VALUES
(5),
(6);

INSERT INTO Customers (customer_id, product_key) VALUES
(1, 5),
(1, 6),
(2, 5),
(2, 6),
(3, 5),
(3, 6);

select * from Customers;

select * from Product;

SELECT customer_id FROM Customers
GROUP BY customer_id HAVING
    COUNT(DISTINCT product_key) = (SELECT COUNT(DISTINCT product_key) FROM Product);

