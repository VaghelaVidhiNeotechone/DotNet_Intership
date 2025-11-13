use DBLeetCode;

CREATE TABLE Delivery (
    delivery_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    customer_pref_delivery_date DATE
);

INSERT INTO Delivery (delivery_id, customer_id, order_date, customer_pref_delivery_date) VALUES
(1, 1, '2019-08-01', '2019-08-02'),
(2, 2, '2019-08-02', '2019-08-02'),
(3, 1, '2019-08-11', '2019-08-11'),
(4, 3, '2019-08-24', '2019-08-24'),
(5, 3, '2019-08-21', '2019-08-22'),
(6, 2, '2019-08-21', '2019-08-22');

select * from Delivery;

SELECT Round((100.00*COUNT(case when order_date = customer_pref_delivery_date then 1 end))/COUNT(customer_id),2) AS immediate_percentage
FROM (SELECT *, 
      RANK() OVER (PARTITION BY customer_id ORDER BY order_date) AS rank 
      FROM Delivery) AS data
WHERE rank = 1