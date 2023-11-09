
create proc sp_GetSanPhamID
@MaSach INT
as
begin
	select * from SanPham
	where MaSach = @MaSach
end
GO


