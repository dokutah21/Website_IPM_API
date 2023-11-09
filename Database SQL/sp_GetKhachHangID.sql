create proc sp_GetKhachHangID
@MaKhachHang INT
as
begin
	select * from KhachHang
	where MaKhachHang = @MaKhachHang
end



