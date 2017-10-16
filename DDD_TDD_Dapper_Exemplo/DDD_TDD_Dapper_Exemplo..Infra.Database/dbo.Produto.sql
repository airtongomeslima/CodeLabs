CREATE TABLE [dbo].[Produto]
(
	[ProdutoId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClienteId] INT NOT NULL, 
    [Nome] NVARCHAR(100) NOT NULL, 
    [Valor] DECIMAL(18, 2) NOT NULL, 
    [Disponivel] BIT NOT NULL, 
    CONSTRAINT [FK_Produto_Cliente] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente]([ClienteId])
)
