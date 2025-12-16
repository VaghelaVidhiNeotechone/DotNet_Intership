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

Select product_id,'store1' as store,store1 as price from Products2 where store1 is not null
union
Select product_id,'store2' as store,store2 as price from Products2 where store2 is not null
union
Select product_id,'store3' as store,store3 as price from Products2 where store3 is not null