use DBLeetCode2;

CREATE TABLE app_events (
    event_id INT PRIMARY KEY,
    user_id INT,
    event_timestamp DATETIME,
    event_type VARCHAR(255) CHECK (event_type IN ('app_open', 'click', 'scroll', 'purchase', 'app_close')),
    session_id VARCHAR(255),
    event_value INT NULL
);

INSERT INTO app_events (event_id, user_id, event_timestamp, event_type, session_id, event_value) VALUES
(1, 201, '2024-03-01 10:00:00', 'app_open', 'S001', NULL), (2, 201, '2024-03-01 10:05:00', 'scroll', 'S001', 500),
(3, 201, '2024-03-01 10:10:00', 'scroll', 'S001', 750), (4, 201, '2024-03-01 10:15:00', 'scroll', 'S001', 600),
(5, 201, '2024-03-01 10:20:00', 'scroll', 'S001', 800), (6, 201, '2024-03-01 10:25:00', 'scroll', 'S001', 550),
(7, 201, '2024-03-01 10:30:00', 'scroll', 'S001', 900), (8, 201, '2024-03-01 10:35:00', 'app_close', 'S001', NULL),
(9, 202, '2024-03-01 11:00:00', 'app_open', 'S002', NULL), (10, 202, '2024-03-01 11:02:00', 'click', 'S002', NULL),
(11, 202, '2024-03-01 11:05:00', 'scroll', 'S002', 400), (12, 202, '2024-03-01 11:08:00', 'click', 'S002', NULL),
(13, 202, '2024-03-01 11:10:00', 'scroll', 'S002', 350), (14, 202, '2024-03-01 11:15:00', 'purchase', 'S002', 50),
(15, 202, '2024-03-01 11:20:00', 'app_close', 'S002', NULL),
(16, 203, '2024-03-01 12:00:00', 'app_open', 'S003', NULL), (17, 203, '2024-03-01 12:10:00', 'scroll', 'S003', 1000),
(18, 203, '2024-03-01 12:20:00', 'scroll', 'S003', 1200), (19, 203, '2024-03-01 12:25:00', 'click', 'S003', NULL),
(20, 203, '2024-03-01 12:30:00', 'scroll', 'S003', 800), (21, 203, '2024-03-01 12:40:00', 'scroll', 'S003', 900),
(22, 203, '2024-03-01 12:50:00', 'scroll', 'S003', 1100), (23, 203, '2024-03-01 13:00:00', 'app_close', 'S003', NULL),
(24, 204, '2024-03-01 14:00:00', 'app_open', 'S004', NULL), (25, 204, '2024-03-01 14:05:00', 'scroll', 'S004', 600),
(26, 204, '2024-03-01 14:08:00', 'scroll', 'S004', 700), (27, 204, '2024-03-01 14:10:00', 'click', 'S004', NULL),
(28, 204, '2024-03-01 14:12:00', 'app_close', 'S004', NULL);

select * from app_events;

SELECT session_id, user_id,
    DATEDIFF(MINUTE, MIN(event_timestamp), MAX(event_timestamp)) AS session_duration_minutes,
    SUM(CASE WHEN event_type = 'scroll' THEN 1 ELSE 0 END) AS scroll_count
FROM app_events
GROUP BY session_id, user_id
HAVING
    DATEDIFF(MINUTE, MIN(event_timestamp), MAX(event_timestamp)) > 30
    AND SUM(CASE WHEN event_type = 'scroll' THEN 1 ELSE 0 END) >= 5
    AND (
        CAST(SUM(CASE WHEN event_type = 'click' THEN 1 ELSE 0 END) AS DECIMAL(5, 2)) /
        NULLIF(CAST(SUM(CASE WHEN event_type = 'scroll' THEN 1 ELSE 0 END) AS DECIMAL(5, 2)), 0)
    ) < 0.20
    AND SUM(CASE WHEN event_type = 'purchase' THEN 1 ELSE 0 END) = 0
ORDER BY scroll_count DESC, session_id ASC;
