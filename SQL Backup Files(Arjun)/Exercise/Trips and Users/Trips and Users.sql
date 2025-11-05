create table Users (
    users_id INT PRIMARY KEY,
    banned VARCHAR(10),
    role VARCHAR(20)
);

insert into Users values
(1, 'No', 'client'),
(2, 'Yes', 'client'),
(3, 'No', 'client'),
(4, 'No', 'client'),
(10, 'No', 'driver'),
(11, 'No', 'driver'),
(12, 'No', 'driver'),
(13, 'No', 'driver');

select * from Users;


create table Trips (
    id INT PRIMARY KEY,
    client_id INT,
    driver_id INT,
    city_id INT,
    status VARCHAR(30),
    request_at DATE
);

insert into Trips values
(1, 1, 10, 1, 'completed', '2013-10-01'),
(2, 2, 11, 1, 'cancelled_by_driver', '2013-10-01'),
(3, 3, 12, 6, 'completed', '2013-10-01'),
(4, 4, 13, 6, 'cancelled_by_client', '2013-10-01'),
(5, 1, 10, 1, 'completed', '2013-10-02'),
(6, 2, 11, 6, 'completed', '2013-10-02'),
(7, 3, 12, 6, 'completed', '2013-10-02'),
(8, 2, 12, 12, 'completed', '2013-10-03'),
(9, 3, 10, 12, 'completed', '2013-10-03'),
(10, 4, 13, 12, 'cancelled_by_driver', '2013-10-03');

select * from Trips;




SELECT t.request_at AS [Day],
    CAST(
        ROUND(
            1.0 * SUM(CASE WHEN t.status IN ('cancelled_by_driver','cancelled_by_client') THEN 1 ELSE 0 END)
            / COUNT(*),
        2) AS DECIMAL(4,2)
    ) AS [Cancellation Rate]
FROM Trips t
JOIN Users u
    ON t.client_id = u.users_id
WHERE u.banned = 'No'
GROUP BY t.request_at
ORDER BY t.request_at;