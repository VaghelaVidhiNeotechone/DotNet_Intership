create table ProductsLow(
product_id int primary key,
low_fats char(1),
recyclable char(1)
);

insert into ProductsLow values
(0, 'Y', 'N'),
(1, 'Y', 'Y'),
(2, 'N', 'Y'),
(3, 'Y', 'Y'),
(4, 'N', 'N');

select * from ProductsLow;



SELECT product_id
FROM ProductsLow
WHERE low_fats = 'Y' AND recyclable = 'Y'
ORDER BY product_id;
