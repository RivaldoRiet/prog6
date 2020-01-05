BEGIN
SET IDENTITY_INSERT [dbo].[BeestType] ON
INSERT INTO [dbo].[BeestType] ([id], [Type]) VALUES (1, N'Jungle')
INSERT INTO [dbo].[BeestType] ([id], [Type]) VALUES (2, N'Boerderij')
INSERT INTO [dbo].[BeestType] ([id], [Type]) VALUES (3, N'Sneeuw')
INSERT INTO [dbo].[BeestType] ([id], [Type]) VALUES (4, N'Woestijn')
SET IDENTITY_INSERT [dbo].[BeestType] OFF
END