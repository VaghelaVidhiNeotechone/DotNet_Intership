use demoDB;

CREATE TABLE Employee (
    id INT PRIMARY KEY,
    name VARCHAR(255),
    department VARCHAR(255),
    managerId INT
);

INSERT INTO Employee (id, name, department, managerId) VALUES
(101, 'yash', 'A', NULL),    
(102, 'arya', 'A', 101),     
(103, 'yax', 'A', 101),    
(104, 'dev', 'A', 101),      
(105, 'krish', 'A', 101),     
(106, 'smit', 'A', 101),    
(107, 'jahi', 'A', 101),     
(108, 'jiva', 'B', 102),      
(109, 'jiya', 'B', 102);   

select * from Employee;

SELECT M.name FROM Employee E JOIN Employee M ON E.managerId = M.id GROUP BY M.id, M.name HAVING COUNT(E.id) >= 5; 
