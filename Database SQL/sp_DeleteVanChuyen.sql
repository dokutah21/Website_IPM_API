create proc sp_DeleteVanChuyen
@MaVanChuyen INT
as
Delete from VanChuyen
where MaVanChuyen = @MaVanChuyen
GO


