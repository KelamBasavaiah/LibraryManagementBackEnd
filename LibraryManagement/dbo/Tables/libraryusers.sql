CREATE TABLE [dbo].[libraryusers] (
    [userId]   INT           IDENTITY (1, 1) NOT NULL,
    [userName] NVARCHAR (50) NOT NULL,
    [password] NVARCHAR (50) NOT NULL,
    [role]     INT           NOT NULL,
    [isActive] BIT           NULL,
    PRIMARY KEY CLUSTERED ([userId] ASC),
    FOREIGN KEY ([role]) REFERENCES [dbo].[Libraryroles] ([Id])
);



