use DBLeetCode2;

CREATE TABLE UserActivity (
    user_id INT,
    activity_date DATE,
    activity_type VARCHAR(255) CHECK (activity_type IN ('free_trial', 'paid', 'cancelled')),
    activity_duration INT,
    PRIMARY KEY (user_id, activity_date, activity_type)
);

INSERT INTO UserActivity (user_id, activity_date, activity_type, activity_duration) VALUES
(1, '2023-01-01', 'free_trial', 45),
(1, '2023-01-02', 'free_trial', 30),
(1, '2023-01-05', 'free_trial', 60),
(1, '2023-01-10', 'paid', 75),
(1, '2023-01-12', 'paid', 90),
(1, '2023-01-15', 'paid', 65),
(2, '2023-02-01', 'free_trial', 55),
(2, '2023-02-03', 'free_trial', 25),
(2, '2023-02-07', 'free_trial', 50),
(2, '2023-02-10', 'cancelled', 0),
(3, '2023-03-05', 'free_trial', 70),
(3, '2023-03-06', 'free_trial', 60),
(3, '2023-03-08', 'free_trial', 80),
(3, '2023-03-12', 'paid', 50),
(3, '2023-03-15', 'paid', 55),
(3, '2023-03-20', 'paid', 85),
(4, '2023-04-01', 'free_trial', 40),
(4, '2023-04-03', 'free_trial', 35),
(4, '2023-04-05', 'paid', 45),
(4, '2023-04-07', 'cancelled', 0);

select * from UserActivity;

SELECT UA.user_id,
    ROUND(AVG(CAST(CASE WHEN UA.activity_type = 'free_trial' THEN UA.activity_duration END AS FLOAT)), 2) AS trial_avg_duration,
    ROUND(AVG(CAST(CASE WHEN UA.activity_type = 'paid' THEN UA.activity_duration END AS FLOAT)), 2) AS paid_avg_duration
FROM UserActivity UA
JOIN (
 SELECT user_id FROM UserActivity GROUP BY user_id
    HAVING
        SUM(CASE WHEN activity_type = 'free_trial' THEN 1 ELSE 0 END) > 0
        AND SUM(CASE WHEN activity_type = 'paid' THEN 1 ELSE 0 END) > 0
) AS Converters ON UA.user_id = Converters.user_id
GROUP BY UA.user_id ORDER BY UA.user_id ASC;
