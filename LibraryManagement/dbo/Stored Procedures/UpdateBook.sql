CREATE procedure UpdateBook(
@Id nvarchar(50),
@BookName nvarchar(max),
@AuthorName nvarchar(max),
@Contact bigint,
@Price money,
@Copies int,
@Edition int,
@PublishedDate date,
@Publisher nvarchar(max),
@Genres nvarchar(50))
as 
begin
	Update Books set BookName = @BookName,
	AuthorName = @AuthorName,
	Contact = @Contact,
	Price = @Price,
	Copies = @Copies,
	Edition = @Edition,
	PublishedDate = @PublishedDate,
	Publisher = @Publisher,
	Genres = @Genres where Id = @Id 
		
end