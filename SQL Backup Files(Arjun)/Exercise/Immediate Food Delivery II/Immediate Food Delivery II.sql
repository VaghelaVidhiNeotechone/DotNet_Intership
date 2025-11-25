create table Delivery(
delivery_id int primary key,
customer_id int,
order_date date,
customer_pref_delivery_date date
);

insert into Delivery values
(1,1,'2019-08-01','2019-08-02'),
(2,2,'2019-08-02','2019-08-02'),
(3,1,'2019-08-11','2019-08-12'),
(4,3,'2019-08-24','2019-08-24'),
(5,3,'2019-08-21','2019-08-22'),
(6,2,'2019-08-11','2019-08-13'),
(7,4,'2019-08-09','2019-08-09');

select * from Delivery;




WITH FirstOrders AS (
    SELECT 
        customer_id,
        MIN(order_date) AS first_order_date
    FROM Delivery
    GROUP BY customer_id
)
SELECT 
    CAST(
        SUM(CASE WHEN d.order_date = d.customer_pref_delivery_date THEN 1.0 ELSE 0 END) * 100.0 
        / COUNT(*) 
        AS DECIMAL(5,2)
    ) AS immediate_percentage
FROM Delivery d
JOIN FirstOrders f
    ON d.customer_id = f.customer_id
   AND d.order_date = f.first_order_date;
