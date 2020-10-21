CREATE PROCEDURE ProcAddBookRecords(@UserId int,@BookId nvarchar(50))
as 
DECLARE @Copies int
		SET @Copies = (select Copies from Books where Id = @BookId)
BEGIN
	Insert into userBooks values (@UserId,@BookId,SYSDATETIME ( ),DATEADD(day, 15, SYSDATETIME ( )),1)

	Update Books set Copies = @Copies - 1 where Id = @BookId
END