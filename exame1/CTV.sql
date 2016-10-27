USE [Vendedor]
GO
/****** Object:  Table [dbo].[Vendedor]    Script Date: 26/10/2016 09:08:07 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendedor](
	[Clave] [varchar](50) NULL,
	[Vendeor] [varchar](50) NULL,
	[TotalVenta] [int] NULL,
	[SueldoBase] [int] NULL,
	[SueldoFinal] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
