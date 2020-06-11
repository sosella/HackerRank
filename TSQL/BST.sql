Use Hackerrank;

DROP TABLE BST;

CREATE TABLE BST (
	N	INT	NOT NULL, 
	P	INT,
)
;

Exec sp_columns BST;

INSERT INTO BST VALUES (1, 2);
INSERT INTO BST VALUES (3, 2);
INSERT INTO BST VALUES (5, 6);
INSERT INTO BST VALUES (7, 6);
INSERT INTO BST VALUES (2, 4);
INSERT INTO BST VALUES (6, 4);
INSERT INTO BST VALUES (4, 15);
INSERT INTO BST VALUES (8, 9);
INSERT INTO BST VALUES (10, 9);
INSERT INTO BST VALUES (12, 13);
INSERT INTO BST VALUES (14, 13);
INSERT INTO BST VALUES (9, 11);
INSERT INTO BST VALUES (13, 11);
INSERT INTO BST VALUES (11, 15);
INSERT INTO BST VALUES (15, NULL);

SELECT 
	N, 
	P 
FROM BST 
;

/*
1	2
3	2
5	6
7	6
2	4
6	4
4	15
8	9
10	9
12	13
14	13
9	11
13	11
11	15
15	NULL
*/

SELECT STUFF (
	(
		SELECT DISTINCT ',' + CONVERT(varchar(10), N) 
		FROM BST 
		FOR XML PATH(''), TYPE
	).value('.', 'NVARCHAR(MAX)') 
	,1,1,''
)
;

/*
1,2,3,5,6,8,9
*/

SELECT DISTINCT P FROM BST;

/*
NULL
2
4
6
9
11
13
15
*/

SELECT 
	N, 
	(CASE WHEN (P IS NULL) THEN 'Root' WHEN N IN (SELECT DISTINCT P FROM BST) THEN 'Inner' ELSE 'Leaf' END) AS Type 
FROM BST 
ORDER BY N 
;
