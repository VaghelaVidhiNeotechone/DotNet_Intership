use DBLeetCode2;

CREATE TABLE Users (
    account INT PRIMARY KEY,
    name VARCHAR(255)
);

CREATE TABLE Transactions (
    trans_id INT PRIMARY KEY,
    account INT FOREIGN KEY REFERENCES Users(account),
    amount INT,
    transacted_on DATE
);

INSERT INTO Users (account, name) VALUES
(900001, 'Alice'),
(900002, 'Bob'),
(900003, 'Charlie');

INSERT INTO Transactions (trans_id, account, amount, transacted_on) VALUES
(1, 900001, 7000, '2020-08-01'),
(2, 900001, 7000, '2020-08-01'), 
(3, 900002, 1000, '2020-08-01'),
(4, 900002, 3000, '2020-08-01'),
(5, 900002, 4000, '2020-08-01'),
(6, 900003, 15000, '2020-08-01');

select * from Users;
select * from Transactions;

SELECT u.name, SUM(t.amount) AS balance FROM Users u
JOIN Transactions t ON u.account = t.account
GROUP BY u.account, u.name HAVING SUM(t.amount) > 10000;
