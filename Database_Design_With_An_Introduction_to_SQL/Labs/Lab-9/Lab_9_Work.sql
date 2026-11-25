################### Lab 9: DDL and DML QUERIES ###################

-- 1. Create a database named SimpleCo.
CREATE SCHEMA SimpleCo;

-- 2. Create the CUSTOMER table as illustrated in the figure above.
CREATE TABLE CUSTOMER (
-- The customer number should store integer values 
CUST_NUM INTEGER UNIQUE,
-- The customer name attributes (first and last) should use variable-length character data up to 30 characters each.
CUST_LNAME VARCHAR(30) NOT NULL,
CUST_FNAME VARCHAR(30) NOT NULL,
-- The customer balance should support up to six digits to the left of the decimal point and two digits to the right.
CUST_BALANCE NUMERIC (8, 2),
PRIMARY KEY (CUST_NUM)); -- customer number serves as the primary key.

-- 3. Create the INVOICE table as illustrated in the figure above.
CREATE TABLE INVOICE (
-- The invoice number should store integer values 
INV_NUM INTEGER UNIQUE,
-- Include a customer number column that will later reference the CUSTOMER table.
CUST_NUM INTEGER,
-- The invoice date should store date values.
INV_DATE DATE,
-- The invoice amount should support up to eight digits to the left of the decimal point and two digits to the right.
INV_AMOUNT NUMERIC (10, 2),
PRIMARY KEY (INV_NUM)); -- serve as the primary key.

-- 4. Write the SQL commands to insert the data into the CUSTOMER table as shown in the figure above.
INSERT INTO CUSTOMER
	VALUES (1000, 'Smith', 'Jeanne', 1050.11);
INSERT INTO CUSTOMER
    VALUES (1001, 'Ortega', 'Juan', 840.92);

SELECT * 
FROM CUSTOMER;

-- 5. Write the SQL commands to insert the data into the INVOICE table as shown in the figure above.

INSERT INTO INVOICE 
	VALUES (8000, 1000, '23-03-22', 235.89);
INSERT INTO INVOICE 
	VALUES (8001, 1001, '23-03-22', 312.82);
INSERT INTO INVOICE 
	VALUES (8002, 1001, '30-03-22', 528.10);
INSERT INTO INVOICE 
	VALUES (8003, 1000, '12-03-22', 194.78);
INSERT INTO INVOICE 
	VALUES (8004, 1000, '23-03-22', 619.44);
    
SELECT *
FROM INVOICE;

-- 6.	Insert the following new customer into the CUSTOMER table:
-- (1002, 'Powers', 'Ruth', 500);

INSERT INTO CUSTOMER
	VALUES (1002, 'Powers', 'Ruth', 500);
SELECT *
FROM CUSTOMER;

-- 7.	Modify the CUSTOMER table to include a new column named CUST_DOB that stores date values.
ALTER TABLE CUSTOMER
ADD CUST_DOB DATE;
SELECT *
FROM CUSTOMER;

-- 8.Update the following customers to include their date of birth:
	-- Customer 1000 → March 15, 1998
	-- Customer 1001 → December 22, 1988
UPDATE CUSTOMER
SET CUST_DOB = '1998-03-15'
WHERE CUST_NUM = 1000;
UPDATE CUSTOMER
SET CUST_DOB = '1998-12-22'
WHERE CUST_NUM = 1001;

SELECT *
FROM CUSTOMER;

-- 9. Write an SQL command to add a check constraint to the CUSTOMER table ensuring that the customer balance is always greater than or equal to zero.
ALTER TABLE CUSTOMER
ADD CHECK(CUST_BALANCE >= 0);

-- 10.	Write an SQL command to add a foreign key constraint to the INVOICE table so that the customer number 
-- in the INVOICE table references the customer number in the CUSTOMER table.
ALTER TABLE INVOICE 
ADD FOREIGN KEY (CUST_NUM) REFERENCES CUSTOMER(CUST_NUM);

-- 11.	Write an SQL command to delete the invoice with invoice number 8003 from the INVOICE table.
DELETE 
FROM INVOICE
WHERE INV_NUM = 8003;
SELECT *
FROM INVOICE;

################### Additionl Practice ###################

-- 12. Modify the CUSTOMER table so that CUST_BALANCE uses NUMERIC(9,2).
ALTER TABLE CUSTOMER
MODIFY CUST_BALANCE NUMERIC (9, 2);
SELECT *
FROM CUSTOMER;

-- 13. Add a new column named CUST_EMAIL to the CUSTOMER table. It should store variable-length character data up to 50 characters. 
-- Then write a second SQL command to remove the CUST_EMAIL column.
ALTER TABLE CUSTOMER
ADD CUST_EMAIL VARCHAR (50);
SELECT *
FROM CUSTOMER;

ALTER TABLE CUSTOMER
DROP COLUMN CUST_EMAIL; -- Drops CUST_EMAIL in CUSTOMER 
SELECT *
FROM CUSTOMER;

-- 14. Create a new table named HIGH_BALANCE_CUSTOMERS that contains all columns and rows from CUSTOMER where CUST_BALANCE is greater than 500.
CREATE TABLE HIGH_BALANCE_CUSTOMERS AS
SELECT *
FROM CUSTOMER 
WHERE CUST_BALANCE > 500;

-- To make sure
SELECT * 
FROM HIGH_BALANCE_CUSTOMERS; 

-- 15. After verifying that HIGH_BALANCE_CUSTOMERS was created correctly, write a SQL command to remove the HIGH_BALANCE_CUSTOMERS table from the database.
DROP TABLE HIGH_BALANCE_CUSTOMERS;

















