use DBLeetCode2;

CREATE TABLE Accounts (
    account_id INT PRIMARY KEY,
    income INT
);

INSERT INTO Accounts (account_id, income) VALUES
(3, 108939),
(2, 12747),
(8, 87709),
(6, 91796);

select * from Accounts;

select 'Low Salary' as category,
COUNT(income) as accounts_count from Accounts
where income < 20000
union
select 'Average Salary' as category,
COUNT(income) as accounts_count from Accounts
where income >= 20000 and income <= 50000
union
select 'High Salary' as category,
COUNT(income) as accounts_count from Accounts
where income > 50000