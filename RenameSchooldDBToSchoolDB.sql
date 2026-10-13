-- Run this in SSMS while connected to localhost\SQLEXPRESS.
-- Close StudentManagementApp first so it releases its SchooldDB connection.
USE [master];
GO

IF DB_ID(N'SchooldDB') IS NULL
BEGIN
    RAISERROR(N'Database SchooldDB was not found on this SQL Server instance. No rename was performed.', 16, 1);
    RETURN;
END;

IF DB_ID(N'SchoolDB') IS NOT NULL
BEGIN
    RAISERROR(N'Database SchoolDB already exists on this SQL Server instance. No rename was performed.', 16, 1);
    RETURN;
END;

ALTER DATABASE [SchooldDB] MODIFY NAME = [SchoolDB];

SELECT name, state_desc
FROM sys.databases
WHERE name = N'SchoolDB';
GO
