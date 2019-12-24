CREATE TABLE [dbo].[Accessoires](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naam] [nvarchar](max) NOT NULL,
	[Prijs] [money] NOT NULL,
	[Afbeelding] [nvarchar](max) NOT NULL,
	[Beestje_id] [int] NOT NULL,
 CONSTRAINT [PK_Accessoires] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accessoires]  WITH CHECK ADD  CONSTRAINT [FK_Accessoires_Beestjes] FOREIGN KEY([Beestje_id])
REFERENCES [dbo].[Beestjes] ([Id])
GO

ALTER TABLE [dbo].[Accessoires] CHECK CONSTRAINT [FK_Accessoires_Beestjes]