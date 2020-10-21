CREATE PROCEDURE ProcGetBookRecords(@UserId int)
AS
BEGIN
	SELECT Id,userId,BookId,DueDate FROM [dbo].userBooks WHERE userId = @UserId
END