Create procedure AddBooks(
@Id nvarchar(50),
@BookName nvarchar(max),
@AuthorName nvarchar(max),
@Contact int,
@Price money,
@Copies int,
@Edition int,
@PublishedDate date,
@Publisher nvarchar(max),
@Genres nvarchar(50))
as 
begin
	Insert into Books (Id,BookName,AuthorName,Contact,Price,Copies,Edition,PublishedDate,Publisher,Genres)
		values (@Id,@BookName,@AuthorName,@Contact,@Price,@Copies,@Edition,@PublishedDate,@Publisher,@Genres)
end