-- Run first in SQL Server Management Studio.
IF DB_ID(N'CollegeStoreDB') IS NULL
    CREATE DATABASE CollegeStoreDB;
GO
USE CollegeStoreDB;
GO
IF OBJECT_ID(N'dbo.Products', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Products (
        ProductID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        ProductCode VARCHAR(10) NOT NULL UNIQUE,
        ProductName VARCHAR(100) NOT NULL,
        Category VARCHAR(50) NOT NULL,
        Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
        QuantityInStock INT NOT NULL CHECK (QuantityInStock >= 0)
    );
END;
GO
