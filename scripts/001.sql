IF Object_id('Produto', 'U') IS NOT NULL
BEGIN
	DROP TABLE Produto;
END

CREATE TABLE [Produto] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AggregateId] [uniqueidentifier] NOT NULL,
	[DataCriacao] DATETIME NOT NULL,
	[Codigo] int NOT NULL,
	[Nome]  varchar(50) NOT NULL,
	[Preco] decimal NOT NULL,
	[Quantidade] INT NOT NULL
	CONSTRAINT [PK_Produto] PRIMARY KEY ( [Id] ASC )
)
GO
