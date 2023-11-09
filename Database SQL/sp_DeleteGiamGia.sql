create proc sp_DeleteGiamGia
@MaGiamGia INT
as
Delete from GiamGia
where MaGiamGia = @MaGiamGia
GO


