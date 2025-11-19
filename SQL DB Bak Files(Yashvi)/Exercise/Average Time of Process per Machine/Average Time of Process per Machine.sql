use DBLeetCode2;

CREATE TABLE Activity (
    machine_id INT,
    process_id INT,
    activity_type VARCHAR(10) CHECK (activity_type IN ('start', 'end')),
    timestamp FLOAT,
    PRIMARY KEY (machine_id, process_id, activity_type)
);

INSERT INTO Activity (machine_id, process_id, activity_type, timestamp) VALUES
(0, 0, 'start', 0.712),
(0, 0, 'end', 1.52),
(0, 1, 'start', 3.14),
(0, 1, 'end', 4.12),
(1, 0, 'start', 0.55),
(1, 0, 'end', 1.55),
(1, 1, 'start', 0.43),
(1, 1, 'end', 1.42),
(2, 0, 'start', 4.1),
(2, 0, 'end', 4.5),
(2, 1, 'start', 2.5),
(2, 1, 'end', 5);

select * from Activity;

SELECT A.machine_id, ROUND(AVG(B.timestamp - A.timestamp), 3) AS processing_time
FROM Activity A JOIN Activity B ON A.machine_id = B.machine_id
               AND A.process_id = B.process_id
               AND A.activity_type = 'start'
               AND B.activity_type = 'end'
GROUP BY A.machine_id;
