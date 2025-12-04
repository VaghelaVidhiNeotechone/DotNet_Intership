create table Samples(
sample_id int primary key,
dna_sequence varchar(255),
species varchar(100)
);

insert into Samples values
(1, 'ATGCTAGCTAGCTAA', 'Human'),
(2, 'GGGTCAATCATC', 'Human'),
(3, 'ATATATCGTAGCTA', 'Human'),
(4, 'ATGGGGTCATCATAA', 'Mouse'),
(5, 'TCAGTCAGTCAG', 'Mouse'),
(6, 'ATATCGCGCTAG', 'Zebrafish'),
(7, 'CGTATGCGTCGTA', 'Zebrafish');

select * from Samples;



SELECT 
    sample_id,
    dna_sequence,
    species,
    
    CASE WHEN dna_sequence LIKE '%ATG%' THEN 1 ELSE 0 END AS has_start,
    CASE WHEN dna_sequence LIKE '%TAA%' THEN 1 ELSE 0 END AS has_stop,
    CASE WHEN dna_sequence LIKE '%ATAT%' THEN 1 ELSE 0 END AS has_atat,
    CASE WHEN dna_sequence LIKE '%GGG%' THEN 1 ELSE 0 END AS has_ggg

FROM Samples;