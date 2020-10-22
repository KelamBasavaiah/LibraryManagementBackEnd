CREATE PROCEDURE ProcGetBookRecords(@UserId int)
AS
BEGIN
	SELECT ub.Id,ub.userId,ub.BookId,ub.DueDate,b.BookName FROM [dbo].userBooks ub join Books b on b.Id = ub.BookId  WHERE ub.userId = @UserId
END