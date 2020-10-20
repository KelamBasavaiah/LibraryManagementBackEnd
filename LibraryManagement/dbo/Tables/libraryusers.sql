CREATE TABLE [dbo].[libraryusers] (
    [userId]   INT           NOT NULL,
    [userName] NVARCHAR (50) NOT NULL,
    [password] NVARCHAR (50) NOT NULL,
    [role]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([userId] ASC)
);

