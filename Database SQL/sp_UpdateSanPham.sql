create proc sp_UpdateSanPham
@MaSach int,
@TenSach NVARCHAR(100), 
@TacGia NVARCHAR(150), 
@TenNXB NVARCHAR(100),
@PhienBan NVARCHAR(100),
@AnhSach NVARCHAR(MAX),
@TrangThai BIT,
@Gia DECIMAL
as
Update SanPham
set TenSach = @TenSach,
TacGia = @TacGia,
TenNXB = @TenNXB,
PhienBan = @PhienBan,
AnhSach = @AnhSach,
TrangThai = @TrangThai,
Gia = @Gia
where MaSach = @MaSach