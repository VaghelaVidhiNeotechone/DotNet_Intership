use DBLeetCode2;

select * from ProductPurchases;
select * from ProductInfo;

WITH UserCategories AS (
    SELECT DISTINCT pp.user_id, pi.category
    FROM ProductPurchases pp
    JOIN
        ProductInfo pi ON pp.product_id = pi.product_id
)
SELECT uc1.category AS category1, uc2.category AS category2,
    COUNT(uc1.user_id) AS customer_count
FROM UserCategories uc1
JOIN
    UserCategories uc2 
    ON uc1.user_id = uc2.user_id         
    AND uc1.category < uc2.category     
GROUP BY uc1.category, uc2.category
HAVING COUNT(uc1.user_id) >= 3 
ORDER BY customer_count DESC, category1 ASC, category2 ASC;