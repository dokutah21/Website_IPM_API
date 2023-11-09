create proc sp_DeleteHoaDon
@MaHoaDon INT
as
Delete from HoaDon
where MaHoaDon = @MaHoaDon