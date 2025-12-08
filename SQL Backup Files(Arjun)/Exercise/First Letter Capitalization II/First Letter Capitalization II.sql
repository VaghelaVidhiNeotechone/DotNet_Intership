create table user_content(
content_id int primary key,
content_text varchar(255)
);

insert into user_content values
(1,'hello world of SQL'),
(2,'the QUICK-brown fox'),
(3,'modern-day DATA science'),
(4,'web-based FRONT-end development');

select * from user_content;




WITH SplitWords AS (
    SELECT
        content_id,
        value AS word,
        ROW_NUMBER() OVER (PARTITION BY content_id ORDER BY (SELECT NULL)) AS rn
    FROM user_content
    CROSS APPLY STRING_SPLIT(content_text, ' ')
),
SplitHyphens AS (
    SELECT
        content_id,
        rn,
        value AS part,
        ROW_NUMBER() OVER (PARTITION BY content_id, rn ORDER BY (SELECT NULL)) AS part_rn
    FROM SplitWords
    CROSS APPLY STRING_SPLIT(word, '-')
),
CapitalizedParts AS (
    SELECT
        content_id,
        rn,
        part_rn,
        UPPER(LEFT(part,1)) + LOWER(SUBSTRING(part,2,LEN(part))) AS cap_part
    FROM SplitHyphens
),
RejoinedHyphens AS (
    SELECT
        content_id,
        rn,
        STRING_AGG(cap_part, '-') WITHIN GROUP (ORDER BY part_rn) AS cap_word
    FROM CapitalizedParts
    GROUP BY content_id, rn
),
FinalText AS (
    SELECT
        uc.content_id,
        uc.content_text AS original_text,
        STRING_AGG(rh.cap_word, ' ') WITHIN GROUP (ORDER BY rh.rn) AS converted_text
    FROM user_content uc
    JOIN RejoinedHyphens rh ON uc.content_id = rh.content_id
    GROUP BY uc.content_id, uc.content_text
)

SELECT * FROM FinalText ORDER BY content_id;