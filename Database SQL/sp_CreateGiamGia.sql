create proc sp_CreateGiamGia
@MaGiamGia INT,
@TenMaGiamGia NVARCHAR(10),
@NoiDungMaGiamGia NVARCHAR(MAX),
@ThoiGianBatDau DATETIME,
@ThoiGianKetThuc DATETIME,
@SoLuongMa INT,
@SoTienGiam VARCHAR(50),
@TrangThai NVARCHAR(50)
as
insert into GiamGia(MaGiamGia, TenMaGiamGia, NoiDungMaGiamGia, ThoiGianBatDau, ThoiGianKetThuc,SoLuongMa, SoTienGiam, TrangThai)
values (@MaGiamGia, @TenMaGiamGia, @NoiDungMaGiamGia, @ThoiGianBatDau, @ThoiGianKetThuc,@SoLuongMa, @SoTienGiam, @TrangThai)
GO


