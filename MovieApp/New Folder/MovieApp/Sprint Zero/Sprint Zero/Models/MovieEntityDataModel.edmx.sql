
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/02/2018 17:09:26
-- Generated from EDMX file: E:\DownloadsE\Getting Started with ASP.NET MVC 5\repos\Sprint Zero\Sprint Zero\Models\MovieEntityDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MovieDataBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ContactDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactDetails];
GO
IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int  NOT NULL,
    [FirstName] char(50)  NULL,
    [LastName] char(50)  NULL,
    [StreetAddress] nvarchar(50)  NULL,
    [City] char(20)  NULL,
    [State] char(20)  NULL,
    [ZipCode] nchar(10)  NULL,
    [PhoneNumber] int  NULL,
    [BirthData] nchar(10)  NULL,
    [EmailAddress] nchar(50)  NULL
);
GO

-- Creating table 'ContactDetails'
CREATE TABLE [dbo].[ContactDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(50)  NULL,
    [LastName] varchar(50)  NULL,
    [State] char(20)  NULL,
    [PhoneNumber] int  NULL,
    [Password] nvarchar(50)  NULL,
    [Password2] nvarchar(50)  NULL,
    [EmailAddress] nchar(50)  NULL,
    [Game] nchar(50)  NULL,
    [AgeCheck] int  NULL,
    [GameSystem] nchar(50)  NULL
);
GO

-- Creating table 'Movies'
CREATE TABLE [dbo].[Movies] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContactDetails'
ALTER TABLE [dbo].[ContactDetails]
ADD CONSTRAINT [PK_ContactDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [PK_Movies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------