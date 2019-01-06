USE [EMPRESAS]
GO

/****** Object:  Table [dbo].[FAC_XMLFACTURAS_TIMBRES]    Script Date: 10/04/2015 12:09:24 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FAC_XMLFACTURAS_TIMBRES](
	[nFactura] [varchar](14) NOT NULL,
	[nRFCEmisor] [int] NOT NULL,
	[cRFCEmpleado] [varchar](18) NOT NULL,
	[ccve_temporada] [varchar](5) NOT NULL,
	[ccve_nomina] [varchar](2) NOT NULL,
	[ccve_semana] [varchar](2) NOT NULL,
	[ccve_empl] [varchar](5) NOT NULL,
	[dfecha] [datetime] NOT NULL,
	[nImporte] [numeric](14, 2) NOT NULL,
	[cContenidoXML] [varchar](max) NOT NULL,
 CONSTRAINT [PK_FAC_XMLFACTURAS_TIMBRES] PRIMARY KEY CLUSTERED 
(
	[nFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


