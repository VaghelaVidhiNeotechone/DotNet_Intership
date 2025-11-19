create table ActivityAverage(
machine_id int,
process_id int,
activity_type varchar(10),
timestamp float,
primary key (machine_id, process_id, activity_type)
);

insert into ActivityAverage values
(0, 0, 'start', 0.712),
(0, 0, 'end', 1.520),
(0, 1, 'start', 3.140),
(0, 1, 'end', 4.120),
(1, 0, 'start', 0.550),
(1, 0, 'end', 1.550),
(1, 1, 'start', 0.430),
(1, 1, 'end', 1.420),
(2, 0, 'start', 4.100),
(2, 0, 'end', 4.512),
(2, 1, 'start', 2.500),
(2, 1, 'end', 5.000);

select * from ActivityAverage;



SELECT machine_id,
    ROUND(AVG(end_time - start_time), 3) AS processing_time
FROM (
    SELECT machine_id,process_id,
        MAX(CASE WHEN activity_type = 'start' THEN timestamp END) AS start_time,
        MAX(CASE WHEN activity_type = 'end' THEN timestamp END) AS end_time
    FROM ActivityAverage
    GROUP BY machine_id, process_id
) AS t
GROUP BY machine_id
ORDER BY machine_id;
