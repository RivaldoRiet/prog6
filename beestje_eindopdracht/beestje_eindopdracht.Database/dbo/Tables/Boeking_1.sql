CREATE TABLE [dbo].[Boeking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[datum] [date] NOT NULL,
	[contact_naam] [nvarchar](max) NOT NULL,
	[contact_adres] [nvarchar](max) NOT NULL,
	[contact_email] [nvarchar](max) NOT NULL,
	[contact_telefoonnummer] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Boeking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]