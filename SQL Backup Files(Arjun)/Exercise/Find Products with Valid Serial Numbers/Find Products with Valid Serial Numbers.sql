create table ProductsValid(
product_id int primary key,
product_name varchar(100),
description varchar(255)
);

insert into ProductsValid values
(1, 'Widget A', 'This is a sample product with SN1234-5678'),
(2, 'Widget B', 'A product with serial SN9876-1234 in the description'),
(3, 'Widget C', 'Product SN1234-56789 is available now'),
(4, 'Widget D', 'No serial number here'),
(5, 'Widget E', 'Check out SN4321-8765 in this description');

select * from ProductsValid;


select * from ProductsValid
where PATINDEX('%SN[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]%', description) > 0
AND description NOT LIKE '%SN[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]%';
