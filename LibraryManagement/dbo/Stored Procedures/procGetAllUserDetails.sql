create  procedure  procGetAllUserDetails
as
begin
	select userId,userName,password,role,isActive,PhoneNo,MailId from libraryusers  
end