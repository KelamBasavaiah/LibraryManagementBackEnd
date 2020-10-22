CREATE PROC getUser(@username nvarchar(50))
AS
SELECT userId,password,role FROM [dbo].libraryusers u WHERE u.userName=@username and u.isActive=1