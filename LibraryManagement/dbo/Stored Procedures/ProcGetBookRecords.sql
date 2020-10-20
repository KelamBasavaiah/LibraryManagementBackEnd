CREATE PROCEDURE ProcGetBookRecords(@UserName nvarchar(50))
AS
BEGIN
	SELECT Id,UserName,BookId,DueDate FROM [dbo].BookRecords WHERE UserName = @UserName
END