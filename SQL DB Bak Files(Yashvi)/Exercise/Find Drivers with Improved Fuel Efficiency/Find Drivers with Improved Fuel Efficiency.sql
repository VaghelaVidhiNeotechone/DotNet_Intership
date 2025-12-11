use DBLeetCode2;

CREATE TABLE drivers (
    driver_id INT PRIMARY KEY,
    driver_name VARCHAR(255)
);

-- Create the trips table
CREATE TABLE trips (
    trip_id INT PRIMARY KEY,
    driver_id INT,
    trip_date DATE,
    distance_km DECIMAL(10, 2),
    fuel_consumed DECIMAL(10, 2),
    FOREIGN KEY (driver_id) REFERENCES drivers(driver_id)
);

-- Insert sample data into drivers
INSERT INTO drivers (driver_id, driver_name) VALUES
(1, 'Alice Johnson'),
(2, 'Bob Smith'),
(3, 'Carol Davis'),
(4, 'David Wilson'),
(5, 'Emma Brown');

-- Insert sample data into trips
INSERT INTO trips (trip_id, driver_id, trip_date, distance_km, fuel_consumed) VALUES
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

select * from drivers;
select * from trips;

WITH A AS (
    SELECT driver_id,
          AVG(CASE WHEN DATEPART(MONTH, trip_date) BETWEEN 0 AND 6
                   THEN distance_km / fuel_consumed END) AS firstavg,
          AVG(CASE WHEN DATEPART(MONTH, trip_date) BETWEEN 7 AND 12
                   THEN distance_km / fuel_consumed END) AS secondavg
    FROM trips  GROUP BY driver_id
)
SELECT A.driver_id, d.driver_name,
      ROUND(A.firstavg, 2) AS first_half_avg,
      ROUND(A.secondavg, 2) AS second_half_avg,
      ROUND(A.secondavg - a.firstavg, 2) AS efficiency_improvement
FROM A JOIN drivers d ON A.driver_id = d.driver_id
WHERE A.secondavg > A.firstavg
ORDER BY efficiency_improvement DESC, driver_name 