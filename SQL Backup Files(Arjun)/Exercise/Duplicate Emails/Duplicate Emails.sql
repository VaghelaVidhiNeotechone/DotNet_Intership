create table Persons
(
id int primary key,
email varchar(100)
);

insert into Persons values
(1,'a@b.com'),
(2,'c@d.com'),
(3,'a@b.com');

select * from Persons;

select email AS Email from Persons
group by email
having count(*) > 1;