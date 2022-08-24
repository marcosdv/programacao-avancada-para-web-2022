/****** Object:  Table [dbo].[TbOperadora]    Script Date: 02/08/2022 21:58:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TbOperadora](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
 CONSTRAINT [PK_TbOperadora] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[TbPessoa]    Script Date: 02/08/2022 22:01:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TbPessoa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](150) NULL,
 CONSTRAINT [PK_TbPessoa] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[TbTelefone]    Script Date: 02/08/2022 22:08:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TbTelefone](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero] [varchar](15) NOT NULL,
	[operadoraId] [int] NULL,
	[pessoaId] [int] NULL,
 CONSTRAINT [PK_TbTelefone] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TbTelefone]  WITH CHECK ADD  CONSTRAINT [FK_TbTelefone_TbOperadora] FOREIGN KEY([operadoraId])
REFERENCES [dbo].[TbOperadora] ([id])
GO

ALTER TABLE [dbo].[TbTelefone] CHECK CONSTRAINT [FK_TbTelefone_TbOperadora]
GO

ALTER TABLE [dbo].[TbTelefone]  WITH CHECK ADD  CONSTRAINT [FK_TbTelefone_TbPessoa] FOREIGN KEY([pessoaId])
REFERENCES [dbo].[TbPessoa] ([id])
GO

ALTER TABLE [dbo].[TbTelefone] CHECK CONSTRAINT [FK_TbTelefone_TbPessoa]
GO