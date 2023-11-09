create proc sp_CreateSanPham
@MaSach int,
@TenSach NVARCHAR(100), 
@TacGia NVARCHAR(150), 
@TenNXB NVARCHAR(100),
@PhienBan NVARCHAR(100),
@AnhSach NVARCHAR(MAX),
@TrangThai BIT,
@Gia DECIMAL
as
insert into SanPham(MaSach, TenSach ,TacGia , TenNXB, PhienBan, AnhSach ,TrangThai ,Gia)
values (@MaSach, @TenSach ,@TacGia , @TenNXB, @PhienBan, @AnhSach ,@TrangThai ,@Gia)

