-- 1)	Write a query to count the number of invoices.
SELECT COUNT(INV_NUMBER)
FROM INVOICE;

-- 2)	Write a query to count the number of customers with balance of more than $500.
SELECT COUNT(CUS_CODE)
FROM CUSTOMER
WHERE CUS_BALANCE > 500;

-- 3)	Write a query to compute the total of all purchases, the number of purchases, and the average purchase amount made by 
-- each customer. Sort the result by customer code.
SELECT  CUSTOMER.CUS_CODE, SUM(LINE_UNITS*LINE_PRICE), COUNT(*), AVG (LINE_UNITS*LINE_PRICE) 
FROM CUSTOMER JOIN INVOICE USING (CUS_CODE) JOIN LINE USING (INV_NUMBER) 
GROUP BY CUSTOMER.CUS_CODE
ORDER BY CUSTOMER.CUS_CODE;

-- 4)	Write a query to produce the total purchase per invoice sorted by invoice number. The invoice total is the sum of the 
-- products purchases in the LINE that corresponds to the INVOICE. 
SELECT INV_NUMBER, SUM(LINE_UNITS*LINE_PRICE) AS TOTALPURCHASE
FROM LINE 
GROUP BY INV_NUMBER
ORDER BY INV_NUMBER;

-- 5)	Get the balances of customers who made a purchase.
SELECT CUSTOMER.CUS_CODE, CUS_BALANCE
FROM CUSTOMER JOIN INVOICE ON CUSTOMER.CUS_CODE = INVOICE.CUS_CODE
ORDER BY CUS_CODE;

-- 6)	Get the balances of customers who did not make a purchase (Outer join).
SELECT CUSTOMER.CUS_CODE, CUSTOMER.CUS_BALANCE
FROM CUSTOMER LEFT JOIN INVOICE ON CUSTOMER.CUS_CODE = INVOICE.CUS_CODE
WHERE INVOICE.CUS_CODE IS NULL
ORDER BY CUSTOMER.CUS_CODE;


