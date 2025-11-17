use DBLeetCode;

CREATE TABLE Prices (
    product_id INT,
    start_date DATE,
    end_date DATE,
    price INT,
    PRIMARY KEY (product_id, start_date, end_date)
);

CREATE TABLE UnitsSold (
    product_id INT,
    purchase_date DATE,
    units INT
);

INSERT INTO Prices (product_id, start_date, end_date, price) VALUES
(1, '2019-02-17', '2019-02-28', 5),
(1, '2019-03-01', '2019-03-22', 20),
(2, '2019-02-01', '2019-02-20', 15),
(2, '2019-02-21', '2019-03-31', 30);

INSERT INTO UnitsSold (product_id, purchase_date, units) VALUES
(1, '2019-02-25', 100),
(1, '2019-03-01', 15),
(2, '2019-02-10', 200),
(2, '2019-03-22', 30);

INSERT INTO Prices (product_id, start_date, end_date, price) VALUES (3, '2019-01-01', '2020-01-01', 10);

select * from Prices;
select * from UnitsSold;

SELECT t.product_id, ROUND(SUM(t.total_price)*1.0 / SUM(t.units), 2) AS average_price
FROM(SELECT u.product_id, u.units, p.price, u.units * p.price AS total_price
    FROM UnitsSold u LEFT JOIN Prices p ON u.product_id = p.product_id
    WHERE u.purchase_date >= p.start_date AND u.purchase_date <= p.end_date) t
GROUP BY t.product_id