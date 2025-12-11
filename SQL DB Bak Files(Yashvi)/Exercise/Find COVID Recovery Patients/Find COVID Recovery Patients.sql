use DBLeetCode2;

CREATE TABLE patients (
    patient_id INT PRIMARY KEY,
    patient_name VARCHAR(255),
    age INT
);

CREATE TABLE covid_tests (
    test_id INT PRIMARY KEY,
    patient_id INT,
    test_date DATE,
    result VARCHAR(255)
);

INSERT INTO patients (patient_id, patient_name, age) VALUES
(1, 'Alice Smith', 28),
(2, 'Bob Johnson', 35),
(3, 'Carol Davis', 42),
(4, 'David Wilson', 31),
(5, 'Emma Brown', 29);

INSERT INTO covid_tests (test_id, patient_id, test_date, result) VALUES
(1, 1, '2023-01-15', 'Positive'),
(2, 1, '2023-01-25', 'Negative'),
(3, 2, '2023-02-01', 'Positive'),
(4, 2, '2023-02-05', 'Inconclusive'),
(5, 2, '2023-02-12', 'Negative'),
(6, 3, '2023-01-20', 'Negative'),
(7, 3, '2023-02-10', 'Positive'),
(8, 3, '2023-02-20', 'Negative'),
(9, 4, '2023-01-10', 'Positive'),
(10, 4, '2023-01-18', 'Positive'),
(11, 5, '2023-02-15', 'Negative'),
(12, 5, '2023-02-20', 'Negative');

select * from patients;
select * from covid_tests;

WITH MinPositive AS (
    SELECT patient_id, MIN(test_date) AS first_positive_date
    FROM covid_tests
    WHERE result = 'Positive' GROUP BY patient_id
),
NextNegative AS ( 
    SELECT ct.patient_id, MIN(ct.test_date) AS first_negative_date_after
    FROM covid_tests ct
    JOIN
        MinPositive mp ON ct.patient_id = mp.patient_id
    WHERE ct.result = 'Negative' AND ct.test_date > mp.first_positive_date
    GROUP BY ct.patient_id
) SELECT P.patient_id, P.patient_name, P.age,
    DATEDIFF(DAY, MP.first_positive_date, NN.first_negative_date_after) AS recovery_time
FROM patients P
JOIN
    MinPositive MP ON P.patient_id = MP.patient_id
JOIN
    NextNegative NN ON P.patient_id = NN.patient_id
ORDER BY recovery_time ASC, P.patient_name ASC;
