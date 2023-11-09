create proc sp_DeleteLoaiTaiKhoan
@MaLoai INT
as
Delete from LoaiTaiKhoan
where MaLoai = @MaLoai
GO


