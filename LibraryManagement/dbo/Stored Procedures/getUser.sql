CREATE PROC getUser(@username nvarchar(50))
AS
SELECT userId,password,role,userName FROM [dbo].libraryusers u WHERE u.userName=@username