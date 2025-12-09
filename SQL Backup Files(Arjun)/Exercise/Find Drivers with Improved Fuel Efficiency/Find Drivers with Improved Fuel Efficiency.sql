create table drivers(
driver_id int primary key,
driver_name varchar(100)
);

insert into drivers values
(1, 'Alice Johnson'),
(2, 'Bob Smith'),
(3, 'Carol Davis'),
(4, 'David Wilson'),
(5, 'Emma Brown');

select * from drivers;

create table tripsFind(
trip_id int primary key,
driver_id int,
trip_date date,
distance_km decimal(10,2),
fuel_consumed decimal(10,2),
foreign key (driver_id) references drivers(driver_id)
);

insert into tripsFind values
(1, 1, '2023-02-15', 120.5, 10.2),
(2, 1, '2023-03-20', 200.0, 16.5),
(3, 1, '2023-08-10', 150.0, 11.0),
(4, 1, '2023-09-25', 180.0, 12.5),
(5, 2, '2023-01-10', 100.0, 9.0),
(6, 2, '2023-04-15', 250.0, 22.0),
(7, 2, '2023-10-05', 200.0, 15.0),
(8, 3, '2023-03-12', 80.0, 8.5),
(9, 3, '2023-05-18', 90.0, 9.2),
(10, 4, '2023-07-22', 160.0, 12.8),
(11, 4, '2023-11-30', 140.0, 11.0),
(12, 5, '2023-02-28', 110.0, 11.5);

select * from tripsFind;




WITH trip_efficiency AS (
    SELECT
        t.driver_id,
        t.trip_date,
        CAST(t.distance_km / t.fuel_consumed AS DECIMAL(10,2)) AS efficiency,
        CASE 
            WHEN MONTH(t.trip_date) BETWEEN 1 AND 6 THEN 'first'
            WHEN MONTH(t.trip_date) BETWEEN 7 AND 12 THEN 'second'
        END AS half_year
    FROM tripsFind t
),
first_half AS (
    SELECT
        driver_id,
        AVG(efficiency) AS first_half_avg
    FROM trip_efficiency
    WHERE half_year = 'first'
    GROUP BY driver_id
),
second_half AS (
    SELECT
        driver_id,
        AVG(efficiency) AS second_half_avg
    FROM trip_efficiency
    WHERE half_year = 'second'
    GROUP BY driver_id
),
final_calc AS (
    SELECT
        fh.driver_id,
        fh.first_half_avg,
        sh.second_half_avg,
        CAST(sh.second_half_avg - fh.first_half_avg AS DECIMAL(10,2)) AS efficiency_improvement
    FROM first_half fh
    JOIN second_half sh ON fh.driver_id = sh.driver_id
)
SELECT
    d.driver_id,
    d.driver_name,
    ROUND(f.first_half_avg, 2) AS first_half_avg,
    ROUND(f.second_half_avg, 2) AS second_half_avg,
    ROUND(f.efficiency_improvement, 2) AS efficiency_improvement
FROM final_calc f
JOIN drivers d ON f.driver_id = d.driver_id
ORDER BY efficiency_improvement DESC, driver_name ASC;
