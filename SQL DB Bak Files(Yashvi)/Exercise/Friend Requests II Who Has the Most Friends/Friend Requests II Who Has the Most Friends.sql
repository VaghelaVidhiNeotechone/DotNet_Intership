use demoDB;

CREATE TABLE RequestAccepted (
    requester_id INT,
    accepter_id INT,
    accept_date DATE,
    PRIMARY KEY (requester_id, accepter_id)
);


INSERT INTO RequestAccepted (requester_id, accepter_id, accept_date) VALUES
(1, 2, '2016-03-01'),
(1, 3, '2016-03-02'),
(2, 3, '2016-03-03'),
(3, 4, '2016-03-04'),
(2, 4, '2016-03-05');

select * from RequestAccepted;

with accepted as (
select userId as id, Count(*) num from (
	select requester_id as userId
	from RequestAccepted
	union all
	select accepter_id
	from RequestAccepted
) cte
group by userId
)
select * from accepted where num = (select max(num) from accepted)