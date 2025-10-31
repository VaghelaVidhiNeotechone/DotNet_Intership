use EmployeeManagementDB;

create table Employees (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(50),
    DeptID INT,
    Salary INT
);

create table Departments (
    DeptID INT PRIMARY KEY,
    DeptName VARCHAR(50)
);

insert into Employees values
(1, 'Yashvi', 101, 50000),
(2, 'jahi', 102, 60000),
(3, 'arya', 101, 55000),
(4, 'shivani', 103, 45000),
(5, 'xyz', NULL, 40000);

insert into Departments values
(101, 'IT'),
(102, 'HR'),
(104, 'Finance');

select e.EmpID,e.EmpName,e.Salary,d.DeptName from Employees e inner join Departments d on e.DeptID=d.DeptID;

select e.EmpID,e.EmpName,e.Salary,d.DeptName from Employees e left join Departments d on e.DeptID=d.DeptID;

select e.EmpID,e.EmpName,e.Salary,d.DeptName from Employees e right join Departments d on e.DeptID=d.DeptID;

select e.EmpID,e.EmpName,e.Salary,d.DeptName from Employees e full join Departments d on e.DeptID=d.DeptID;

select e1.EmpName as Employee1,e2.EmpName as Employee2,e1.DeptID from Employees e1 join Employees e2 on e1.DeptID=e2.DeptID
where e1.EmpID<>e2.EmpID;

select DeptID from Employees union select DeptID from Departments;

select DeptID from Employees union all select DeptID from Departments;

select  DeptID,sum(Salary) as TotalSalary from Employees Group by DeptID having sum(Salary)>90000;

select EmpName from Employees e where exists (select 1 from Departments d where e.DeptID=d.DeptID);

select EmpName,Salary from Employees where Salary>any(select Salary from Employees where DeptID=101);

select EmpName, Salary from Employees where Salary > ALL (select Salary from Employees where DeptID = 101);
