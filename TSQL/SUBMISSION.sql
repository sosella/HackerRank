DROP TABLE SUBMISSIONS;

CREATE TABLE SUBMISSIONS (
	SUBMISSION_ID	INT		NOT NULL, 
	HACKER_ID		INT		NOT NULL, 
--	CHALLENGE_ID	INT		NOT NULL, 
	SCORE			INT		NOT NULL, 
	SUBMISSION_DATE DATE	NOT NULL, 
	PRIMARY KEY (SUBMISSION_ID)
)
;

SELECT S.SUBMISSION_DATE, H.HACKER_ID, H.NAME 
FROM SUBMISSIONS S
JOIN HACKERS H ON S.HACKER_ID = H.HACKER_ID 
WHERE S.SUBMISSION_DATE >= '20160301' AND S.SUBMISSION_DATE <= '20160301' 
AND S.SCORE > 90 
ORDER BY S.SUBMISSION_DATE ASC  
;

/*
2016-03-01 2697 Earl 
2016-03-01 19516 Brian 
2016-03-01 22750 Mildred 
2016-03-01 43192 Bobby 
2016-03-01 56909 Arthur 
2016-03-01 83509 Sharon 
2016-03-01 83968 Julie 
2016-03-01 89737 Jeremy 
2016-03-01 97530 Amy
*/

SELECT SUBMISSION_DATE, SUBMISSION_ID, MAX(SCORE) AS MAX_SCORE 
FROM SUBMISSIONS 
WHERE SUBMISSION_DATE >= '20160301' AND SUBMISSION_DATE <= '20160301' 
GROUP BY SUBMISSION_ID, SUBMISSION_DATE 
HAVING MAX(SCORE) > 0 
ORDER BY SUBMISSION_DATE ASC 
;

/*
2016-03-01 2624 85 
2016-03-01 2676 95 
2016-03-01 2686 10 
2016-03-01 2823 35 
2016-03-01 2947 55 
...
*/