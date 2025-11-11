use demoDB;

CREATE TABLE Seat (
    id INT PRIMARY KEY,
    student VARCHAR(255)
);

INSERT INTO Seat (id, student) VALUES
(1, 'Abbot'),
(2, 'Doris'),
(3, 'Emerson'),
(4, 'Green'),
(5, 'Jeames');

select * from Seat;

SELECT CASE
	WHEN id % 2 <> 0 AND id <> (SELECT MAX(id) FROM Seat) THEN id + 1
	WHEN id % 2 = 0 THEN id - 1
	ELSE id
    END AS id,student FROM Seat ORDER BY id ASC;
