Use Hackerrank;

DROP TABLE TRIANGLES;

CREATE TABLE TRIANGLES (
	A	INT	NOT NULL, 
	B	INT	NOT NULL,
	C	INT	NOT NULL
)
;

INSERT INTO TRIANGLES VALUES (20, 20, 23);
INSERT INTO TRIANGLES VALUES (20, 20, 20);
INSERT INTO TRIANGLES VALUES (20, 21, 22);
INSERT INTO TRIANGLES VALUES (13, 14, 30);

SELECT 
	A, 
	B, 
	C 
FROM TRIANGLES 
;

Exec sp_columns TRIANGLES;

-- Isosceles: two equal sides
-- Equilateral: all side lengths are equal
-- Scalene: each side is a different length

SELECT 
	(CASE 
		WHEN ((A + B) > C) AND ((A + C) > B) AND ((B + C) > A) THEN 
			(CASE 
				WHEN A = B AND B = C THEN 'Equilateral' 
				WHEN A = B OR A = C OR B = C THEN 'Isosceles' 
				ELSE /* A != B AND A != C AND B != C THEN */ 'Scalene' 
			END) 
		ELSE 'Not A Triangle' 
	END) AS Type 
FROM TRIANGLES 
;
