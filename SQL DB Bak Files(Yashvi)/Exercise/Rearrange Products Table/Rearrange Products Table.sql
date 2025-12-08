use DBLeetCode2;

CREATE TABLE Products2 (
    product_id INT PRIMARY KEY,
    store1 INT NULL,
    store2 INT NULL,
    store3 INT NULL
);

INSERT INTO Products2 (product_id, store1, store2, store3) VALUES
(0, 95, 100, 105),
(1, 70, NULL, 80);

select * from Products2;

SELECT product_id, store, price FROM Products2
UNPIVOT( price FOR store IN (store1, store2, store3)) AS UnpivotedProducts;
