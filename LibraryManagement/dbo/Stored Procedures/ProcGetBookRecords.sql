CREATE PROCEDURE ProcGetBookRecords(@UserName nvarchar(50))
AS
BEGIN
	SELECT UserName,BookId,DueDate FROM [dbo].BookRecords WHERE UserName = @UserName
END