create table LogsIP(
log_id int primary key,
ip varchar(15),
status_code int
);

insert into LogsIP values
(1, '192.168.1.1', 200),
(2, '256.1.2.3', 404),
(3, '192.168.001.1', 200),
(4, '192.168.1.1', 200),
(5, '192.168.1', 500),
(6, '256.1.2.3', 404),
(7, '192.168.001.1', 200);

select * from LogsIP;



SELECT ip, COUNT(*) AS invalid_count
FROM LogsIP
WHERE 
    (LEN(ip) - LEN(REPLACE(ip, '.', '')) <> 3)
    OR 
    (TRY_CONVERT(int, PARSENAME(ip, 1)) IS NULL OR
     TRY_CONVERT(int, PARSENAME(ip, 2)) IS NULL OR
     TRY_CONVERT(int, PARSENAME(ip, 3)) IS NULL OR
     TRY_CONVERT(int, PARSENAME(ip, 4)) IS NULL)
    OR
    (TRY_CONVERT(int, PARSENAME(ip, 1)) NOT BETWEEN 0 AND 255 OR
     TRY_CONVERT(int, PARSENAME(ip, 2)) NOT BETWEEN 0 AND 255 OR
     TRY_CONVERT(int, PARSENAME(ip, 3)) NOT BETWEEN 0 AND 255 OR
     TRY_CONVERT(int, PARSENAME(ip, 4)) NOT BETWEEN 0 AND 255)
    OR
    (PARSENAME(ip,1) LIKE '0%' AND PARSENAME(ip,1) <> '0') OR
    (PARSENAME(ip,2) LIKE '0%' AND PARSENAME(ip,2) <> '0') OR
    (PARSENAME(ip,3) LIKE '0%' AND PARSENAME(ip,3) <> '0') OR
    (PARSENAME(ip,4) LIKE '0%' AND PARSENAME(ip,4) <> '0')
GROUP BY ip
ORDER BY invalid_count DESC, ip DESC;
