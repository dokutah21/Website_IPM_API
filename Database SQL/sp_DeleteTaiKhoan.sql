create proc sp_DeleteTaiKhoan
@MaTK INT
as
Delete from TaiKhoan
where MaTK = @MaTK
GO


