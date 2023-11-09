create proc sp_CreateVanChuyen
@MaVanChuyen INT,
@TenKH NVARCHAR(100),
@SDT INT, 
@DiaChi NVARCHAR(350),
@PhuongThucVanChuyen NVARCHAR(200),
@PhuongThucThanhToan NVARCHAR(200)
as
insert into VanChuyen(MaVanChuyen, TenKH, SDT, DiaChi, PhuongThucVanChuyen, PhuongThucThanhToan)
values (@MaVanChuyen, @TenKH, @SDT, @DiaChi, @PhuongThucVanChuyen, @PhuongThucThanhToan)
GO


