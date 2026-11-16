-- Run after 01_Create_Database_And_Table.sql.
-- This script can be rerun without duplicating product codes.
USE CollegeStoreDB;
GO
SET NOCOUNT ON;

;WITH Numbers AS (
    SELECT 1 AS n
    UNION ALL
    SELECT n + 1 FROM Numbers WHERE n < 100
)
INSERT INTO dbo.Products (ProductCode, ProductName, Category, Price, QuantityInStock)
SELECT
    'P' + RIGHT('0000' + CAST(n AS VARCHAR(4)), 4),
    CASE n
        WHEN 1 THEN 'Notebook A5'
        WHEN 2 THEN 'Ballpoint Pen Blue'
        WHEN 3 THEN 'USB Flash Drive 32GB'
        ELSE 'Product ' + CAST(n AS VARCHAR(3))
    END,
    CASE
        WHEN n IN (1,2) THEN 'Stationery'
        WHEN n = 3 THEN 'Electronics'
        WHEN n % 4 = 0 THEN 'Books'
        WHEN n % 4 = 1 THEN 'Accessories'
        WHEN n % 4 = 2 THEN 'Stationery'
        ELSE 'Electronics'
    END,
    CASE n
        WHEN 1 THEN CAST(4.99 AS DECIMAL(10,2))
        WHEN 2 THEN CAST(1.49 AS DECIMAL(10,2))
        WHEN 3 THEN CAST(12.99 AS DECIMAL(10,2))
        WHEN 100 THEN CAST(24.99 AS DECIMAL(10,2))
        ELSE CAST(2.99 + (n % 40) * 1.75 AS DECIMAL(10,2))
    END,
    CASE n
        WHEN 1 THEN 120
        WHEN 2 THEN 250
        WHEN 3 THEN 45
        WHEN 100 THEN 30
        ELSE 10 + (n * 7) % 191
    END
FROM Numbers
WHERE NOT EXISTS (
    SELECT 1 FROM dbo.Products p
    WHERE p.ProductCode = 'P' + RIGHT('0000' + CAST(n AS VARCHAR(4)), 4)
)
OPTION (MAXRECURSION 100);
GO
