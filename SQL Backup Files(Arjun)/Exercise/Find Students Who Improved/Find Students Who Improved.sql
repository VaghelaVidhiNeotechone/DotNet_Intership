create table Score(
student_id int,
subject varchar(50),
score int,
exam_date varchar(20),
primary key (student_id, subject, exam_date)
);

insert into Score values
(101,'Math',70,'2023-01-15'),
(101,'Math',85,'2023-02-15'),
(101,'Physics',65,'2023-01-15'),
(101,'Physics',60,'2023-02-15'),
(102,'Math',80,'2023-01-15'),
(102,'Math',85,'2023-02-15'),
(103,'Math',90,'2023-01-15'),
(104,'Physics',75,'2023-01-15'),
(104,'Physics',85,'2023-02-15');

select * from Score;



WITH ordered_scores AS (
    SELECT
        student_id,
        subject,
        score,
        exam_date,
        ROW_NUMBER() OVER (PARTITION BY student_id, subject ORDER BY exam_date) AS rn_first,
        ROW_NUMBER() OVER (PARTITION BY student_id, subject ORDER BY exam_date DESC) AS rn_last
    FROM Score
),
first_last AS (
    SELECT
        s1.student_id,
        s1.subject,
        s1.score AS first_score,
        s2.score AS latest_score
    FROM ordered_scores s1
    JOIN ordered_scores s2
        ON s1.student_id = s2.student_id
        AND s1.subject = s2.subject
    WHERE s1.rn_first = 1
      AND s2.rn_last = 1
)
SELECT *
FROM first_last
WHERE latest_score > first_score
ORDER BY student_id, subject;
