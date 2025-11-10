create table Tree(
id int primary key,
p_id int
);

insert into Tree values
(1,null),
(2,1),
(3,1),
(4,2),
(5,2);

select * from Tree;




SELECT 
    t1.id,
    CASE
        WHEN t1.p_id IS NULL THEN 'Root'
        WHEN EXISTS (SELECT 1 FROM Tree t2 WHERE t2.p_id = t1.id) THEN 'Inner'
        ELSE 'Leaf'
    END AS type
FROM Tree t1
ORDER BY t1.id;
