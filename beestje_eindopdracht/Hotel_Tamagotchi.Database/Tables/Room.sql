CREATE TABLE [dbo].[Rooms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoomType_id] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [AmountOfBed] int  NOT NULL,
    [ImageUrl] nvarchar(max)  NOT NULL
);