use DBLeetCode2;

CREATE TABLE products3 (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(255),
    description VARCHAR(MAX)
);

INSERT INTO products3 (product_id, product_name, description) VALUES
(1, 'Laptop', 'Powerful laptop with SN1234-5678 serial number.'),
(2, 'Phone', 'Latest model (SN9876-1234) with advanced features.'),
(3, 'Tablet', 'Compact design, serial: SN111-222.'),      
(4, 'Monitor', 'Serial number SN0000-9999 available.'),    
(5, 'Keyboard', 'Serial is SNABCD-1234, watch out.'),     
(6, 'Mouse', 'SN5555-ABCD is the serial number.'),     
(7, 'USB Drive', 'Serial is sn1234-5678, note the case.'); 

select * from products3;

SELECT product_id, product_name, description
FROM products3
WHERE PATINDEX('%SN[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]%', description) > 0
ORDER BY product_id ASC;
