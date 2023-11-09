create proc sp_DeleteKhachHang
@MaKhachHang INT
as
Delete from KhachHang
where MaKhachHang = @MaKhachHang
GO


