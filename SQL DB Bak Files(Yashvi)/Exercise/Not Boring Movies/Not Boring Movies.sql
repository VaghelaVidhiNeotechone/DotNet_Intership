use demoDB;

CREATE TABLE Cinema (
    id INT PRIMARY KEY,
    movie VARCHAR(255),
    description VARCHAR(255),
    rating FLOAT(2) 
);

INSERT INTO Cinema (id, movie, description, rating) VALUES
(1, 'War', 'great 3D', 8.9),
(2, 'Science', 'fiction', 8.5),
(3, 'irish', 'boring 2D', 6.2),
(4, 'Ice song', 'fantasy', 8.6),
(5, 'House card', 'Interesting', 9.1);

select * from Cinema;

select id, movie, description, rating from Cinema
where id % 2 <> 0 AND description <> 'boring 2D' order by rating desc;

