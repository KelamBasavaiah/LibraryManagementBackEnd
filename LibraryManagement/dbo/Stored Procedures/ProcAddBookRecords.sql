CREATE PROCEDURE ProcAddBookRecords(@UserName nvarchar(50),@BookId nvarchar(50),@IssueDate datetime,@DueDate datetime,@NumberOfCopies int)
as 
DECLARE @Copies int
		SET @Copies = (select Copies from Books where Id = @BookId)
BEGIN
	Insert into BookRecords values (@UserName,@BookId,@IssueDate,@DueDate,@NumberOfCopies)

	Update Books set Copies = @Copies - @NumberOfCopies where Id = @BookId
END