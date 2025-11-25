--create database Company;

--CREATE TABLE departments (
--    id INT PRIMARY KEY,
--    department_name VARCHAR(50)
--);

--INSERT INTO departments VALUES
--(1, 'HR'),
--(2, 'IT'),
--(3, 'Finance'),
--(4, 'Marketing');

--select * from departments;



--CREATE TABLE employees (
--    id INT PRIMARY KEY,
--    name VARCHAR(50),
--    salary DECIMAL(10,2),
--    department_id INT,
--    manager_id INT,
--    FOREIGN KEY (department_id) REFERENCES departments(id)
--);

--INSERT INTO employees VALUES
--(1, 'Aryan', 50000, 1, 3),
--(2, 'Keval', 55000, 1, 3),
--(3, 'Vedant', 80000, 2, NULL), 
--(4, 'Sahil', 60000, 2, 3),
--(5, 'Darshit', 45000, 3, 6),
--(6, 'Harsh', 90000, 3, NULL), 
--(7, 'Jay', 40000, NULL, NULL); 

--select * from employees;


--SELECT e.name, d.department_name FROM employees e
--LEFT JOIN departments d
--ON e.department_id = d.id;

--SELECT e.name, d.department_name FROM employees e
--RIGHT JOIN departments d
--ON e.department_id = d.id;

--SELECT e.name, d.department_name FROM employees e
--FULL JOIN departments d
--ON e.department_id = d.id;

--SELECT A.name AS Employee, B.name AS Manager FROM employees A
--JOIN employees B
--ON A.manager_id = B.id;

--SELECT name FROM employees
--UNION
--SELECT name FROM manager;

--SELECT name FROM employees
--UNION ALL
--SELECT name FROM managers;

--SELECT department_id, COUNT(*) AS total_employees FROM employees
--GROUP BY department_id;

--SELECT department_id, COUNT(*) AS total_employees FROM employees
--GROUP BY department_id
--HAVING COUNT(*) > 5;

--SELECT department_name FROM departments d
--WHERE EXISTS (
--    SELECT 1 FROM employees e
--    WHERE e.department_id = d.id
--);

--SELECT name, salary FROM employees
--WHERE salary > ANY (
--    SELECT salary FROM employees WHERE department_id = 3
--);

--SELECT name, salary FROM employees
--WHERE salary > ALL (
--    SELECT salary FROM employees WHERE department_id = 2
--);