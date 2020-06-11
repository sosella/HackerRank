Use Hackerrank;

DROP TABLE CITY;

CREATE TABLE CITY (
	ID			INT             NOT NULL, 
	NAME		VARCHAR (17)    NOT NULL, 
	COUNTRYCODE	VARCHAR (3)     NOT NULL, 
	DISTRICT	VARCHAR (20)	NOT NULL, 
	POPULATION	INT				NOT NULL, 
	PRIMARY KEY (ID)
)
;

INSERT INTO CITY VALUES (3878, 'Scottsdale', 'USA', 'Arizona', 202705);
INSERT INTO CITY VALUES (3965, 'Corona', 'USA', 'California', 124966);
INSERT INTO CITY VALUES (3973, 'Concord', 'USA', 'California', 121780);
INSERT INTO CITY VALUES (3977, 'Cedar Rapids', 'USA', 'Iowa', 120758);
INSERT INTO CITY VALUES (3982, 'Coral Springs', 'USA', 'Florida', 117549);
INSERT INTO CITY VALUES (1613, 'Neyagawa', 'JPN', 'Osaka', 257315);
INSERT INTO CITY VALUES (1630, 'Ageo', 'JPN', 'Saitama', 209442);
INSERT INTO CITY VALUES (1661, 'Sayama', 'JPN', 'Saitama', 162472);
INSERT INTO CITY VALUES (1681, 'Omuta', 'JPN', 'Fukuoka', 142889);
INSERT INTO CITY VALUES (1739, 'Tokuyama', 'JPN', 'Yamaguchi', 107078);

SELECT * FROM CITY WHERE COUNTRYCODE = 'USA' AND POPULATION > 100000;

SELECT NAME FROM CITY WHERE COUNTRYCODE = 'USA' AND POPULATION > 120000;

SELECT * FROM CITY;

SELECT * FROM CITY WHERE ID = 1661;

SELECT * FROM CITY WHERE COUNTRYCODE = 'JPN';

SELECT NAME FROM CITY WHERE COUNTRYCODE = 'JPN';

SELECT * FROM CITY WHERE ID = 1661;

SELECT * FROM CITY WHERE COUNTRYCODE = 'USA' AND POPULATION > 100000;

SELECT 
	POPULATION 
FROM CITY 
WHERE COUNTRYCODE = 'USA' AND DISTRICT = 'California' 
;

SELECT 
    AVG(POPULATION) 
FROM CITY 
;

SELECT 
    CAST(ROUND(AVG(POPULATION),0) AS int)
FROM CITY 
;