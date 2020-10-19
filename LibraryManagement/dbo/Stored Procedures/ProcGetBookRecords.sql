CREATE PROCEDURE ProcGetBookRecords(@UserName nvarchar(50))
AS
BEGIN
	SELECT UserName,BookId,IssueDate,DueDate,NumberOfCopies FROM [dbo].BookRecords WHERE UserName = @UserName
END