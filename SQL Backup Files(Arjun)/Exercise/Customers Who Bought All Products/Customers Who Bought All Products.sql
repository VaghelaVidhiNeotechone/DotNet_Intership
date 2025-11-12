create table Customer(
customer_id int not null,
product_key int,
FOREIGN KEY (product_key) REFERENCES Product(product_key)
);

insert into Customer values
(1,5),
(2,6),
(3,5),
(3,6),
(1,6);

select * from Customer;



create table Product(
product_key INT PRIMARY KEY
);

insert into Product values
(5),
(6);

select * from Product;




SELECT customer_id FROM Customer
GROUP BY customer_id
HAVING COUNT(DISTINCT product_key) = (SELECT COUNT(*) FROM Product);
