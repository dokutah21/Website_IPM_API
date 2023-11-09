create proc sp_CreateLoaiTaiKhoan
@MaLoai INT,
@PhanQuyen NVARCHAR(50),
@TenChucDanh NVARCHAR(100)
as
insert into LoaiTaiKhoan(MaLoai, PhanQuyen, TenChucDanh)
values (@MaLoai, @PhanQuyen, @TenChucDanh)
GO


