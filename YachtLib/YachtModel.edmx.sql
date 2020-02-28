
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/28/2020 08:18:08
-- Generated from EDMX file: C:\Users\I2CM Developer\Documents\Yachtcharter\Yachtcharter\YachtLib\YachtModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [YachtCharter];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_LiegtIn]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Schiffs] DROP CONSTRAINT [FK_LiegtIn];
GO
IF OBJECT_ID(N'[dbo].[FK_IstEignerVon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Schiffs] DROP CONSTRAINT [FK_IstEignerVon];
GO
IF OBJECT_ID(N'[dbo].[FK_Macht_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Macht] DROP CONSTRAINT [FK_Macht_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_Macht_Toern]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Macht] DROP CONSTRAINT [FK_Macht_Toern];
GO
IF OBJECT_ID(N'[dbo].[FK_IstZugeordnet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Toerns] DROP CONSTRAINT [FK_IstZugeordnet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[Bases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bases];
GO
IF OBJECT_ID(N'[dbo].[Schiffs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Schiffs];
GO
IF OBJECT_ID(N'[dbo].[Toerns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Toerns];
GO
IF OBJECT_ID(N'[dbo].[Macht]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Macht];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Vorname] nvarchar(max)  NULL,
    [Adresse] nvarchar(max)  NULL,
    [Segelschein] bit  NULL,
    [RoleCustomer] bit  NOT NULL,
    [RoleAdmin] bit  NOT NULL
);
GO

-- Creating table 'Bases'
CREATE TABLE [dbo].[Bases] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ort] nvarchar(max)  NOT NULL,
    [Land] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Schiffs'
CREATE TABLE [dbo].[Schiffs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EignerId] int  NOT NULL,
    [BasisId] int  NOT NULL,
    [PersonId1] int  NOT NULL,
    [Typ] nvarchar(max)  NOT NULL,
    [Laenge] smallint  NOT NULL,
    [Baujahr] smallint  NOT NULL,
    [Schiffsname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Toerns'
CREATE TABLE [dbo].[Toerns] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SchiffId] int  NOT NULL,
    [Start] datetime  NOT NULL,
    [Ende] datetime  NOT NULL
);
GO

-- Creating table 'Macht'
CREATE TABLE [dbo].[Macht] (
    [People_Id] int  NOT NULL,
    [Toerns_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bases'
ALTER TABLE [dbo].[Bases]
ADD CONSTRAINT [PK_Bases]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Schiffs'
ALTER TABLE [dbo].[Schiffs]
ADD CONSTRAINT [PK_Schiffs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Toerns'
ALTER TABLE [dbo].[Toerns]
ADD CONSTRAINT [PK_Toerns]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [People_Id], [Toerns_Id] in table 'Macht'
ALTER TABLE [dbo].[Macht]
ADD CONSTRAINT [PK_Macht]
    PRIMARY KEY CLUSTERED ([People_Id], [Toerns_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BasisId] in table 'Schiffs'
ALTER TABLE [dbo].[Schiffs]
ADD CONSTRAINT [FK_LiegtIn]
    FOREIGN KEY ([BasisId])
    REFERENCES [dbo].[Bases]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LiegtIn'
CREATE INDEX [IX_FK_LiegtIn]
ON [dbo].[Schiffs]
    ([BasisId]);
GO

-- Creating foreign key on [PersonId1] in table 'Schiffs'
ALTER TABLE [dbo].[Schiffs]
ADD CONSTRAINT [FK_IstEignerVon]
    FOREIGN KEY ([PersonId1])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IstEignerVon'
CREATE INDEX [IX_FK_IstEignerVon]
ON [dbo].[Schiffs]
    ([PersonId1]);
GO

-- Creating foreign key on [People_Id] in table 'Macht'
ALTER TABLE [dbo].[Macht]
ADD CONSTRAINT [FK_Macht_Person]
    FOREIGN KEY ([People_Id])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Toerns_Id] in table 'Macht'
ALTER TABLE [dbo].[Macht]
ADD CONSTRAINT [FK_Macht_Toern]
    FOREIGN KEY ([Toerns_Id])
    REFERENCES [dbo].[Toerns]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Macht_Toern'
CREATE INDEX [IX_FK_Macht_Toern]
ON [dbo].[Macht]
    ([Toerns_Id]);
GO

-- Creating foreign key on [SchiffId] in table 'Toerns'
ALTER TABLE [dbo].[Toerns]
ADD CONSTRAINT [FK_IstZugeordnet]
    FOREIGN KEY ([SchiffId])
    REFERENCES [dbo].[Schiffs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IstZugeordnet'
CREATE INDEX [IX_FK_IstZugeordnet]
ON [dbo].[Toerns]
    ([SchiffId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------