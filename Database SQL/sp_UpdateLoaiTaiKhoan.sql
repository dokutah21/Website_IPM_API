create proc sp_UpdateLoaiTaiKhoan
@MaLoai INT,
@PhanQuyen NVARCHAR(50),
@TenChucDanh NVARCHAR(100)
as
Update LoaiTaiKhoan
set PhanQuyen = @PhanQuyen,
TenChucDanh = @TenChucDanh
where MaLoai = @MaLoai