use DBLeetCode2;

CREATE TABLE logs (
    log_id INT PRIMARY KEY,
    ip VARCHAR(255),
    status_code INT
);

INSERT INTO logs (log_id, ip, status_code) VALUES
(1, '192.168.1.1', 200),    
(2, '255.255.255.255', 200), 
(3, '256.1.2.3', 403),      
(4, '192.168.001.1', 403), 
(5, '192.168.1', 403),      
(6, '192.168.1.1.1', 403),  
(7, '10.0.0.0', 200),       
(8, '01.1.1.1', 403);       

select * from logs;

SELECT ip, COUNT(*) AS invalid_count
FROM logs
WHERE LEN(ip) - LEN(REPLACE(ip, '.', '')) <> 3
	OR ip NOT LIKE '[0-9]%.[0-9]%.[0-9]%.[0-9]%'
	OR 
    (   TRY_CAST(PARSENAME(ip, 4) AS INT) > 255 OR
        TRY_CAST(PARSENAME(ip, 3) AS INT) > 255 OR
        TRY_CAST(PARSENAME(ip, 2) AS INT) > 255 OR
        TRY_CAST(PARSENAME(ip, 1) AS INT) > 255 )
GROUP BY ip ORDER BY invalid_count DESC, ip DESC;




