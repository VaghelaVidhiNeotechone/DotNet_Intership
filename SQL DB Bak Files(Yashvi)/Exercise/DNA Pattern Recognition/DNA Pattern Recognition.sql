use DBLeetCode2;

CREATE TABLE Samples (
    sample_id INT PRIMARY KEY,
    dna_sequence VARCHAR(MAX),
    species VARCHAR(255)
);

INSERT INTO Samples (sample_id, dna_sequence, species) VALUES
(1, 'ATGCTAGCTAGCTAA', 'Human'),
(2, 'GGGTCAATCATC', 'Human'),
(3, 'ATATATCGTAGCTA', 'Human'),
(4, 'ATGGGGTCATCATAA', 'Mouse'),
(5, 'TCAGTCAGTCAG', 'Mouse'),
(6, 'ATATCGCGCTAG', 'Zebrafish'),
(7, 'CGTATGCGTCGTA', 'Zebrafish');

select * from Samples;

SELECT sample_id, dna_sequence,  species, 
	CASE WHEN dna_sequence LIKE 'ATG%' THEN 1 ELSE 0 END AS has_start,
    CASE 
        WHEN dna_sequence LIKE '%TAA' THEN 1
        WHEN dna_sequence LIKE '%TAG' THEN 1
        WHEN dna_sequence LIKE '%TGA' THEN 1
        ELSE 0
    END AS has_stop
FROM Samples ORDER BY sample_id ASC;
