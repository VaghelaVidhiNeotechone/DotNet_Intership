use demoDB;

CREATE TABLE SalesPerson (
    sales_id INT PRIMARY KEY,
    name VARCHAR(255),
    salary INT,
    commission_rate INT,
    hire_date DATE
);

CREATE TABLE Company (
    com_id INT PRIMARY KEY,
    name VARCHAR(255),
    city VARCHAR(255)
);

CREATE TABLE ORDERSS (
    order_id INT PRIMARY KEY,
    order_date DATE,
    com_id INT,
    sales_id INT,
    amount INT,
    FOREIGN KEY (com_id) REFERENCES Company(com_id),
    FOREIGN KEY (sales_id) REFERENCES SalesPerson(sales_id)
);

INSERT INTO SalesPerson (sales_id, name, salary, commission_rate, hire_date) VALUES
(1, 'John', 100000, 6, '2006-04-01'),
(2, 'Amy', 12000, 5, '2010-05-01'),
(3, 'Mark', 65000, 12, '2008-12-25'),
(4, 'Pam', 25000, 25, '2005-01-01'),
(5, 'Alex', 50000, 10, '2007-08-01');

INSERT INTO Company (com_id, name, city) VALUES
(1, 'APPLE', 'London'),
(2, 'IBM', 'New York'),
(3, 'RED', 'Boston'),
(4, 'GOOGLE', 'Mountain View');

INSERT INTO ORDERSS (order_id, order_date, com_id, sales_id, amount) VALUES
(1, '2014-01-01', 3, 4, 10000),
(2, '2014-02-02', 4, 5, 25000),
(3, '2014-03-03', 1, 1, 30000),
(4, '2014-04-04', 1, 4, 10000),
(5, '2014-05-05', 2, 1, 15000),
(6, '2014-06-06', 3, 5, 40000);

select * from SalesPerson;
SELECT name FROM SalesPerson WHERE
    sales_id NOT IN (
        SELECT DISTINCT o.sales_id FROM ORDERSS o LEFT JOIN Company c ON o.com_id = c.com_id
        WHERE c.name = 'RED'
    );

