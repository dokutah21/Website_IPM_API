create proc sp_DeleteNhaXuatBan
@MaNXB INT
as
Delete from NhaXuatBan
where MaNXB = @MaNXB