create table UsersEmails(
user_id int primary key,
email varchar(255)
);

insert into UsersEmails values
(1, 'alice@example.com'),
(2, 'bob_at_example.com'),
(3, 'charlie@example.net'),
(4, 'david@domain.com'),
(5, 'eve@invalid');

select * from UsersEmails;



SELECT user_id, email
FROM UsersEmails
WHERE email LIKE '%@%.com'  
  AND email NOT LIKE '% %'  
  AND email NOT LIKE '%@%@%'  
ORDER BY user_id ASC;
