create table empFind(
employee_id int primary key,
name varchar(100)
);

insert into empFind values
(1, 'Alice Johnson'),
(2, 'Bob Smith'),
(3, 'Carol Davis'),
(4, 'David Wilson'),
(5, 'Emma Brown');

select * from empFind;


create table performance_reviews(
review_id int primary key,
employee_id int,
review_date date,
rating int,
foreign key (employee_id) references empFind(employee_id)
);

insert into performance_reviews values
(1, 1, '2023-01-15', 2),
(2, 1, '2023-04-15', 3),
(3, 1, '2023-07-15', 4),
(4, 1, '2023-10-15', 5),
(5, 2, '2023-02-01', 3),
(6, 2, '2023-05-01', 2),
(7, 2, '2023-08-01', 4),
(8, 2, '2023-11-01', 5),
(9, 3, '2023-03-10', 1),
(10, 3, '2023-06-10', 2),
(11, 3, '2023-09-10', 3),
(12, 3, '2023-12-10', 4),
(13, 4, '2023-01-20', 4),
(14, 4, '2023-04-20', 4),
(15, 4, '2023-07-20', 4),
(16, 5, '2023-02-15', 3),
(17, 5, '2023-05-15', 2);

select * from performance_reviews;




WITH ordered_reviews AS (
    SELECT
        employee_id,
        review_date,
        rating,
        ROW_NUMBER() OVER (PARTITION BY employee_id ORDER BY review_date DESC) AS rn
    FROM performance_reviews
),
last_three AS (
    SELECT
        employee_id,
        review_date,
        rating,
        rn,
        LAG(rating) OVER (PARTITION BY employee_id ORDER BY review_date) AS prev_rating
    FROM ordered_reviews
    WHERE rn <= 3
),
check_increase AS (
    SELECT
        employee_id,
        SUM(CASE WHEN prev_rating IS NOT NULL AND rating > prev_rating THEN 1 ELSE 0 END) AS increases,
        MIN(rating) AS first_rating,
        MAX(rating) AS last_rating,
        COUNT(*) AS total_reviews
    FROM last_three
    GROUP BY employee_id
),
final_output AS (
    SELECT
        e.employee_id,
        e.name,
        (ci.last_rating - ci.first_rating) AS improvement_score
    FROM check_increase ci
    JOIN empFind e ON ci.employee_id = e.employee_id
    WHERE ci.total_reviews = 3  
      AND ci.increases = 2           
)
SELECT *
FROM final_output
ORDER BY improvement_score DESC, name ASC;
