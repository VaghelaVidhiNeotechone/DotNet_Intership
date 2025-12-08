use DBLeetCode2;

CREATE TABLE DailySales (
    date_id DATE,
    make_name VARCHAR(255),
    lead_id INT,
    partner_id INT
);

INSERT INTO DailySales (date_id, make_name, lead_id, partner_id) VALUES
('2020-12-08', 'toyota', 0, 1),
('2020-12-08', 'toyota', 1, 0),
('2020-12-08', 'toyota', 1, 2),
('2020-12-07', 'toyota', 0, 2),
('2020-12-07', 'toyota', 0, 1),
('2020-12-08', 'honda', 1, 2),
('2020-12-08', 'honda', 2, 1),
('2020-12-07', 'honda', 0, 1),
('2020-12-07', 'honda', 1, 2),
('2020-12-07', 'honda', 2, 1);

select * from DailySales;

SELECT date_id,make_name,COUNT(DISTINCT lead_id) AS unique_leads,COUNT(DISTINCT partner_id) AS unique_partners
FROM DailySales GROUP BY date_id,make_name;

