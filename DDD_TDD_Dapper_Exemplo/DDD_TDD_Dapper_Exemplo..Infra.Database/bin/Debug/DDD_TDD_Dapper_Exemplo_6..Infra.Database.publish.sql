﻿/*
Deployment script for ddddappertest

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ddddappertest"
:setvar DefaultFilePrefix "ddddappertest"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
PRINT N'Rename refactoring operation with key f846caca-16d1-496c-a8c1-2746d873d3eb is skipped, element [dbo].[Cliente].[Id] (SqlSimpleColumn) will not be renamed to ClientId';


GO
PRINT N'Rename refactoring operation with key 29b0edec-6a8b-4861-9448-cbecf264003e is skipped, element [dbo].[Produto].[Id] (SqlSimpleColumn) will not be renamed to ProdutoId';


GO
PRINT N'Rename refactoring operation with key 053af895-e637-4c1e-a3c5-2dcb2fd6ef16 is skipped, element [dbo].[Cliente].[Id] (SqlSimpleColumn) will not be renamed to ClienteId';


GO
PRINT N'Rename refactoring operation with key 5037efa5-9966-4a33-87fc-9249c70f1260 is skipped, element [dbo].[Produto].[Id] (SqlSimpleColumn) will not be renamed to ProdutoId';


GO
PRINT N'Creating [dbo].[Cliente]...';


GO
CREATE TABLE [dbo].[Cliente] (
    [ClienteId]    INT            IDENTITY (1, 1) NOT NULL,
    [Nome]         NVARCHAR (150) NOT NULL,
    [Sobrenome]    NVARCHAR (100) NOT NULL,
    [Email]        NVARCHAR (200) NOT NULL,
    [DataCadastro] DATETIME       NOT NULL,
    [Ativo]        BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([ClienteId] ASC)
);


GO
PRINT N'Creating [dbo].[Produto]...';


GO
CREATE TABLE [dbo].[Produto] (
    [ProdutoId]  INT             IDENTITY (1, 1) NOT NULL,
    [ClienteId]  INT             NOT NULL,
    [Nome]       NVARCHAR (100)  NOT NULL,
    [Valor]      DECIMAL (18, 2) NOT NULL,
    [Disponivel] BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([ProdutoId] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Produto_Cliente]...';


GO
ALTER TABLE [dbo].[Produto] WITH NOCHECK
    ADD CONSTRAINT [FK_Produto_Cliente] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente] ([ClienteId]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'f846caca-16d1-496c-a8c1-2746d873d3eb')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('f846caca-16d1-496c-a8c1-2746d873d3eb')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '29b0edec-6a8b-4861-9448-cbecf264003e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('29b0edec-6a8b-4861-9448-cbecf264003e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '053af895-e637-4c1e-a3c5-2dcb2fd6ef16')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('053af895-e637-4c1e-a3c5-2dcb2fd6ef16')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '5037efa5-9966-4a33-87fc-9249c70f1260')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('5037efa5-9966-4a33-87fc-9249c70f1260')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Produto] WITH CHECK CHECK CONSTRAINT [FK_Produto_Cliente];


GO
PRINT N'Update complete.';


GO
