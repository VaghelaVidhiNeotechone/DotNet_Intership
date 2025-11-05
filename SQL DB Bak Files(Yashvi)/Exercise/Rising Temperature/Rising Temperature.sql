use demoDB;

SELECT * FROM Weather;

select w2.id from Weather w1 JOIN Weather w2 on DATEDIFF(day, w1.recordDate, w2.recordDate) = 1 where w2.temperature > w1.temperature;