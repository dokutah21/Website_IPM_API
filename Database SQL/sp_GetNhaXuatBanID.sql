create proc sp_GetNhaXuatBanID
@MaNXB INT
as
begin
	select * from NhaXuatBan
	where MaNXB = @MaNXB
end