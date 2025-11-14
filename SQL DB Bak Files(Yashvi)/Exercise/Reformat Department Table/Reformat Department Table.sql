use DBLeetCode;

CREATE TABLE Department (
    id INT,
    revenue INT,
    month VARCHAR(3),
    PRIMARY KEY (id, month)
);

INSERT INTO Department (id, revenue, month) VALUES
(1, 8000, 'Jan'),
(2, 9000, 'Jan'),
(3, 10000, 'Feb'),
(1, 7000, 'Feb'),
(1, 6000, 'Mar');

select * from Department;

SELECT id, JAN AS Jan_Revenue,
    FEB AS Feb_Revenue, 
    MAR AS Mar_Revenue, 
    APR AS Apr_Revenue, 
    MAY AS May_Revenue,
    JUN AS Jun_Revenue,
    JUL AS Jul_Revenue, 
    AUG AS Aug_Revenue,
    SEP AS Sep_Revenue, 
    OCT AS Oct_Revenue,
    NOV AS Nov_Revenue,
    DEC AS Dec_Revenue
FROM Department
PIVOT
(
    SUM(revenue)
    FOR month IN (JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV,DEC)
) P