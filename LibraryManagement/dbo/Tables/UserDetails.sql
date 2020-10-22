CREATE TABLE [dbo].[UserDetails] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [UserId]  INT           NOT NULL,
    [PhoneNo] BIGINT        NULL,
    [MailId]  NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[libraryusers] ([userId])
);

