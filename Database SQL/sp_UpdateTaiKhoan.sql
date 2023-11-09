create proc sp_UpdateTaiKhoan
@MaTK INT,
@MaLoai INT,
@TenTaiKhoan NVARCHAR(50),
@MatKhau NVARCHAR(50),
@Email NVARCHAR(100)
as
Update TaiKhoan
set MaLoai = @MaLoai,
TenTaiKhoan = @TenTaiKhoan,
MatKhau = @MatKhau,
Email = @Email
where MaTK = @MaTK