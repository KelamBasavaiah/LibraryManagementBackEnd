CREATE TABLE [dbo].[Books] (
    [Id]            NVARCHAR (50)  NOT NULL,
    [BookName]      NVARCHAR (MAX) NULL,
    [AuthorName]    NVARCHAR (MAX) NULL,
    [Contact]       BIGINT         NULL,
    [Price]         MONEY          NULL,
    [PublishedDate] DATE           NULL,
    [Edition]       INT            NULL,
    [Genres]        NVARCHAR (50)  NULL,
    [Publisher]     NVARCHAR (MAX) NULL,
    [Copies]        INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



