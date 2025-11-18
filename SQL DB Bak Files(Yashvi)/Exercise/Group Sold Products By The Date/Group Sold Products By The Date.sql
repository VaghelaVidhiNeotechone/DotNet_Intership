use DBLeetCode;

CREATE TABLE Activities (
    sell_date DATE,
    product VARCHAR(255)
);

INSERT INTO Activities (sell_date, product) VALUES
('2020-05-30', 'Headphone'),
('2020-06-01', 'Pencil'),
('2020-06-01', 'Mask'),
('2020-06-01', 'WaterBottle'),
('2020-06-01', 'Mask'),
('2020-05-30', 'T-Shirt'),
('2020-05-30', 'Headphone'),
('2020-06-01', 'Pencil'),
('2020-06-01', 'Headphone');

select * from Activities;

SELECT sell_date, COUNT(DISTINCT product) AS num_sold,
    STRING_AGG(product, ',') WITHIN GROUP (ORDER BY product ASC) AS products
FROM (SELECT DISTINCT sell_date, product FROM Activities) AS UniqueSales
GROUP BY sell_date ORDER BY sell_date ASC;
