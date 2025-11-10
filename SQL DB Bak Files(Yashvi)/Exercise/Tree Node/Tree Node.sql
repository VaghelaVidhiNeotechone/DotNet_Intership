use demoDB;


CREATE TABLE Tree (
    id INT PRIMARY KEY,
    p_id INT
);

INSERT INTO Tree (id, p_id) VALUES
(1, NULL),
(2, 1),
(3, 1),
(4, 2),
(5, 2);

select * from Tree;

select id,
    CASE WHEN p_id IS NULL THEN 'Root'
        WHEN id NOT IN (SELECT DISTINCT p_id FROM Tree WHERE p_id IS NOT NULL) THEN 'Leaf'
    END AS Type
from Tree order by id;
