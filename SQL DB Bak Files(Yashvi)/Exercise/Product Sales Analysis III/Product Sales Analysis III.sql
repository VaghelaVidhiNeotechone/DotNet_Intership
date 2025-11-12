use DBLeetCode;

select * from Sales;

WITH MinYearPerProduct AS (
    SELECT product_id, MIN(year) AS first_year FROM Sales GROUP BY product_id)
SELECT s.product_id, m.first_year, s.quantity, s.price FROM Sales s
JOIN MinYearPerProduct m ON s.product_id = m.product_id AND s.year = m.first_year;

