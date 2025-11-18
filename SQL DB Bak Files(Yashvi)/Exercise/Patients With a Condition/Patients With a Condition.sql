use DBLeetCode;

CREATE TABLE Patients (
    patient_id INT PRIMARY KEY,
    patient_name VARCHAR(255),
    conditions VARCHAR(255)
);

INSERT INTO Patients (patient_id, patient_name, conditions) VALUES
(1, 'James Cooper', 'DIAB100 MNOP'),
(2, 'Marie Myers', 'UNSATISFIED'),
(3, 'Lynn Bond', ''),
(4, 'Roger Dean', 'DIAB100 other DIAB104'),
(5, 'Ryan Basil', 'DIAB200'), 
(6, 'John Doe', 'DIAB1'),
(7, 'Jane Smith', 'SICK DIAB1 AND HEALTHY'); 

select * from Patients;

SELECT patient_id, patient_name, conditions FROM Patients
WHERE conditions LIKE 'DIAB1%' OR conditions LIKE '% DIAB1%';
