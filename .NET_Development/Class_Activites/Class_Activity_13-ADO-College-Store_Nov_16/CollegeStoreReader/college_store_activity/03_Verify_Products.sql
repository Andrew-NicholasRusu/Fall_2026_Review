USE CollegeStoreDB;
GO
SELECT COUNT(*) AS TotalProducts FROM dbo.Products;
SELECT ProductID, ProductCode, ProductName, Category, Price, QuantityInStock
FROM dbo.Products
ORDER BY ProductID;
GO
