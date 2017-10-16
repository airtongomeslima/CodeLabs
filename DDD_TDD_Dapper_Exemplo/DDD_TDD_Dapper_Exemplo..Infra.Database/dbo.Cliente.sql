CREATE TABLE [dbo].[Cliente]
(
	[ClienteId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] NVARCHAR(150) NOT NULL, 
    [Sobrenome] NVARCHAR(100) NOT NULL, 
    [Email] NVARCHAR(200) NOT NULL, 
    [DataCadastro] DATETIME NOT NULL, 
    [Ativo] BIT NOT NULL 
)
