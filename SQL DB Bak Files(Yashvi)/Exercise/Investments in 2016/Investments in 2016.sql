use demoDB;

CREATE TABLE Insurance (
    pid INT PRIMARY KEY,
    tiv_2015 FLOAT,
    tiv_2016 FLOAT,
    lat FLOAT,
    lon FLOAT
);

INSERT INTO Insurance (pid, tiv_2015, tiv_2016, lat, lon) VALUES
(1, 10, 5, 10, 10), 
(2, 10, 10, 20, 20),
(3, 20, 20, 30, 30),
(4, 20, 30, 40, 40),
(5, 10, 40, 10, 10),
(6, 40, 50, 50, 50);

select * from Insurance;

select round(sum(tiv_2016),2) as tiv_2016 from insurance 
where tiv_2015 in (select tiv_2015 from insurance group by tiv_2015 having count(tiv_2015) > 1) 
AND lat+lon not in (select lat+lon from insurance group by lat+lon having count(lat+lon) > 1) 