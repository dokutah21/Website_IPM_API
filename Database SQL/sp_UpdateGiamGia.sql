create proc sp_UpdateGiamGia
@MaGiamGia INT,
@TenMaGiamGia NVARCHAR(10),
@NoiDungMaGiamGia NVARCHAR(MAX),
@ThoiGianBatDau DATETIME,
@ThoiGianKetThuc DATETIME,
@SoLuongMa INT,
@SoTienGiam VARCHAR(50),
@TrangThai NVARCHAR(50)
as
Update GiamGia
set TenMaGiamGia = @TenMaGiamGia,
NoiDungMaGiamGia = @NoiDungMaGiamGia,
ThoiGianBatDau = @ThoiGianBatDau,
ThoiGianKetThuc = @ThoiGianKetThuc,
SoLuongMa = @SoLuongMa,
SoTienGiam = @SoTienGiam,
TrangThai = @TrangThai
where MaGiamGia = @MaGiamGia