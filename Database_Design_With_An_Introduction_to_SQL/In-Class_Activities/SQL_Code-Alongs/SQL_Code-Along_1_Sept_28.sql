SELECT * # Selects everything from the database;
FROM PRODUCT; 

SELECT P_CODE, P_DESCRIPT, P_PRICE, P_QOH
FROM PRODUCT;

SELECT P_CODE, P_DESCRIPT, P_PRICE AS "UNIT PRICE", P_QOH # Changes the P_PRICE column name to UNIT PRICE
FROM PRODUCT;

SELECT P_CODE, P_DESCRIPT, P_PRICE, P_QOH AS "QUANTITY" # Changes the P_QOH column name to QUANTITY
FROM PRODUCT;

SELECT P_DESCRIPT, P_QOH, P_PRICE, P_QOH * P_PRICE AS "TOTAL VALUE"
FROM PRODUCT;

SELECT DISTINCT V_CODE # Removes repeated lines
FROM PRODUCT;

# Retrieves invite number, product code, and line units from the line table
SELECT INV_NUMBER, P_CODE, LINE_UNITS 
FROM LINE;

SELECT P_CODE, P_DESCRIPT, P_PRICE
FROM PRODUCT
ORDER BY P_PRICE;  # Sorts the table based on P_PRICE

SELECT P_CODE, P_DESCRIPT, P_PRICE
FROM PRODUCT
ORDER BY P_PRICE DESC;  # Sorts the table based on P_PRICE (DESCENDING)

SELECT EMP_LNAME, EMP_FNAME, EMP_INITIAL, EMP_AREACODE, EMP_PHONE
FROM EMPLOYEE
ORDER BY EMP_LNAME, EMP_FNAME, EMP_INITIAL; # Sorts based on the employee last name, employee first name, and the initial of the employee

SELECT P_DESCRIPT, P_QOH, P_PRICE, V_CODE
FROM PRODUCT
WHERE V_CODE = 21344; # Selects all values in the table with the V_CODE being 21344

SELECT P_DESCRIPT, P_QOH, P_PRICE, V_CODE
FROM PRODUCT
WHERE V_CODE <> 21344; # Gets all the values in the table, except for the selected values with V_CODE 21344

SELECT P_DESCRIPT, P_QOH, P_MIN, P_PRICE
FROM PRODUCT
WHERE P_PRICE <= 10;

SELECT P_DESCRIPT, P_PRICE, P_QOH
FROM PRODUCT
WHERE P_PRICE > 100 AND P_QOH < 20; # Selects the list of products when their price is more than 100 but their quantity is less than 20.

