create table Seat(
id int primary key,
student varchar(100)
);

insert into Seat values
(1, 'Abbot'),
(2, 'Doris'),
(3, 'Emerson'),
(4, 'Green'),
(5, 'Jeames');

select * from Seat;



SELECT 
    CASE
        WHEN id % 2 = 1 AND id + 1 <= (SELECT MAX(id) FROM Seat)
            THEN id + 1
        WHEN id % 2 = 0
            THEN id - 1
        ELSE id
    END AS id,
    student
FROM Seat
ORDER BY id;