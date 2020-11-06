CREATE PROC ProcInsertUserDetails(@Id int = NULL,@username nvarchar(50) = NULL,@password nvarchar(50),@role nvarchar(10) = NULL,@isActive bit = 1
			,@phoneno bigint = NULL,@mailid nvarchar(50) = NULL,@newPassword nvarchar(50) = NULL)
AS	
BEGIN
    IF(@Id IS NULL)
	BEGIN
		INSERT INTO libraryusers values(@username,@password,@role,@isActive,@phoneno,@mailid)
	END
	ELSE
	BEGIN
		Declare @dbpassword nvarchar(50)
		SET @dbpassword = (select password from libraryusers where userID = @Id)
		IF(@dbpassword = @password)
		BEGIN
			IF(@newPassword IS NULL)
			BEGIN
				UPDATE libraryusers SET userName = @username,password = @password,role = @role,isActive = @isActive,PhoneNo = @phoneno,MailId =@mailid WHERE userID = @Id
			END
			ELSE
				UPDATE libraryusers SET password = @newPassword where userID = @Id
		END	
	END
END