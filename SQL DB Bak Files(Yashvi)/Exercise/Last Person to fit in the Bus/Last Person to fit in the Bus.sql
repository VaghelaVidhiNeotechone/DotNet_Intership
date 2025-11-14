use DBLeetCode;

CREATE TABLE Queue (
    person_id INT PRIMARY KEY,
    person_name VARCHAR(255),
    weight INT,
    turn INT
);

INSERT INTO Queue (person_id, person_name, weight, turn) VALUES
(5, 'George Washington', 250, 1),
(1, 'John Adams', 350, 2),
(2, 'Thomas Jefferson', 500, 3),
(6, 'James Madison', 50, 4),
(4, 'James Monroe', 200, 5),
(3, 'Andrew Jackson', 250, 6);

select * from Queue;

select TOP 1 person_name from (
select * , sum(weight) over (order by Turn) as total_sum from queue) t 
where total_sum <= 1000
order by turn DESC