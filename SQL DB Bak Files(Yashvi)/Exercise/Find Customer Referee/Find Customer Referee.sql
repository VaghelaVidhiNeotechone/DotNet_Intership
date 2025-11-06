use demoDB;

CREATE TABLE Customer (
    id INT PRIMARY KEY,
    name VARCHAR(255),
    referee_id INT
);

INSERT INTO Customer (id, name, referee_id) VALUES
(1, 'yashvi', NULL),    
(2, 'arya', NULL),
(3, 'yax', 2),     
(4, 'jahi', NULL),
(5, 'jiva', 1),      
(6, 'dev', 2);   

select * from Customer;

SELECT name FROM Customer WHERE referee_id <> 2 OR referee_id IS NULL;

