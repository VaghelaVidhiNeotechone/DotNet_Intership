create table ProductsRange(
product_id int primary key,
store1 int,
store2 int,
store3 int
);

insert into ProductsRange values
(0,95,100,105),
(1,70,Null,80);

select * from ProductsRange;



SELECT product_id, store, price
FROM ProductsRange
UNPIVOT (
    price FOR store IN ([store1], [store2], [store3])
) AS unpvt
WHERE price IS NOT NULL
ORDER BY product_id, store;