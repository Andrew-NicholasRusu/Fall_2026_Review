-- Query 1 — Subquery in WHERE: Find students whose GPA is higher than the average GPA of all students.
SELECT GPA
FROM STUDENTS
WHERE GPA > (SELECT AVG(GPA) FROM STUDENTS);

-- Query 2 — Subquery in HAVING: Find courses where the average grade is above the overall average grade across all enrollments.
SELECT c.COURSE_ID, c.COURSE_NAME
FROM COURSES c JOIN ENROLLMENTS e ON e.COURSE_ID = c.COURSE_ID
GROUP BY c.COURSE_ID, c.COURSE_NAME
HAVING AVG(e.GRADE) > (SELECT AVG(GRADE) FROM ENROLLMENTS);

-- Query 3 — Subquery in WHERE with comparison: List students who have taken more than one course.
SELECT STUDENT_ID
FROM ENROLLMENTS
GROUP BY STUDENT_ID
HAVING COUNT(DISTINCT COURSE_ID) > 1;

-- Query 4 — Using IN: Display all students who are majoring in the same field as either Alice or Charlie.
SELECT NAME
FROM STUDENTS 
WHERE MAJOR IN (SELECT MAJOR FROM STUDENTS WHERE NAME IN ('Alice' OR 'Charlie'));

-- Query 5: For each course, display the course name and the number of students enrolled in it. 
-- Use GROUP BY and sort the results by the number of students in descending order.
SELECT COURSE_NAME, COUNT(STUDENT_ID) AS Number_Of_Students
FROM COURSES INNER JOIN STUDENTS ON STUDENT_ID = STUDENT_ID
GROUP BY COURSE_NAME
ORDER BY Number_Of_Students DESC;

-- Query 6: For each major, display the major and the average GPA of its students. Use GROUP BY and round the average GPA to two decimal places.
SELECT MAJOR, ROUND(AVG(GPA), 2)
FROM STUDENTS
GROUP BY MAJOR;

-- Query 7: Display each major and its average student GPA, but include only majors with an average GPA greater than 3.40. Use GROUP BY and HAVING.
SELECT MAJOR, AVG(GPA)
FROM STUDENTS
GROUP BY MAJOR
HAVING AVG(GPA) > 3.40;









