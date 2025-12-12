use DBLeetCode2;

CREATE TABLE subscription_events (
    event_id INT PRIMARY KEY,
    user_id INT,
    event_date DATE,
    event_type VARCHAR(255) CHECK (event_type IN ('start', 'upgrade', 'downgrade', 'cancel')),
    plan_name VARCHAR(255) NULL,
    monthly_amount DECIMAL(10, 2)
);

INSERT INTO subscription_events (event_id, user_id, event_date, event_type, plan_name, monthly_amount) VALUES
(1, 501, '2024-01-01', 'start', 'premium', 29.99), (2, 501, '2024-02-15', 'downgrade', 'standard', 19.99), (3, 501, '2024-03-20', 'downgrade', 'basic', 9.99),
(4, 502, '2024-01-05', 'start', 'standard', 19.99), (5, 502, '2024-02-10', 'upgrade', 'premium', 29.99), (6, 502, '2024-03-15', 'downgrade', 'basic', 9.99),
(7, 503, '2024-01-10', 'start', 'basic', 9.99), (8, 503, '2024-02-20', 'upgrade', 'standard', 19.99), (9, 503, '2024-03-25', 'upgrade', 'premium', 29.99),
(10, 504, '2024-01-15', 'start', 'premium', 29.99), (11, 504, '2024-03-01', 'downgrade', 'standard', 19.99), (12, 504, '2024-03-30', 'cancel', NULL, 0.00),
(13, 505, '2024-02-01', 'start', 'basic', 9.99), (14, 505, '2024-02-28', 'upgrade', 'standard', 19.99),
(15, 506, '2024-01-20', 'start', 'premium', 29.99), (16, 506, '2024-03-10', 'downgrade', 'basic', 9.99);

select * from subscription_events;

with total_days as(
    select user_id,datediff(day,min(event_date),max(event_date)) as days_as_subscriber
    from subscription_events
    group by user_id
    having datediff(day,min(event_date),max(event_date)) > 60
), down_count as(
    select user_id,
        sum(case when event_type='downgrade' then 1 end) as dg_count
    from subscription_events
    group by user_id
    having sum(case when event_type='downgrade' then 1 end) >= 1
), overall as(
    select user_id,
        plan_name as current_plan,
        monthly_amount as current_monthly_amount,
        max_historical_amount
    from(
        select *,
        max(monthly_amount)over(partition by user_id) as max_historical_amount ,
        row_number() over(partition by user_id order by event_date desc) as rn
        from subscription_events
    )as x
    where rn=1 and event_type<>'cancel' and monthly_amount < (0.50*max_historical_amount)
)
select td.user_id,
       ol.current_plan,
       ol.current_monthly_amount,
       ol.max_historical_amount,td.days_as_subscriber
from total_days td 
join down_count dc
on td.user_id=dc.user_id
join overall ol
on ol.user_id=dc.user_id
order by days_as_subscriber desc,td.user_id asc