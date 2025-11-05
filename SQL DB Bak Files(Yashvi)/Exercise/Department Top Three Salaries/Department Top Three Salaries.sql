use EmployeeManagementDB;

select EmpName,Salary,DeptID from Employees;
select * from Departments;

select department , employee , salary 
from (
  select e.EmpName employee , e.salary salary, d.DeptName department, dense_rank() over (partition by d.DeptId order by e.salary desc) ranking
  from Employees e inner join Departments d
  on e.DeptID = d.DeptID
) newTable
where ranking <= 3