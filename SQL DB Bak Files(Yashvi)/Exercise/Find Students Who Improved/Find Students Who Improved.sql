use DBLeetCode2;

CREATE TABLE Scores (
    student_id INT,
    subject VARCHAR(255),
    score INT,
    exam_date VARCHAR(255),
    PRIMARY KEY (student_id, subject, exam_date)
);

INSERT INTO Scores (student_id, subject, score, exam_date) VALUES
(1, 'Math', 90, '2023-01-01'),
(1, 'Math', 95, '2023-01-15'),
(1, 'Math', 100, '2023-01-20'),
(1, 'Science', 80, '2023-01-01'),
(2, 'Math', 70, '2023-01-01'),
(2, 'Math', 60, '2023-01-15'),
(3, 'Math', 90, '2023-01-01'), 
(4, 'Math', 90, '2023-01-01'),
(4, 'Math', 90, '2023-01-15'); 

select * from Scores;

WITH RankedScores AS (
    SELECT student_id, subject, score,
        ROW_NUMBER() OVER(PARTITION BY student_id, subject ORDER BY exam_date ASC) AS rnk_first,
        ROW_NUMBER() OVER(PARTITION BY student_id, subject ORDER BY exam_date DESC) AS rnk_last,
        COUNT(*) OVER(PARTITION BY student_id, subject) AS num_exams
    FROM Scores
),
FirstAndLastScores AS (
    SELECT student_id,subject,
        -- Get the score from the 'first' row (rnk_first = 1)
        MAX(CASE WHEN rnk_first = 1 THEN score END) AS first_score,
        -- Get the score from the 'last' row (rnk_last = 1)
        MAX(CASE WHEN rnk_last = 1 THEN score END) AS last_score,
        MAX(num_exams) AS total_exams
    FROM RankedScores GROUP BY student_id, subject
)
SELECT DISTINCT student_id, subject FROM FirstAndLastScores
WHERE total_exams >= 2 AND last_score > first_score
ORDER BY student_id ASC, subject ASC;
