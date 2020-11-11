CREATE PROCEDURE ProcDeleteBookRecords(@Ids Intlist readonly)
as 
begin
declare @temp table (BookId nvarchar(50))
insert into @temp
select BookId from userBooks where Id in(select value from @Ids)
Delete from userBooks where Id in(select value from @Ids)
Update Books set Copies = b.Copies + 1 from Books b join @temp t on b.Id=t.BookId
end