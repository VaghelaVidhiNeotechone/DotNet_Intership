create table Accounts(
account_id int primary key,
income int
);

insert into Accounts values
(3, 108939),
(2, 12747),
(8, 87709),
(6, 91796);

select * from Accounts;




WITH Categories AS (
    SELECT 'Low Salary' AS category
    UNION ALL
    SELECT 'Average Salary'
    UNION ALL
    SELECT 'High Salary'
),
CategorizedAccounts AS (
    SELECT 
        CASE 
            WHEN income < 20000 THEN 'Low Salary'
            WHEN income BETWEEN 20000 AND 50000 THEN 'Average Salary'
            ELSE 'High Salary'
        END AS category
    FROM Accounts
)
SELECT 
    c.category,
    COUNT(ca.category) AS accounts_count
FROM Categories c
LEFT JOIN CategorizedAccounts ca ON c.category = ca.category
GROUP BY c.category
ORDER BY 
    CASE c.category
        WHEN 'Low Salary' THEN 1
        WHEN 'Average Salary' THEN 2
        WHEN 'High Salary' THEN 3
    END;
