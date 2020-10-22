CREATE PROC ProcUpdateUserDetails(@Id int,@username nvarchar(50),@password nvarchar(50),@role int = 2,@isActive bit = 1
			,@phoneno bigint,@mailid nvarchar(50))
AS
BEGIN
	UPDATE libraryusers SET userName = @username,password = @password,role = @role,isActive = @isActive WHERE userID = @Id
	UPDATE UserDetails SET PhoneNo = @phoneno,MailId =@mailid WHERE UserId = @Id
END