create proc sp_UpdateVanChuyen
@MaVanChuyen INT,
@TenKH NVARCHAR(100),
@SDT INT, 
@DiaChi NVARCHAR(350),
@PhuongThucVanChuyen NVARCHAR(200),
@PhuongThucThanhToan NVARCHAR(200)
as
Update VanChuyen
set TenKH = @TenKH,
SDT = @SDT,
DiaChi = @DiaChi,
PhuongThucVanChuyen = @PhuongThucVanChuyen,
PhuongThucThanhToan = @PhuongThucThanhToan
where MaVanChuyen = @MaVanChuyen