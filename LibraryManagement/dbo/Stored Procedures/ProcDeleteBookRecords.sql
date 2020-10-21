CREATE PROCEDURE ProcDeleteBookRecords(@UserId int,@BookId nvarchar(50),@DueDate datetime)
as 
Declare @Copies int 
		SET @Copies = (select Copies from Books where Id = @BookId)
begin
	Delete from userBooks where userId = @UserId and BookId = @BookId and DueDate = @DueDate

	Update Books set Copies = @Copies + 1 where Id = @BookId
end