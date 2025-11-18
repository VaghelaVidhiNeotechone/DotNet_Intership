use DBLeetCode;

CREATE TABLE Users3 (
    id INT PRIMARY KEY,
    name VARCHAR(255)
);

CREATE TABLE Rides (
    id INT PRIMARY KEY,
    user_id INT FOREIGN KEY REFERENCES Users3(id),
    distance INT
);

INSERT INTO Users3 (id, name) VALUES
(1, 'Alice'),
(2, 'Bob'),
(3, 'Alex'),
(4, 'Donald'),
(7, 'Lee'),
(13, 'Aamir'),
(19, 'Chad'),
(30, 'Brad');

INSERT INTO Rides (id, user_id, distance) VALUES
(1, 1, 120),
(2, 2, 317),
(3, 2, 222),
(4, 7, 100),
(5, 7, 220),
(6, 4, 970);

select * from Users3;
select * from Rides;

SELECT u.name, ISNULL(SUM(r.distance), 0) AS travelled_distance
FROM Users3 u LEFT JOIN Rides r ON u.id = r.user_id
GROUP BY u.id, u.name ORDER BY travelled_distance DESC, u.name ASC;  
