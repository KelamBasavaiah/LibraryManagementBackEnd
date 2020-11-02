CREATE TABLE [dbo].[libraryusers] (
    [userId]   INT           IDENTITY (1, 1) NOT NULL,
    [userName] NVARCHAR (50) NOT NULL,
    [password] NVARCHAR (50) NOT NULL,
    [role]     NVARCHAR (10) NOT NULL,
    [isActive] BIT           NULL,
    [PhoneNo]  BIGINT        NULL,
    [MailId]   NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([userId] ASC),
    UNIQUE NONCLUSTERED ([userName] ASC)
);









