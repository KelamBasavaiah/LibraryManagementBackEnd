
CREATE PROCEDURE CheckingOldPassword(@userId int,@oldPassword nvarchar(50))
AS
DECLARE @password nvarchar(50) 
	set @password = (SELECT password from libraryusers where userId = @userId)
BEGIN
	IF(@password = @oldPassword)
	begin
		select 'true'
	end
	else
		select 'false'
end