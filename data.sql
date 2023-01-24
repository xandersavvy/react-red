-- Create a new database called 'Blog'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'Blog'
)
CREATE DATABASE Blog
GO


USE [Blog];

-- Create a new table called 'Users' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('Users', 'U') IS NOT NULL
DROP TABLE Users
GO
-- Create the table in the specified schema
CREATE TABLE Users
(
    [UsersId] [UNIQUEIDENTIFIER] NOT NULL PRIMARY KEY DEFAULT newid(), -- primary key column
    [Name] [VARCHAR](200) NOT NULL,
    [Email] [VARCHAR](450) NOT NULL ,
    [Role] [VARCHAR](7) NOT NULL CHECK([Role] IN('user','admin')) DEFAULT 'user',
    [Password] [VARCHAR](MAX) NOT NULL,
    [TOKEN] [TEXT],
    [Bio] [TEXT],
    [Image] [IMAGE],
    [Registered] [DATE] NOT NULL DEFAULT GETDATE() ,
    UNIQUE([Email])
    -- specify more columns here
);
GO

-- Create a new table called 'Posts' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('Posts', 'U') IS NOT NULL
DROP TABLE [Posts]
GO
-- Create the table in the specified schema
CREATE TABLE [Posts]
(
    [PostsId] [UNIQUEIDENTIFIER] NOT NULL PRIMARY KEY DEFAULT newid(),
    [Header] [nVARCHAR](500) NOT NULL, 
    [Slug] [VARCHAR](450) UNIQUE NOT NULL ,
    [Content] [ntext] NOT NULL,
    
    -- specify more columns here
);
GO