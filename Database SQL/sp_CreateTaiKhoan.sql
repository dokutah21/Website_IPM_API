create proc sp_CreateTaiKhoan
@MaTK INT,
@MaLoai INT,
@TenTaiKhoan NVARCHAR(50),
@MatKhau NVARCHAR(50),
@Email NVARCHAR(100)
as
insert into TaiKhoan(MaTK, MaLoai, TenTaiKhoan, MatKhau, Email)
values (@MaTK, @MaLoai, @TenTaiKhoan, @MatKhau, @Email)
GO


