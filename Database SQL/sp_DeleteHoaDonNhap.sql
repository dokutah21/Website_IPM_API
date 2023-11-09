create proc sp_DeleteHoaDonNhap
@MaHoaDonNhap INT
as
Delete from HoaDonNhap
where MaHoaDonNhap = @MaHoaDonNhap