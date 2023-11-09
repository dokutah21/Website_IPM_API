create proc sp_CreateNhaXuatBan
@MaNXB INT,
@TenNXB NVARCHAR(100),
@DiaChi NVARCHAR(500),
@SoDienThoai INT
as
insert into NhaXuatBan(MaNXB, TenNXB, DiaChi, SoDienThoai)
values (@MaNXB, @TenNXB, @DiaChi, @SoDienThoai)