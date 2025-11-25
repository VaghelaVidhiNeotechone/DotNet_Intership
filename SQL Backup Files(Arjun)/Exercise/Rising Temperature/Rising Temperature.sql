create table Weather (
id int primary key,
recordDate Date,
temperature int
);

insert into Weather values
(1,'2015-01-01',10),
(2,'2015-01-02',25),
(3,'2015-01-03',20),
(4,'2015-01-04',30);

select * from Weather;


SELECT w1.id
FROM Weather w1
JOIN Weather w2
    ON DATEDIFF(day, w2.recordDate, w1.recordDate) = 1
WHERE w1.temperature > w2.temperature;