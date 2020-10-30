CREATE PROC ProcInsertUserDetails(@Id int = NULL,@username nvarchar(50),@password nvarchar(50),@role nvarchar(10),@isActive bit = 1
			,@phoneno bigint,@mailid nvarchar(50))
AS
BEGIN
    IF(@Id IS NULL)
	BEGIN
		INSERT INTO libraryusers values(@username,@password,@role,@isActive,@phoneno,@mailid)
	END
	ELSE
	BEGIN
		UPDATE libraryusers SET userName = @username,password = @password,role = @role,isActive = @isActive,PhoneNo = @phoneno,MailId =@mailid WHERE userID = @Id
	END
END