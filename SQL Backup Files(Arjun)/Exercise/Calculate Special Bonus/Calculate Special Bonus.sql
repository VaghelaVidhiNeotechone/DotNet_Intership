create table EmployeesCal(
employee_id int primary key,
name varchar(50),
salary int
);

insert into EmployeesCal values
(2,'Meir',3000),
(3,'Michael',3800),
(7,'Addilyn',7400),
(8,'Juan',6100),
(9,'Kannon',7700);

select * from EmployeesCal;




SELECT employee_id,
    CASE 
        WHEN employee_id % 2 = 0 THEN 0   
        WHEN name LIKE 'M%' THEN 0           
        ELSE salary                         
    END AS bonus
FROM EmployeesCal
ORDER BY employee_id;
