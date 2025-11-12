use DBLeetCode;

CREATE TABLE ActorDirector (
    actor_id INT,
    director_id INT,
    timestamp INT PRIMARY KEY
);

INSERT INTO ActorDirector (actor_id, director_id, timestamp) VALUES
(1, 1, 0),
(1, 1, 1),
(1, 1, 2),
(1, 2, 3),
(1, 2, 4),
(2, 1, 5),
(2, 1, 6);

select * from ActorDirector;

select actor_id,director_id from ActorDirector group by actor_id, director_id having COUNT(*) >= 3;
