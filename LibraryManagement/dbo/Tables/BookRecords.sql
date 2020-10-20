CREATE TABLE [dbo].[BookRecords] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [UserName]       NVARCHAR (50) NOT NULL,
    [BookId]         NVARCHAR (50) NOT NULL,
    [IssueDate]      DATETIME      NULL,
    [DueDate]        DATETIME      NULL,
    [NumberOfCopies] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]),
    FOREIGN KEY ([UserName]) REFERENCES [dbo].[user] ([userName])
);



