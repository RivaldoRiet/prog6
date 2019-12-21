CREATE TABLE [dbo].[Beestjes](
	[Id] [int] NOT NULL,
	[Boeking_id] [int] NULL,
	[BeestType_id] [int] NOT NULL,
	[Naam] [nvarchar](max) NOT NULL,
	[Prijs] [nvarchar](max) NOT NULL,
	[Afbeelding] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Beestjes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Beestjes]  WITH CHECK ADD  CONSTRAINT [Beestjes_ID] FOREIGN KEY([BeestType_id])
REFERENCES [dbo].[BeestType] ([id])
GO

ALTER TABLE [dbo].[Beestjes] CHECK CONSTRAINT [Beestjes_ID]
GO
ALTER TABLE [dbo].[Beestjes]  WITH CHECK ADD  CONSTRAINT [FK_Beestjes_Boeking] FOREIGN KEY([Boeking_id])
REFERENCES [dbo].[Boeking] ([Id])
GO

ALTER TABLE [dbo].[Beestjes] CHECK CONSTRAINT [FK_Beestjes_Boeking]