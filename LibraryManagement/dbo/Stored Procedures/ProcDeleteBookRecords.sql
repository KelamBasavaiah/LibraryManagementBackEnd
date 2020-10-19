CREATE PROCEDURE ProcDeleteBookRecords(@UserName nvarchar(50),@BookId nvarchar(50),@IssueDate datetime,@DueDate datetime,@NumberOfCopies int)
as 
Declare @Copies int 
		SET @Copies = (select Copies from Books where Id = @BookId)
begin
	Delete from BookRecords where UserName = @UserName and BookId = @BookId and IssueDate = @IssueDate and DueDate = @DueDate

	Update Books set Copies = @Copies + @NumberOfCopies where Id = @BookId
end