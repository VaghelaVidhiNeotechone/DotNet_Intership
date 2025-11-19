create table UsersFix(
user_id int primary key,
name varchar(100)
);

insert into UsersFix values
(1, 'aLice'),
(2, 'bOB');

select * from UsersFix;

SELECT user_id,
    UPPER(LEFT(name, 1)) +
    LOWER(SUBSTRING(name, 2, LEN(name))) AS name
FROM UsersFix;

