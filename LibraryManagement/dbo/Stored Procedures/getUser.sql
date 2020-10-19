CREATE PROC getUser(@username nvarchar(50))
as 
select userName,password from [dbo].[user] u where u.userName=@username