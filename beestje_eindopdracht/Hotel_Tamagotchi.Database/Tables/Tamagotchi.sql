CREATE TABLE [dbo].[Tamagotchis] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Room_id] int  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Age] int  NOT NULL,
    [ImageUrl] nvarchar(max)  NOT NULL,
    [Money] int  NOT NULL,
    [Level] int  NOT NULL,
    [Health] int  NOT NULL,
    [Boredom] int  NOT NULL,
    [Live] bit  NOT NULL
);