use DBLeetCode;

CREATE TABLE Products (
    product_id INT,
    new_price INT,
    change_date DATE,
    PRIMARY KEY (product_id, change_date)
);

INSERT INTO Products (product_id, new_price, change_date) VALUES (1, 20, '2019-08-14');
INSERT INTO Products (product_id, new_price, change_date) VALUES (1, 30, '2019-08-15');
INSERT INTO Products (product_id, new_price, change_date) VALUES (1, 35, '2019-08-17');
INSERT INTO Products (product_id, new_price, change_date) VALUES (2, 20, '2019-08-14');
INSERT INTO Products (product_id, new_price, change_date) VALUES (3, 20, '2019-08-18');

select * from Products;

select product_id, isnull((select top 1 new_price from Products p2
    where p1.product_id = p2.product_id and change_date <= '2019-08-16' order by change_date desc), 10) as price
from Products p1 group by product_id
