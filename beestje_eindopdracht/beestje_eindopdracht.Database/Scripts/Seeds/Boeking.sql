BEGIN
SET IDENTITY_INSERT [dbo].[Boeking] ON

INSERT INTO [dbo].[Boeking] ([Id], [datum], [contact_naam], [contact_adres], [contact_email], [contact_telefoonnummer]) VALUES (1, CAST(N'2008-11-11' AS Date), N'Jan', N'Straat', N'email@email.com', N'0612121212')
INSERT INTO [dbo].[Boeking] ([Id], [datum], [contact_naam], [contact_adres], [contact_email], [contact_telefoonnummer]) VALUES (2, CAST(N'2009-11-11' AS Date), N'Bob', N'Laan', N'mail@mail.com', N'0638383838')
SET IDENTITY_INSERT [dbo].[Boeking] OFF
END