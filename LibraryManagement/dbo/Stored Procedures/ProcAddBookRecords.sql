CREATE PROCEDURE ProcAddBookRecords(@UserId int,@BookId StringList readonly)
as 

BEGIN
	Insert into userBooks values (@UserId,(select value from @BookId),SYSDATETIME ( ),DATEADD(day, 15, SYSDATETIME ( )),1) 
	Update Books set Copies = b.Copies - 1 from Books b where b.Id in (select value from @BookId)
END