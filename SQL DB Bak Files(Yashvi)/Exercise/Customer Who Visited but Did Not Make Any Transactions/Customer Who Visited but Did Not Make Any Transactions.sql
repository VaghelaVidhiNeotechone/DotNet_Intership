USE DBLeetCode;

CREATE TABLE Visits (
    visit_id INT PRIMARY KEY,
    customer_id INT
);

CREATE TABLE Transactions2 (
    transaction_id INT PRIMARY KEY,
    visit_id INT FOREIGN KEY REFERENCES Visits(visit_id),
    amount INT
);

INSERT INTO Visits (visit_id, customer_id) VALUES
(1, 23),
(2, 9),
(4, 30),
(5, 54),
(6, 9),
(7, 9),
(9, 99),   
(12, 88);  

INSERT INTO Transactions2 (transaction_id, visit_id, amount) VALUES
(2, 5, 310),
(3, 9, 300),
(9, 12, 200),
(12, 1, 910),
(13, 2, 970);

SELECT * FROM Visits;
SELECT * FROM Transactions2;

--(LEFT JOIN METHOD)
--SELECT v.customer_id, COUNT(v.visit_id) AS count_no_trans
--FROM Visits v
--LEFT JOIN Transactions2 t ON v.visit_id = t.visit_id
--WHERE t.transaction_id IS NULL
--GROUP BY v.customer_id;

SELECT customer_id, COUNT(visit_id) AS count_no_trans FROM Visits
WHERE visit_id NOT IN (SELECT DISTINCT visit_id FROM Transactions2) GROUP BY customer_id;
