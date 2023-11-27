create proc sp_UpdateKhachHang
@MaKhachHang INT,
@TenKH NVARCHAR(100),
@GioiTinh NVARCHAR(20),
@DiaChi NVARCHAR(250),
@SDT INT,
@Email NVARCHAR(250)
as
Update KhachHang
set TenKH = @TenKH,
GioiTinh = @GioiTinh,
DiaChi = @DiaChi,
SDT = @SDT,
Email = @Email
where MaKhachHang = @MaKhachHang