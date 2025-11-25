create table ProductSales(
product_id int primary key,
product_name varchar(50)
);

insert into ProductSales values
(100,'Nokia'),
(200,'Apple'),
(300,'Samsung');

select * from ProductSales;


create table Sales(
sale_id int,
product_id int,
year int,
quantity int,
price int,
primary key (sale_id, year),
foreign key (product_id) references ProductSales(product_id)
);

insert into Sales values
(1,100,2008,10,5000),
(2,100,2009,12,5000),
(7,200,2011,15,9000);

select * from Sales;



SELECT 
    s.product_id,
    s.year AS first_year,
    s.quantity,
    s.price
FROM Sales s
WHERE s.year = (
    SELECT MIN(year)
    FROM Sales
    WHERE product_id = s.product_id
);

