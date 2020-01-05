BEGIN
SET IDENTITY_INSERT [dbo].[Accessoires] ON
INSERT INTO [dbo].[Accessoires] ([Id], [Naam], [Prijs], [Afbeelding], [Beestje_id]) VALUES (1, N'Ketting', 50.0000, N'Content/Images/Accessoires/ketting.png', 1)
INSERT INTO [dbo].[Accessoires] ([Id], [Naam], [Prijs], [Afbeelding], [Beestje_id]) VALUES (2, N'Armband', 30.0000, N'Content/Images/Accessoires/bracelet.png', 2)
INSERT INTO [dbo].[Accessoires] ([Id], [Naam], [Prijs], [Afbeelding], [Beestje_id]) VALUES (3, N'Oorbellen', 70.0000, N'Content/Images/Accessoires/earrings.png', 3)
SET IDENTITY_INSERT [dbo].[Accessoires] OFF
END