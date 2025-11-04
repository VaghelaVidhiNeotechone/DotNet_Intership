use EmployeeManagementDB;

select * from Employees;

select Score from Employees group by Score having count(Score)>1;
