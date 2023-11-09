create proc sp_GetTaiKhoanID
@MaTK INT
as
begin
	select * from TaiKhoan
	where MaTK = @MaTK
end



