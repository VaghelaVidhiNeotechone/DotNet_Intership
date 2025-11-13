create table UsersI(
user_id int primary key,
join_date date,
favorite_brand varchar(50)
);

insert into UsersI values
(1, '2018-01-01', 'Lenovo'),
(2, '2018-02-09', 'Samsung'),
(3, '2018-01-19', 'LG'),
(4, '2018-05-21', 'HP');

select * from UsersI;


create table OrdersI(
order_id int primary key,
order_date date,
item_id int,
buyer_id int,
seller_id int
);

insert into OrdersI values
(1,'2019-08-01',4,1,2),
(2,'2018-08-02',2,1,3),
(3,'2019-08-03',3,2,3),
(4,'2018-08-04',1,4,2),
(5,'2018-08-04',1,3,4),
(6,'2019-08-05',2,2,4);

select * from OrdersI;


create table Items(
item_id int primary key,
item_brand varchar(50)
);

insert into Items values
(1,'Samsung'),
(2,'Lenovo'),
(3,'LG'),
(4,'HP');

select * from Items;



SELECT 
    u.user_id AS buyer_id,
    u.join_date,
    COUNT(o.order_id) AS orders_in_2019
FROM UsersI u
LEFT JOIN OrdersI o
    ON u.user_id = o.buyer_id
    AND YEAR(o.order_date) = 2019
GROUP BY u.user_id, u.join_date
ORDER BY u.user_id;
