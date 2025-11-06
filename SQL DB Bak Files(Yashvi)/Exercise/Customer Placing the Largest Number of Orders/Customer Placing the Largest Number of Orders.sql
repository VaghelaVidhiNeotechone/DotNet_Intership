use demoDB;

CREATE TABLE Orders (
    order_number INT PRIMARY KEY,
    customer_number INT
);

INSERT INTO Orders (order_number, customer_number) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 3),
(5, 1),
(6, 3);
select * from Orders;

SELECT TOP 1 customer_number FROM Orders GROUP BY customer_number ORDER BY COUNT(order_number) DESC;
