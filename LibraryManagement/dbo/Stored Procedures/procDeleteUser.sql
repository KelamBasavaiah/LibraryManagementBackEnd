create procedure procDeleteUser(@userId int)
as 
begin
	update libraryusers set isActive=0 where userId=@userId
end