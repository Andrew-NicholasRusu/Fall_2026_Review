-- 1) Show all invoices, including the invoice number, invoice date, invoice total, employee full name, and employee email.
SELECT INV_NUM, INV_DATE, INV_TOTAL, EMP_FNAME, EMP_EMAIL
FROM LGINVOICE NATURAL JOIN LGEMPLOYEE;

-- 2) Show all invoices and their invoice lines. Include the invoice number, invoice date, product SKU, product description, quantity, and line price. Order the results by product description.
SELECT INV_NUM, INV_DATE, PROD_SKU, LINE_QTY, LINE_PRICE
FROM LGINVOICE NATURAL JOIN LGLINE
ORDER BY PROD_DESCRIPT;

-- 3) Show all vendors that are located in Florida (FL) or Vermont (VT). Include the vendor ID, vendor name, city, and state. Order the results by state and then vendor name.
SELECT VEND_ID, VEND_NAME, VEND_CITY, VEND_STATE
FROM LGVENDOR
WHERE VEND_STATE LIKE 'VT' OR VEND_STATE LIKE 'FL'
ORDER BY VEND_STATE, VEND_NAME;

-- 4) Display the different product categories found in the LGPRODUCT table. Each category should appear only once. Order the categories alphabetically.
SELECT PROD_SKU, PROD_DESCRIPT, PROD_CATEGORY, PROD_PRICE
FROM LGPRODUCT
WHERE PROD_PRICE BETWEEN 20 AND 40
ORDER BY PROD_PRICE DESC;

-- 5) Show all products with a price between $20 and $40. Include the product SKU, description, category, and price. Order the results from highest price to lowest price.
SELECT PROD_SKU, PROD_DESCRIPT, PROD_QOH, PROD_PRICE
FROM LGPRODUCT
ORDER BY PROD_PRICE <= 20  AND PROD_PRICE >= 150;

-- 6) Show all products whose description contains the word 'Primer'. Include the product SKU, description, product type, product base, and price. Order the results by product description.
SELECT PROD_SKU, PROD_DESCRIPT, PROD_TYPE, PROD_BASE, PROD_PRICE LIKE "Primer"
FROM LGPRODUCT
ORDER BY PROD_DESCRIPT;

-- 7) Show the employee number, first name, last name, title, and department number for employees who work in department 200 or department 300. Order the results by last name and then first name.
SELECT EMP_NUM, EMP_FNAME, EMP_LNAME, EMP_TITLE, DEPT_NUM LIKE '200' OR '300'
FROM LGEMPLOYEE
ORDER BY EMP_LNAME, EMP_FNAME;

-- 8) Show each product together with its brand information. Include the product SKU, product description, product price, brand name, and brand type. Order the results by brand name and then product description.
SELECT PROD_SKU, PROD_DESCRIPT, PROD_PRICE, BRAND_NAME, BRAND_TYPE
FROM LGBRAND, LGPRODUCT
ORDER BY BRAND_NAME, PROD_DESCRIPT;

-- 9) Show the invoice number, line number, product SKU, quantity, line price, and a calculated column named LineTotal that shows LINE_QTY * LINE_PRICE. Order the results by invoice number and line number.
SELECT INV_NUM, LINE_NUM, PROD_SKU, LINE_QTY, LINE_PRICE, LINE_QTY * LINE_PRICE AS LineTotal
FROM LGLINE
ORDER BY INV_NUM, LINE_NUM;

-- 10) Show customer information for invoices with an invoice total greater than $500. 
-- Include the customer code, customer first name, customer last name, invoice number, invoice date, and invoice total. 
-- Order the results from highest invoice total to lowest.
SELECT LGCUSTOMER.CUST_CODE, CUST_FNAME, CUST_LNAME, INV_NUM, INV_DATE, INV_TOTAL
FROM LGCUSTOMER INNER JOIN LGINVOICE ON lgcustomer.CUST_CODE = lginvoice.CUST_CODE
WHERE INV_TOTAL > 500
ORDER BY INV_TOTAL DESC;

