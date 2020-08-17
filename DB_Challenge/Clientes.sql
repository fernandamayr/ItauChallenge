USE [TechnicalKnowledgeDB]
GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 16/08/2020 21:58:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nome_cliente] [nchar](100) NULL,
	[data_nascimento] [datetime] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


