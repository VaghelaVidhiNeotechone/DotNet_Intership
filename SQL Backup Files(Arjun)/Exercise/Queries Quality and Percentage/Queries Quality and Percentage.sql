create table Queries(
query_name varchar(50),
result varchar(100),
position int,
rating int
);

insert into Queries values
('Dog','Golden Retriever',1,5),
('Dog','German Shapherd',2,5),
('Dog','Mule',200,1),
('Cat','Shirazi',5,2),
('Cat','Siamese',3,3),
('Cat','Sphynx',7,4);

select * from Queries;



SELECT query_name,
    ROUND(AVG(CAST(rating AS FLOAT) / position), 2) AS quality,
    ROUND(
        (SUM(CASE WHEN rating < 3 THEN 1 ELSE 0 END) * 100.0) / COUNT(*),
        2
    ) AS poor_query_percentage
FROM Queries
GROUP BY query_name;
