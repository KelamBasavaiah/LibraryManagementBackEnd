CREATE PROCEDURE GetBook(@Id nvarchar(50))
as
BEGIN
	SELECT Id,BookName,AuthorName,Price,Contact,Edition,PublishedDate,Publisher,Copies,Genres FROM Books where Id = @Id
END