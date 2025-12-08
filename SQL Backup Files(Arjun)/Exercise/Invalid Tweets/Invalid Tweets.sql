create table Tweets(
tweet_id int primary key,
content varchar(255)
);

insert into Tweets values
(1,'Let us Code'),
(2,'More than fifteen chars are here!');

select * from Tweets;



select tweet_id
from Tweets
where Len(content) > 15;