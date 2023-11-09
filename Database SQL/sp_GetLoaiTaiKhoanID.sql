create proc sp_GetLoaiTaiKhoanID
@MaLoai INT
as
begin
	select * from LoaiTaiKhoan
	where MaLoai = @MaLoai
end



