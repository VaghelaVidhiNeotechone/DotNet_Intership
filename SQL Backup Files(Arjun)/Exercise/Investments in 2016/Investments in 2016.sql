create table Insurance(
pid INT PRIMARY KEY,      
tiv_2015 FLOAT,          
tiv_2016 FLOAT,            
lat FLOAT NOT NULL,      
lon FLOAT NOT NULL 
);

insert into Insurance values
(1, 10, 5, 10, 10),
(2, 20, 20, 20, 20),
(3, 10, 30, 20, 20),
(4, 10, 40, 40, 40);

select * from Insurance;


SELECT ROUND(SUM(i.tiv_2016), 2) AS tiv_2016
FROM Insurance i
WHERE i.tiv_2015 IN (
    SELECT tiv_2015
    FROM Insurance
    GROUP BY tiv_2015
    HAVING COUNT(*) > 1
)
AND EXISTS (
    SELECT 1
    FROM Insurance i2
    WHERE i.lat = i2.lat AND i.lon = i2.lon
    GROUP BY i2.lat, i2.lon
    HAVING COUNT(*) = 1
);

