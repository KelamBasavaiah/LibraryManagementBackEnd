CREATE PROCEDURE ProcAddBookRecords(@UserId int,@BookId StringList readonly)
as 

BEGIN
	BEGIN TRY 
		BEGIN TRAN
		INSERT INTO userBooks(userId,BookId,IssueDate,DueDate,NumberOfCopies) 
		SELECT @userId,b.value,SYSDATETIME ( ),DATEADD(day, 15, SYSDATETIME ( )),1 FROM @BookId b left join userBooks u ON u.BookId in(b.value)
		UPDATE Books SET Copies = b.Copies - 1 FROM Books b WHERE b.Id in (SELECT value FROM @BookId)
		COMMIT TRAN
	END TRY
	BEGIN CATCH 
		ROLLBACK TRAN
	END CATCH
END