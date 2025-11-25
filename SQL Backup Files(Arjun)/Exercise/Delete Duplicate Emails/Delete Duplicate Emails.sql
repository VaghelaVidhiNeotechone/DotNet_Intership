create table Persons
(
id int primary key,
email varchar(100)
);

insert into Persons values
(1,'a@b.com'),
(2,'c@d.com'),
(3,'a@b.com');


DELETE FROM Persons
WHERE id NOT IN (
    SELECT MIN(id) 
    FROM Persons
    GROUP BY email
);

select * from Persons;