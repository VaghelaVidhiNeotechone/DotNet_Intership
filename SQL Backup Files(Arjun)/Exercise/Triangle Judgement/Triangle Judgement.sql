create table Triangle(
x int,
y int,
z int,
primary key (x,y,z)
);

insert into Triangle values
(13,15,30),
(10,20,15);

select * from Triangle;





SELECT x,y,z,CASE
WHEN x + y > z AND y + z > x AND z + x > y THEN 'Yes'
ELSE 'No'
END AS triangle
FROM Triangle;
