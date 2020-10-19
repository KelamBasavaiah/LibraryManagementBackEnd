CREATE TABLE [dbo].[LibraryUser] (
    [userName] NVARCHAR (50) NOT NULL,
    [password] NVARCHAR (50) NOT NULL,
    [role]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([userName] ASC)
);

