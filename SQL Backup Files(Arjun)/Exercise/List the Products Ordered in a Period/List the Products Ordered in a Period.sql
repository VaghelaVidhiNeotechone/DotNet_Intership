create table ProductsList(
product_id int primary key,
product_name varchar(100),
product_category varchar(50)
);

insert into ProductsList values
(1,'Leetcode Solutions','Book'),
(2,'Jewels of Stringology', 'Book'),
(3, 'HP', 'Laptop'),
(4, 'Lenovo', 'Laptop'),
(5, 'Leetcode Kit', 'T-shirt');

select * from ProductsList;


create table OrdersList(
product_id int,
order_date date,
unit int,
foreign key (product_id) references ProductsList(product_id)
);

insert into OrdersList values
(1, '2020-02-05', 60),
(1, '2020-02-10', 70),
(2, '2020-01-18', 30),
(2, '2020-02-11', 80),
(3, '2020-02-17', 2),
(3, '2020-02-24', 3),
(4, '2020-03-01', 20),
(4, '2020-03-04', 30),
(4, '2020-03-04', 60),
(5, '2020-02-25', 50),
(5, '2020-02-27', 50),
(5, '2020-03-01', 50);


select * from OrdersList;




SELECT 
    p.product_name,
    SUM(o.unit) AS unit
FROM ProductsList p
JOIN OrdersList o
    ON p.product_id = o.product_id
WHERE o.order_date BETWEEN '2020-02-01' AND '2020-02-29'
GROUP BY p.product_name
HAVING SUM(o.unit) >= 100;

