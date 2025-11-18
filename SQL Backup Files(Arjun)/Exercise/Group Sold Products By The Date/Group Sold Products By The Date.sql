create table Activities(
sell_date date,
product varchar(100)
);

insert into Activities values
('2020-05-30', 'Headphone'),
('2020-06-01', 'Pencil'),
('2020-06-02', 'Mask'),
('2020-05-30', 'Basketball'),
('2020-06-01', 'Bible'),
('2020-06-02', 'Mask'),
('2020-05-30', 'T-Shirt');

select * from Activities;




SELECT 
    sell_date,
    COUNT(*) AS num_sold,
    STRING_AGG(product, ',') 
        WITHIN GROUP (ORDER BY product ASC) AS products
FROM Activities
GROUP BY sell_date
ORDER BY sell_date;
