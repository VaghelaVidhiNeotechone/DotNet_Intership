use CompanyDB;
Go
create table employee(
	EmployeeID int identity(1,1) primary key,
	EmplyeeName varchar(50),
	Department varchar(50),
	JobTitle varchar(50),
	Salary decimal(10,2),
	HireDate date
);

insert into employee(EmplyeeName,Department,JobTitle,Salary,HireDate) values
('yashvi dhaduk', 'HR', 'HR Manager', 50000, '2022-03-10'),
('jahi dhaduk', 'IT', 'Software Engineer', 60000, '2021-07-15'),
('arya dhaduk', 'Finance', 'Accountant', 55000, '2020-02-05'),
('yax satodiya', 'IT', 'System Analyst', 70000, '2019-08-23'),
('shivani dhaduk', 'Sales', 'Sales Executive', 45000, '2022-05-12');

select * from employee;

select top 3 * from employee;

select COUNT(*) as TotalEmployees, MIN(Salary) AS LowestSalary,MAX(Salary) AS HighestSalary,
	   AVG(Salary) AS AverageSalary,SUM(Salary) AS TotalSalary FROM employee;

select Department, AVG(Salary) as AverageSalary from employee group by Department;

select Department,sum(Salary) as TotalSalary from employee group by Department having sum(Salary)>=50000;

select * from employee where EmplyeeName like 'j%';

select * from employee where EmplyeeName like 'Ar%';

select * from employee where EmplyeeName like 'y%';

select * from employee where Department in('IT','HR');

select * from employee where Salary between 50000 AND 60000;

SELECT * FROM employee ORDER BY Salary DESC;

SELECT EmplyeeName, Department, Salary FROM employee WHERE Department = 'IT' AND EmplyeeName LIKE '%i%' ORDER BY Salary asc;

