USE [TechnicalKnowledgeDB]
GO

/****** Object:  Table [dbo].[Filme]    Script Date: 16/08/2020 21:59:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Filme](
	[id_filme] [int] IDENTITY(1,1) NOT NULL,
	[nome_filme] [nchar](100) NULL,
	[produtora] [nchar](50) NULL,
	[indicacao] [int] NULL,
 CONSTRAINT [PK_Filme] PRIMARY KEY CLUSTERED 
(
	[id_filme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


