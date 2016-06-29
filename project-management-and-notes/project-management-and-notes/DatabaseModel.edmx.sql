
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/29/2016 18:46:11
-- Generated from EDMX file: C:\Users\Borche Jankovski\Documents\GitHub\project-managemenet-and-notes\project-management-and-notes\project-management-and-notes\DatabaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjerctManagementAndNotesDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Assignment_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Assignment] DROP CONSTRAINT [FK_Assignment_ToTable];
GO
IF OBJECT_ID(N'[dbo].[FK_CssCode_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CssCode] DROP CONSTRAINT [FK_CssCode_ToTable];
GO
IF OBJECT_ID(N'[dbo].[FK_LoginInfo_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoginInfo] DROP CONSTRAINT [FK_LoginInfo_ToTable];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Assignment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Assignment];
GO
IF OBJECT_ID(N'[dbo].[CssCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CssCode];
GO
IF OBJECT_ID(N'[dbo].[LoginInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoginInfo];
GO
IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Assignments'
CREATE TABLE [dbo].[Assignments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsDone] bit  NULL,
    [ToDo] varchar(max)  NULL,
    [ProjectId] int  NULL
);
GO

-- Creating table 'CssCodes'
CREATE TABLE [dbo].[CssCodes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Function] varchar(max)  NULL,
    [Code] varchar(max)  NULL,
    [ProjectId] int  NULL
);
GO

-- Creating table 'LoginInfoes'
CREATE TABLE [dbo].[LoginInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Url] varchar(max)  NULL,
    [Username] varchar(max)  NULL,
    [Password] varchar(max)  NULL,
    [ProjectId] int  NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NULL,
    [Client] varchar(max)  NULL,
    [StartDate] datetime  NULL,
    [FinishDate] datetime  NULL,
    [DeadLine] datetime  NULL,
    [Status] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Assignments'
ALTER TABLE [dbo].[Assignments]
ADD CONSTRAINT [PK_Assignments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CssCodes'
ALTER TABLE [dbo].[CssCodes]
ADD CONSTRAINT [PK_CssCodes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LoginInfoes'
ALTER TABLE [dbo].[LoginInfoes]
ADD CONSTRAINT [PK_LoginInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProjectId] in table 'Assignments'
ALTER TABLE [dbo].[Assignments]
ADD CONSTRAINT [FK_Assignment_ToTable]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Assignment_ToTable'
CREATE INDEX [IX_FK_Assignment_ToTable]
ON [dbo].[Assignments]
    ([ProjectId]);
GO

-- Creating foreign key on [ProjectId] in table 'CssCodes'
ALTER TABLE [dbo].[CssCodes]
ADD CONSTRAINT [FK_CssCode_ToTable]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CssCode_ToTable'
CREATE INDEX [IX_FK_CssCode_ToTable]
ON [dbo].[CssCodes]
    ([ProjectId]);
GO

-- Creating foreign key on [ProjectId] in table 'LoginInfoes'
ALTER TABLE [dbo].[LoginInfoes]
ADD CONSTRAINT [FK_LoginInfo_ToTable]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LoginInfo_ToTable'
CREATE INDEX [IX_FK_LoginInfo_ToTable]
ON [dbo].[LoginInfoes]
    ([ProjectId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------