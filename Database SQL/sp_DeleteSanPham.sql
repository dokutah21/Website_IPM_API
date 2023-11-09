create proc sp_DeleteSanPham
@MaSach INT
as
Delete from SanPham
where MaSach = @MaSach
GO


