use DBLeetCode;

CREATE TABLE Users (
    user_id INT PRIMARY KEY,
    join_date DATE,
    favorite_brand VARCHAR(255)
);

CREATE TABLE Items (
    item_id INT PRIMARY KEY,
    item_brand VARCHAR(255)
);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    order_date DATE,
    item_id INT FOREIGN KEY REFERENCES Items(item_id),
    buyer_id INT FOREIGN KEY REFERENCES Users(user_id),
    seller_id INT FOREIGN KEY REFERENCES Users(user_id)
);

INSERT INTO Users (user_id, join_date, favorite_brand) VALUES
(1, '2018-01-01', 'Samsung'),
(2, '2018-02-02', 'Lenovo'),
(3, '2018-04-09', 'LG'),
(4, '2018-05-21', 'Samsung');

INSERT INTO Items (item_id, item_brand) VALUES
(1, 'Samsung'),
(2, 'Lenovo'),
(3, 'LG'),
(4, 'Samsung');

INSERT INTO Orders (order_id, order_date, item_id, buyer_id, seller_id) VALUES
(1, '2019-01-01', 1, 1, 2), 
(2, '2019-02-01', 2, 2, 1), 
(3, '2019-02-01', 3, 1, 1),
(4, '2019-03-01', 4, 4, 1), 
(5, '2018-04-01', 3, 4, 4),
(6, '2019-05-01', 2, 2, 4); 

select * from Users;
select * from Items;
select * from Orders;

SELECT u.user_id AS buyer_id, u.join_date,
    ( SELECT COUNT(O.order_id) FROM Orders O WHERE O.buyer_id = u.user_id AND YEAR(O.order_date) = 2019) AS orders_in_2019
FROM Users u ORDER BY buyer_id;
