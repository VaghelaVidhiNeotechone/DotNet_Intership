create table patientsFind(
patient_id int primary key,
patient_name varchar(100),
age int 
);

insert into patientsFind values
(1, 'Alice Smith', 28),
(2, 'Bob Johnson', 35),
(3, 'Carol Davis', 42),
(4, 'David Wilson', 31),
(5, 'Emma Brown', 29);

select * from patientsFind;


create table covid_tests(
test_id int primary key,
patient_id int,
test_date date,
result varchar(20),
foreign key (patient_id) references patientsFind(patient_id)
);

insert into covid_tests values
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

select * from covid_tests;



WITH first_positive AS (
    SELECT
        patient_id,
        MIN(test_date) AS first_positive_date
    FROM covid_tests
    WHERE result = 'Positive'
    GROUP BY patient_id
),
first_negative_after_positive AS (
    SELECT
        c.patient_id,
        MIN(c.test_date) AS first_negative_date
    FROM covid_tests c
    JOIN first_positive fp ON c.patient_id = fp.patient_id
    WHERE c.result = 'Negative'
      AND c.test_date > fp.first_positive_date
    GROUP BY c.patient_id
),
final_recovery AS (
    SELECT
        fp.patient_id,
        fp.first_positive_date,
        fn.first_negative_date,
        DATEDIFF(DAY, fp.first_positive_date, fn.first_negative_date) AS recovery_time
    FROM first_positive fp
    JOIN first_negative_after_positive fn
        ON fp.patient_id = fn.patient_id
)
SELECT
    p.patient_id,
    p.patient_name,
    p.age,
    fr.recovery_time
FROM final_recovery fr
JOIN patientsFind p ON fr.patient_id = p.patient_id
ORDER BY fr.recovery_time ASC, p.patient_name ASC;
