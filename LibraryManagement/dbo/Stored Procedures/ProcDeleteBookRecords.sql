CREATE PROCEDURE ProcDeleteBookRecords(@Id int)
as 
Declare @BookId nvarchar(50),
		@Copies int
		SET @BookId = (select BookId from userBooks where Id = @Id)
begin
	Delete from userBooks where Id = @Id
	SET @Copies = (select Copies from Books where Id = @BookId)

	Update Books set Copies = @Copies + 1 where Id = @BookId
end