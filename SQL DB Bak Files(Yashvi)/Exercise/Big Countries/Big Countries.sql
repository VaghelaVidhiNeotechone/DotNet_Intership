use demoDB;

CREATE TABLE World (
    name VARCHAR(255) PRIMARY KEY,
    continent VARCHAR(255),
    area INT,
    population INT,
    gdp BIGINT
);

INSERT INTO World (name, continent, area, population, gdp) VALUES
('India', 'Asia', 3287263, 1428627663, 3730000000000),
('Afghanistan', 'Asia', 652230, 25500100, 20343000000), 
('Albania', 'Europe', 28748, 2816000, 13120000000),   
('Algeria', 'Africa', 2381741, 37100000, 188681000000),
('Canada', 'North America', 9984670, 38246108, 1990760000000), 
('USA', 'North America', 9833520, 331893745, 25460000000000),
('Brazil', 'South America', 8515767, 214326223, 1649000000000); 

select * from World;
SELECT name, population, area FROM World WHERE area >= 3000000 OR population >= 25000000;
