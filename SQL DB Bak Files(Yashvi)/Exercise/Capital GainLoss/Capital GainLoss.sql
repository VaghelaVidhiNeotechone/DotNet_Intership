use DBLeetCode;

CREATE TABLE Stocks (
    stock_name VARCHAR(255),
    operation VARCHAR(50), -- 'Buy' or 'Sell'
    operation_day INT,
    price INT,
    PRIMARY KEY (stock_name, operation_day)
);

INSERT INTO Stocks (stock_name, operation, operation_day, price) VALUES
('Leetcode', 'Buy', 1, 1000),
('Corona Masks', 'Buy', 2, 10),
('Leetcode', 'Sell', 5, 9000),
('Corona Masks', 'Buy', 3, 1010),
('Corona Masks', 'Sell', 4, 1000),
('Leetcode', 'Sell', 10, 5000);

select * from Stocks;

SELECT stock_name,
	SUM(CASE WHEN operation = 'Sell' THEN price ELSE 0 END) - 
    SUM(CASE WHEN operation = 'Buy' THEN price ELSE 0 END) AS capital_gain_loss
FROM Stocks GROUP BY stock_name;
