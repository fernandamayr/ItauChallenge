USE [TechnicalKnowledgeDB]
GO

/****** Object:  Table [dbo].[Locacao]    Script Date: 16/08/2020 21:59:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Locacao](
	[id_locacao] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NULL,
	[id_filme] [int] NULL,
	[devolucao] [datetime] NULL,
	[estimativa_devolucao] [datetime] NULL,
	[data_locacao] [datetime] NULL,
	[observacao] [nchar](100) NULL,
 CONSTRAINT [PK_Locacao] PRIMARY KEY CLUSTERED 
(
	[id_locacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Locacao]  WITH CHECK ADD  CONSTRAINT [FK_Locacao_Clientes] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Clientes] ([id_cliente])
GO

ALTER TABLE [dbo].[Locacao] CHECK CONSTRAINT [FK_Locacao_Clientes]
GO

ALTER TABLE [dbo].[Locacao]  WITH CHECK ADD  CONSTRAINT [FK_Locacao_Filme] FOREIGN KEY([id_filme])
REFERENCES [dbo].[Filme] ([id_filme])
GO

ALTER TABLE [dbo].[Locacao] CHECK CONSTRAINT [FK_Locacao_Filme]
GO


