# ch07_saleco schema:

-- Result 1
SELECT EMP_LNAME, EMP_FNAME, EMP_DOB
FROM EMPLOYEE
WHERE YEAR (EMP_DOB) = 1983; -- Gives us a table where it selects the ones with a year in 1983

-- Result 2
SELECT EMPL_LNAME, EMP_FNAME, EMP_DOB
FROM EMPLOYEE
WHERE MONTH (EMP_DOB) = 11; -- Gives us a table where the month is thr 11th one (November)

-- Result 3
SELECT EMPL_LNAME, EMP_FNAME, EMP_DOB
FROM EMPLOYEE
WHERE DATE (EMP_DOB) = 14; -- Gives us a table where the date is the 14th in a month

-- Result 4
SELECT P_CODE, P_INDATE, DATE_ADD(P_INDATE, INTERVAL 30 DAY)
FROM PRODUCT;
-- DATE_ADD: Make it as a date
-- INTERVAL: Range of 2 numbers

SELECT EMP_AREACODE, EMP_YEARS, EMP_PHONE, DATE_ADD(EMP_HIRE_DATE, INTERVAL 15 DAY) -- 15 different results
FROM EMPLOYEE;

SELECT EMP_AREACODE, EMP_YEARS, EMP_PHONE, DATE_ADD(EMP_HIRE_DATE, INTERVAL 5 DAY) -- Everything from 1 to 5
FROM EMPLOYEE;

-- Result 5
SELECT P_CODE, P_PRICE, ROUND(P_PRICE, 1), ROUND(P_PRICE, 0)
FROM PRODUCT;
-- ROUND: Rounds a number to specified decimal points (ROUND(P_PRICE, 1) = Rounded to the nearest decimal)
-- ROUND(P_PRICE, 0) = rounding to the whole value

-- Result 6
SELECT EMP_FNAME, UPPER(EMP_LNAME)
FROM EMPLOYEE;
-- UPPER: Makes all the variables upper case (CAPS)

SELECT LOWER(CUS_LNAME), LOWER(CUS_LNAME)
FROM CUSTOMER;
-- LOWER: Makes all the variables lower case (bottom case)

-- Result 7
SELECT CONCAT(EMP_LNAME, ', ') AS Employee_Last_Name, EMP_FNAME AS Employee_First_Name
FROM EMPLOYEE;

-- Result 8
# List EMPLOYEE and FAMILY_NAME in this format: ROBERT, BIERMAN
SELECT UPPER (CONCAT(EMP_FNAME, ', ', EMP_LNAME)) AS FULLNAME
FROM EMPLOYEE;

-- Result 9
SELECT EMP_LNAME, EMP_PHONE, SUBSTRING(EMP_PHONE, 1, 3) AS AREACODE
FROM EMPLOYEE;
-- SUBSTRING Extract 3 characters from a string, starting in position 1:

SELECT *
FROM LINE;

SELECT INV_NUMBER, P_CODE, SUBSTRING(P_CODE, 1, 4) AS Smaller_Value
FROM LINE;

-- Result 10
SELECT EMP_LNAME, LENGTH(EMP_LNAME) -- LENGTH: Gives the length (characters) in a table 
FROM EMPLOYEE;

SELECT INV_NUMBER, CUS_CODE
FROM INVOICE;

SELECT INV_NUMBER, LENGTH(CUS_CODE) AS Length
FROM INVOICE;





