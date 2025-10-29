USE CollegeDB;

CREATE TABLE Student
(
	StudentID int identity(1,1) primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50),
	Age int,
	Email nvarchar(50) unique
);

Insert into Student(FirstName,LastName,Age,Email) values('yashvi','dhaduk',21,'yashvi@gmail.com'),
														 ('arya','dhaduk',14,'arya@gmail.com'),
														 ('jahi','dhaduk',17,'jahi@gmail.com');

Insert into Student(FirstName,LastName,Age,Email) values('shivu','dhaduk',22,'shivani@gmail.com');

select * from Student;

select FirstName,Email from Student;

select * from Student where  Age<20;

select * from Student order by Age asc;

select distinct FirstName from Student;

SELECT * FROM Student WHERE FirstName='yashvi' AND Age=21;

update Student set Age=22,Email='yashvi12@gmail.com' where StudentID=1;

delete from Student where StudentID=8;

alter table Student add City nvarchar(50);

update Student set City = 'Rajkot' where StudentID = 1;

update Student set City = 'Surat' where StudentID = 2;

update Student set City = 'Ahmedabad' where StudentID = 3;
