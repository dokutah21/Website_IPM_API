create proc sp_UpdateNhaXuatBan
@MaNXB INT,
@TenNXB NVARCHAR(100),
@DiaChi NVARCHAR(500),
@SoDienThoai INT
as
Update NhaXuatBan
set TenNXB = @TenNXB,
DiaChi = @DiaChi,
SoDienThoai = @SoDienThoai
where MaNXB = @MaNXB