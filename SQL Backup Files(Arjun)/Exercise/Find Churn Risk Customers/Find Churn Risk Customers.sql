create table subscription_events(
event_id int primary key,
user_id int,
event_date date,
event_type varchar(20),
plan_name varchar(20),
monthly_amount decimal(10,2)
);

insert into subscription_events values
(1, 501, '2024-01-01', 'start', 'premium', 29.99),
(2, 501, '2024-02-15', 'downgrade', 'standard', 19.99),
(3, 501, '2024-03-20', 'downgrade', 'basic', 9.99),

(4, 502, '2024-01-05', 'start', 'standard', 19.99),
(5, 502, '2024-02-10', 'upgrade', 'premium', 29.99),
(6, 502, '2024-03-15', 'downgrade', 'basic', 9.99),

(7, 503, '2024-01-10', 'start', 'basic', 9.99),
(8, 503, '2024-02-20', 'upgrade', 'standard', 19.99),
(9, 503, '2024-03-25', 'upgrade', 'premium', 29.99),

(10, 504, '2024-01-15', 'start', 'premium', 29.99),
(11, 504, '2024-03-01', 'downgrade', 'standard', 19.99),
(12, 504, '2024-03-30', 'cancel', NULL, 0.00),

(13, 505, '2024-02-01', 'start', 'basic', 9.99),
(14, 505, '2024-02-28', 'upgrade', 'standard', 19.99),

(15, 506, '2024-01-20', 'start', 'premium', 29.99),
(16, 506, '2024-03-10', 'downgrade', 'basic', 9.99);

select * from subscription_events;




WITH first_last AS (
    SELECT
        user_id,
        MIN(event_date) AS first_event_date,
        MAX(event_date) AS last_event_date
    FROM subscription_events
    GROUP BY user_id
),

latest_event AS (
    SELECT se.user_id,
           se.event_type AS last_event_type,
           se.plan_name AS current_plan,
           se.monthly_amount AS current_monthly_amount
    FROM subscription_events se
    JOIN first_last fl
        ON se.user_id = fl.user_id
       AND se.event_date = fl.last_event_date
),

user_stats AS (
    SELECT
        se.user_id,
        SUM(CASE WHEN event_type = 'downgrade' THEN 1 ELSE 0 END) AS downgrade_count,
        MAX(monthly_amount) AS max_historical_amount
    FROM subscription_events se
    GROUP BY se.user_id
)

SELECT
    le.user_id,
    le.current_plan,
    le.current_monthly_amount,
    us.max_historical_amount,
    CASE 
        WHEN DAY(fl.first_event_date) = 1 
            THEN DATEDIFF(DAY, fl.first_event_date, fl.last_event_date)
        ELSE 
            DATEDIFF(DAY, fl.first_event_date, fl.last_event_date) - 1
    END AS days_as_subscriber
FROM latest_event le
JOIN first_last fl ON le.user_id = fl.user_id
JOIN user_stats us ON le.user_id = us.user_id
WHERE
    le.last_event_type <> 'cancel'
    AND us.downgrade_count >= 1
    AND le.current_monthly_amount < (0.5 * us.max_historical_amount)
    AND (
         CASE 
             WHEN DAY(fl.first_event_date) = 1 
                 THEN DATEDIFF(DAY, fl.first_event_date, fl.last_event_date)
             ELSE 
                 DATEDIFF(DAY, fl.first_event_date, fl.last_event_date) - 1
         END
    ) >= 60
ORDER BY
    days_as_subscriber DESC,
    le.user_id ASC;
