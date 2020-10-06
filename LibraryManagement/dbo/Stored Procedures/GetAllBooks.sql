CREATE PROCEDURE GetAllBooks
as
BEGIN
	SELECT Id,BookName,AuthorName,Price,Contact,Edition,PublishedDate,Publisher,Copies,Genres FROM Books
END