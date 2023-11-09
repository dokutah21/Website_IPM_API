create proc sp_CreateKhachHang
@MaKhachHang INT,
@TenKH NVARCHAR(100),
@GioiTinh BIT,
@DiaChi NVARCHAR(250),
@SDT INT,
@Email NVARCHAR(250)
as
insert into KhachHang(MaKhachHang,TenKH,GioiTinh,DiaChi, SDT, Email)
values (@MaKhachHang,@TenKH,@GioiTinh,@DiaChi, @SDT, @Email)
GO


