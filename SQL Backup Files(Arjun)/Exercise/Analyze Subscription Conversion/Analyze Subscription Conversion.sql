create table UserActivity(
user_id int,
activity_date date,
activity_type varchar(20),
activity_duration int,
primary key (user_id, activity_date, activity_type)
);

insert into UserActivity values
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


SELECT 
    user_id,
    ROUND(AVG(CASE WHEN activity_type = 'free_trial' THEN activity_duration END), 2) 
        AS trial_avg_duration,
    ROUND(AVG(CASE WHEN activity_type = 'paid' THEN activity_duration END), 2) 
        AS paid_avg_duration
FROM UserActivity
GROUP BY user_id
HAVING SUM(CASE WHEN activity_type = 'paid' THEN 1 END) > 0;