create table Patients(
patient_id int primary key,
patient_name varchar(100),
condition varchar(255)
);

insert into Patients values
(1, 'Daniel', 'YFEV COUGH'),
(2, 'Alice', ''),
(3, 'Bob', 'DIAB100 MYOP'),
(4, 'George', 'ACNE DIAB100'),
(5, 'Alain', 'DIAB201');

select * from Patients;



SELECT *
FROM Patients
WHERE condition LIKE '% DIAB1%' 
   OR condition LIKE 'DIAB1%';

