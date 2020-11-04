
CREATE PROCEDURE UpdatePassword(@userId int,@password nvarchar(50))
AS
BEGIN
	update libraryusers SET password = @password where userId = @userId
END