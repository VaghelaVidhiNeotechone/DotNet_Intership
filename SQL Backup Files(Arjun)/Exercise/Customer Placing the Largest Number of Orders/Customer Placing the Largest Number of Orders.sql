create table OrderLargest(
order_number INT PRIMARY KEY,  
customer_number INT
);

insert into OrderLargest values
(1, 1),
(2, 2),
(3, 3),
(4, 3);

select * from OrderLargest;



SELECT TOP 1 customer_number
FROM OrderLargest
GROUP BY customer_number
ORDER BY COUNT(order_number) DESC;