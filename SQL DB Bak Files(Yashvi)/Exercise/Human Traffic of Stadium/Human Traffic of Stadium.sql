use demoDB;

CREATE TABLE Stadium (
    id INT PRIMARY KEY,
    visit_date DATE NOT NULL UNIQUE,
    people INT NOT NULL
);

INSERT INTO Stadium (id, visit_date, people) VALUES
(1, '2017-01-01', 10),
(2, '2017-01-02', 109),
(3, '2017-01-03', 150),
(4, '2017-01-04', 99),
(5, '2017-01-05', 140),
(6, '2017-01-06', 145),
(7, '2017-01-07', 150),
(8, '2017-01-08', 110),
(9, '2017-01-09', 100);

select * from Stadium;

with groups as(
SELECT id - row_number() over (order by visit_date) grouped_val,id,visit_date,people
FROM Stadium where people >= 100)
SELECT id, visit_date, people
FROM groups where grouped_val in (SELECT grouped_val from groups group by grouped_val having count(*) > 2) order by visit_date