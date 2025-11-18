create table UsersValid(
user_id int primary key,
name varchar(100),
mail varchar(100)
);

insert into UsersValid values
(1,'Winston','winston@leetcode.com'),
(2,'Jonathan','jonathanisgreat'),
(3,'Annabelle','belle-@leetcode.com'),
(4,'Sally','sally.com@leetcode.com'),
(5,'Marwan','quarz#2020@leetcode.com'),
(6,'David','david69@gmail.com'),
(7,'Shapiro','.shapo@leetcode.com');

select * from UsersValid;




SELECT *
FROM UsersValid
WHERE mail LIKE '%@leetcode.com'
  AND mail NOT LIKE '#%'
  AND mail NOT LIKE '.%'
  AND mail NOT LIKE '%#%';
