CREATE PROC ProcInsertUserDetails(@username nvarchar(50),@password nvarchar(50),@role int = 2,@isActive bit = 1
			,@phoneno bigint,@mailid nvarchar(50))
AS
Declare @userID int
BEGIN
	INSERT INTO libraryusers values(@username,@password,@role,@isActive)
	SET @userID =SCOPE_IDENTITY()
	INSERT INTO UserDetails values(@userID,@phoneno,@mailid)
END