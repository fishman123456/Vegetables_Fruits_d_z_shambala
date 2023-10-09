USE [Vegetables_Fruits]
GO

/****** Object:  Table [dbo].[Veg_Fru_t]    Script Date: 10.10.2023 0:05:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Veg_Fru_t](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name_f] [nvarchar](30) NOT NULL,
	[Type_f] [nvarchar](30) NOT NULL,
	[Color_f] [nvarchar](20) NOT NULL,
	[Ñalories_f] [int] NOT NULL
) ON [PRIMARY]
GO


