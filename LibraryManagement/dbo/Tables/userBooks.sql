CREATE TABLE [dbo].[userBooks] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [userId]         INT           NOT NULL,
    [BookId]         NVARCHAR (50) NOT NULL,
    [IssueDate]      DATETIME      NULL,
    [DueDate]        DATETIME      NULL,
    [NumberOfCopies] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]),
    FOREIGN KEY ([userId]) REFERENCES [dbo].[libraryusers] ([userId])
);

