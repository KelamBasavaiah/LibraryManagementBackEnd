CREATE PROC ProcGetUserDetails(@Id int)
AS
BEGIN
	SELECT userId,userName,password,role,isActive,PhoneNo,MailId FROM libraryusers where userId =@Id
END