DROP TABLE EMPLOYEE;

TRUNCATE TABLE EMPLOYEE;

CREATE TABLE EMPLOYEE ( 
	ID				INT					NOT NULL, 
	DEPARTMENT_ID	INT					NOT NULL, 
	NAME			VARCHAR (20)		NOT NULL, 
	MONTHS			INT					NOT NULL, 
	SALARY			DECIMAL (18, 2)		NOT NULL,        
	CONSTRAINT PK_EMPLOYEE PRIMARY KEY (ID), 
	CONSTRAINT FK_DEPARTMENT_ID FOREIGN KEY (DEPARTMENT_ID) REFERENCES DEPARTMENT(ID)
)
;

INSERT INTO EMPLOYEE VALUES (1, 5, 'Rose', 15, 1968);
INSERT INTO EMPLOYEE VALUES (2, 1, 'Angela', 1, 3443);
INSERT INTO EMPLOYEE VALUES (3, 2, 'Frank', 17, 1608);
INSERT INTO EMPLOYEE VALUES (4, 4, 'Patrick', 7, 1345);
INSERT INTO EMPLOYEE VALUES (5, 3, 'Susan', 3, 1453);

SELECT NAME 
FROM EMPLOYEE 
ORDER BY NAME ASC
;

SELECT NAME 
FROM EMPLOYEE 
WHERE SALARY > 2000 
AND MONTHS < 10 
ORDER BY ID ASC
;

SELECT SUM(SALARY), MAX(SALARY), MIN(SALARY), AVG(SALARY)  
FROM EMPLOYEE E 
JOIN DEPARTMENT D ON E.DEPARTMENT_ID = D.ID 
WHERE D.NAME LIKE '%Research%' 
;
