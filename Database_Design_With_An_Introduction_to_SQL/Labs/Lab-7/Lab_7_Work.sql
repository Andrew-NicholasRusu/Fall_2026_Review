# Part 1 – SELECT, DISTINCT, ORDER BY, and WHERE

-- 1. Display the employee ID, first name, last name, and salary of all employees.
SELECT EMPLOYEE_ID, FIRST_NAME, LAST_NAME, SALARY
FROM EMPLOYEES;

-- 2. Display all unique job IDs from the employees table.
SELECT DISTINCT JOB_ID
FROM EMPLOYEES
ORDER BY JOB_ID;

-- 3. Display employee first name, last name, and salary sorted from highest salary to lowest.
SELECT FIRST_NAME, LAST_NAME, SALARY
FROM EMPLOYEES
ORDER BY SALARY DESC;

-- 4. Display the employees who work in department 60.
SELECT *
FROM EMPLOYEES 
WHERE DEPARTMENT_ID = 60;

-- 5. Display the employees whose salary is between 5,000 and 10,000.
SELECT *
FROM EMPLOYEES 
WHERE SALARY BETWEEN 5000 AND 10000;

-- 6. Display the employees whose last name begins with the letter S.
SELECT *
FROM EMPLOYEES
WHERE LAST_NAME LIKE "S%";

# Part 2 – Aggregate Functions

-- 7. Find the total number of employees.
SELECT COUNT(EMPLOYEE_ID)
FROM EMPLOYEES;

-- 8. Find the minimum, maximum, and average employee salary.
SELECT MIN(SALARY), MAX(SALARY), AVG(SALARY)
FROM EMPLOYEES; 

-- 9. Find the maximum salary of employees working as IT_PROG.
SELECT MAX(SALARY)
FROM EMPLOYEES
WHERE JOB_ID = "IT_PROG";

# Use to find all the people in IT_PROG
-- SELECT *
-- FROM EMPLOYEES
-- WHERE JOB_ID = "IT_PROG";

-- 10. Find the difference between the highest and lowest employee salaries.
SELECT  MAX(SALARY) - MIN(SALARY)
FROM EMPLOYEES;

# Part 3 – GROUP BY and HAVING

-- 11. Display each job ID and the number of employees with that job.
SELECT JOB_ID, COUNT(EMPLOYEE_ID) -- We use a count method to find the number of employees in a specific job.
FROM EMPLOYEES
GROUP BY JOB_ID;

-- 12. Display each department ID and the average salary of employees in that department.
SELECT DEPARTMENT_ID, AVG(SALARY)
FROM EMPLOYEES
GROUP BY DEPARTMENT_ID;

-- 13. Display the departments that have more than 5 employees.
SELECT DEPARTMENT_ID, COUNT(*) AS COUNT
FROM EMPLOYEES
GROUP BY DEPARTMENT_ID
HAVING COUNT > 5;

# Part 4 – JOIN Queries

-- 14. Use INNER JOIN to display each employee's first name, last name, department ID, and department name.
SELECT FIRST_NAME, LAST_NAME, DEPARTMENTS.DEPARTMENT_ID, DEPARTMENT_NAME
FROM EMPLOYEES INNER JOIN DEPARTMENTS;

-- 15. Use INNER JOIN to display each employee's first name, last name, job title, and salary.
SELECT FIRST_NAME, LAST_NAME, JOB_TITLE, SALARY
FROM EMPLOYEES INNER JOIN JOBS;

-- 16. Use INNER JOIN to display each department name and its city.
SELECT DEPARTMENT_NAME, CITY
FROM DEPARTMENTS INNER JOIN LOCATIONS;

-- 17. Use LEFT OUTER JOIN to display all departments and their employees, including departments that do not have any employees.
SELECT D.DEPARTMENT_ID, EMPLOYEE_ID
FROM DEPARTMENTS D LEFT JOIN EMPLOYEES E ON D.DEPARTMENT_ID=E.DEPARTMENT_ID;

-- 18. Use LEFT OUTER JOIN to display only the departments that do not have any employees.
SELECT D.DEPARTMENT_ID, EMPLOYEE_ID
FROM DEPARTMENTS D LEFT JOIN EMPLOYEES E ON D.DEPARTMENT_ID = E.DEPARTMENT_ID
WHERE EMPLOYEE_ID IS NULL;

-- 19. Use RIGHT OUTER JOIN to display all locations and any departments assigned to them, including locations that do not have a department.
SELECT L.LOCATION_ID, D.DEPARTMENT_ID
FROM DEPARTMENTS D RIGHT JOIN LOCATIONS L ON L.LOCATION_ID = D.LOCATION_ID;

-- 20. Use a self-join to display the employee ID, employee last name, manager ID, and manager last name.
SELECT  E.EMPLOYEE_ID, E.LAST_NAME, e.MANAGER_ID, M.LAST_NAME AS MAN_LASTNAME
FROM EMPLOYEES E INNER JOIN EMPLOYEES M ON  E.MANAGER_ID=M.EMPLOYEE_ID ;

# Part 5 – Subqueries

-- 21. Subquery in WHERE: Display the first name, last name, and salary of employees who earn more than the average salary of all employees.
Select FIRST_NAME, LAST_NAME, SALARY 
FROM EMPLOYEES
WHERE SALARY > (SELECT AVG (SALARY) FROM EMPLOYEES);

-- 22. Subquery with IN: Display the first name, last name, and department ID of employees who work in a department located in Seattle.
SELECT FIRST_NAME, LAST_NAME, departments.DEPARTMENT_ID 
FROM EMPLOYEES JOIN DEPARTMENTS
WHERE departments.DEPARTMENT_ID IN ("Seattle");

-- 23. Subquery in FROM: Using a subquery in the FROM clause, display each department ID and its average salary, 
-- then show only departments whose average salary is greater than 8,000.
SELECT LIST. DEPARTMENT_ID,  LIST.AVGSALARY
FROM (SELECT E.DEPARTMENT_ID, AVG(E.SALARY) AS AVGSALARY
		FROM EMPLOYEES E JOIN DEPARTMENTS D USING(department_id)
		GROUP BY DEPARTMENT_ID
		HAVING AVGSALARY>8000) AS LIST;
	
-- 24. Subquery in HAVING: Display each job ID and its average salary. 
-- Show only the jobs whose average salary is greater than the average salary of employees working as IT_PROG.
SELECT JOB_ID, AVG(SALARY) AS Average_Salary
FROM EMPLOYEES
GROUP BY JOB_ID
HAVING AVG(SALARY) > (SELECT AVG(SALARY) FROM EMPLOYEES WHERE JOB_ID = 'IT_PROG');

