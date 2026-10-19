-- Result 1
SELECT P_CODE, VENDOR.V_CODE, V_NAME
FROM VENDOR LEFT JOIN PRODUCT ON VENDOR.V_CODE = PRODUCT.V_CODE; -- Returns all vendors, including vendors that have no products.

-- Result 2
SELECT P_CODE, VENDOR.V_CODE, V_NAME
FROM VENDOR RIGHT JOIN PRODUCT ON VENDOR.V_CODE = PRODUCT.V_CODE; -- Returns all products, including products that do not have a matching vendor.

-- Result 3
SELECT VENDOR.V_CODE, V_NAME, P_CODE
FROM PRODUCT RIGHT JOIN VENDOR ON PRODUCT.V_CODE = VENDOR.V_CODE
WHERE P_CODE IS NULL; -- Finds vendors that are not associated with any product (using right join)
-- Because VENDOR is on the right side of the RIGHT JOIN, all vendors are preserved.

-- Result 4
SELECT P_DESCRIPT, P_PRICE, V_NAME
FROM VENDOR V JOIN PRODUCT P ON V.V_CODE = P.V_CODE; -- Returns products that have a matching vendor.
-- V and P are table aliases.

-- Result 5
SELECT E.EMP_NUM, E.EMP_LNAME, E.EMP_MGR, M.EMP_LNAME
FROM EMP E JOIN EMP M ON E.EMP_MGR = M.EMP_NUM; -- This is a self-join. The EMP table is joined to itself.
-- E represents the employee.
-- M represents the employee’s manager.
-- E.EMP_MGR contains the manager’s employee number.
-- M.EMP_LNAME gives the manager’s last name.

-- Result 6
SELECT COUNT(P_CODE)
FROM PRODUCT; -- Counts the number of codes in PRODUCT

-- Result 7
SELECT COUNT(P_CODE)
FROM PRODUCT
WHERE P_PRICE < 10; -- Counts products whose price is less than $10.

-- Result 8
SELECT COUNT(V_CODE)
FROM PRODUCT; -- Counts non-NULL vendor codes in the PRODUCT table.

-- Result 9
SELECT COUNT(DISTINCT V_CODE)
FROM PRODUCT;

-- Result 10
SELECT MIN(P_PRICE) AS MINPRICE, MAX(P_PRICE) AS MAXPRICE
FROM PRODUCT; -- Returns the lowest and highest product prices.

-- Result 11
SELECT SUM(CUS_BALANCE) AS TOTALBALANCE
FROM CUSTOMER; -- Adds all customer balances together.
-- SUM() ignores NULL values. 

-- Result 12
SELECT V_CODE, AVG(P_PRICE) AS AVERAGEPRICE
FROM PRODUCT; -- Invalid

-- Result 13
SELECT V_CODE, AVG(P_PRICE) AS AVERAGEPRICE
FROM PRODUCT
GROUP BY V_CODE; -- Calculates the average product price for each vendor.

-- Result 14
SELECT VENDOR.V_CODE, V_NAME, COUNT(P_CODE)
FROM PRODUCT JOIN VENDOR ON PRODUCT.V_CODE = VENDOR.V_CODE
GROUP BY V_CODE; -- Counts how many products each vendor supplies and show the vendor name.

-- Result 15
SELECT VENDOR.V_CODE, SUM(P_QOH), V_NAME, COUNT(P_CODE)
FROM PRODUCT JOIN VENDOR ON PRODUCT.V_CODE = VENDOR.V_CODE
GROUP BY V_CODE
ORDER BY V_NAME;

-- Result 16
SELECT VENDOR.V_CODE, P_QOH, V_NAME, COUNT(P_CODE)
FROM PRODUCT JOIN VENDOR ON PRODUCT.V_CODE = VENDOR.V_CODE
GROUP BY V_CODE, P_QOH
ORDER BY V_NAME;

-- Result 17 
SELECT V_CODE, COUNT(P_CODE) 
FROM PRODUCT 
GROUP BY V_CODE
HAVING AVG(P_PRICE) < 10; -- Finds vendors whose average product price is less than $10, and returns the number of 
-- products for each such vendor.




