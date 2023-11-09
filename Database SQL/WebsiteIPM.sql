CREATE DATABASE WebsiteIPM

USE WebsiteIPM
GO

CREATE TABLE SanPham
(
	MaSach INT PRIMARY KEY NOT NULL, 
	TenSach NVARCHAR(100), 
	TacGia NVARCHAR(150), 
	TenNXB NVARCHAR(100),
	PhienBan NVARCHAR(100),
	AnhSach NVARCHAR(MAX),
    TrangThai BIT,
	Gia DECIMAL,
)

CREATE TABLE NhaXuatBan
(
	MaNXB INT PRIMARY KEY NOT NULL,
	TenNXB NVARCHAR(100),
	DiaChi NVARCHAR(500),
	SoDienThoai INT,
)

CREATE TABLE LoaiTaiKhoan
(
	MaLoai INT PRIMARY KEY NOT NULL,
	PhanQuyen NVARCHAR(50),
	TenChucDanh NVARCHAR(100)
)


CREATE TABLE TaiKhoan
(
	MaTK INT PRIMARY KEY NOT NULL,
	MaLoai INT,
	TenTaiKhoan NVARCHAR(50),
	MatKhau NVARCHAR(50),
	Email NVARCHAR(100)
	FOREIGN KEY (MaLoai) REFERENCES LoaiTaiKhoan(MaLoai)
)

CREATE TABLE ChiTietTaiKhoan
(
	MaChiTietTK INT PRIMARY KEY NOT NULL,
	MaTK INT, 
	HoTen NVARCHAR(200),
	DiaChi NVARCHAR(MAX), 
	SoDienThoai INT,
	Avatar NVARCHAR(MAX),
	FOREIGN KEY (MaTK) REFERENCES TaiKhoan(MaTK)
)


CREATE TABLE KhachHang
(
	MaKhachHang INT PRIMARY KEY NOT NULL,
	TenKH NVARCHAR(100),
	GioiTinh BIT,
	DiaChi NVARCHAR(250),
	SDT INT,
	Email NVARCHAR(250)
)


CREATE TABLE HoaDon
(
	MaHoaDon INT PRIMARY KEY NOT NULL,
	MaVanChuyen INT,
	MaKhachHang INT, 
	TenKH NVARCHAR(100),
	DiaChi NVARCHAR(MAX),
	NgayTao DATETIME,
	NgayDuyet DATETIME,
	GhiChu NVARCHAR(MAX),
	TrangThai BIT,
	FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
	FOREIGN KEY (MaVanChuyen) REFERENCES VanChuyen(MaVanChuyen)
)

CREATE TABLE ChiTietHoaDon
(
	MaChiTietHoaDon INT PRIMARY KEY NOT NULL,
	MaHoaDon INT,
	MaSach INT,
	MaGiamGia INT,
	SoLuong INT,
	TongGia DECIMAL,
	FOREIGN KEY (MaSach) REFERENCES SanPham(MaSach),
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
	FOREIGN KEY (MaGiamGia) REFERENCES GiamGia(MaGiamGia),
) 

CREATE TABLE HoaDonNhap
(
	MaHoaDonNhap INT PRIMARY KEY NOT NULL,
	MaNXB INT,
	NgayNhap DATETIME,
	KieuThanhToan NVARCHAR(100),
	TrangThai BIT
	FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB)
)

CREATE TABLE ChiTietHoaDonNhap
(
	MaChiTietHoaDonNhap INT PRIMARY KEY NOT NULL,
	MaHoaDonNhap INT,
	MaSach INT,
	SoLuong INT,
	DonViTinh NVARCHAR(50),
	TongTien DECIMAL,
	FOREIGN KEY (MaHoaDonNhap) REFERENCES HoaDonNhap(MaHoaDonNhap),
	FOREIGN KEY (MaSach) REFERENCES SanPham(MaSach)
)


CREATE TABLE VanChuyen
(
	MaVanChuyen INT PRIMARY KEY NOT NULL,
	TenKH NVARCHAR(100),
	SDT INT, 
	DiaChi NVARCHAR(350),
	PhuongThucVanChuyen NVARCHAR(200),
	PhuongThucThanhToan NVARCHAR(200),
)


CREATE TABLE GiamGia
(
	MaGiamGia INT PRIMARY KEY NOT NULL,
	TenMaGiamGia NVARCHAR(10),
	NoiDungMaGiamGia NVARCHAR(MAX),
	ThoiGianBatDau DATETIME,
	ThoiGianKetThuc DATETIME,
	SoLuongMa INT,
	SoTienGiam VARCHAR(50),
	TrangThai BIT
)

/****** Mặt hàng bảng SanPham ******/

SELECT*FROM SanPham

SELECT*FROM ChiTietSanPham

INSERT INTO SanPham(MaSach, TenSach ,TacGia , TenNXB, PhienBan, AnhSach ,TrangThai ,Gia) VALUES (1, N'Cô gái nơi xứ ngoài 1', N'NAGABE',N'Hồng Đức', N'Đặc biệt',N'https://product.hstatic.net/200000287623/product/co-gai-noi-xu-ngoai-1-banthuong__1__62ddca1969ae4609b1ecd8ec7095c218_master.jpg', 1, 59000)
INSERT INTO SanPham(MaSach, TenSach ,TacGia , TenNXB, PhienBan, AnhSach ,TrangThai ,Gia) VALUES (2, N'Đóa hoa của hy vọng', N'Hana Hope', N'SELF', N'Thường', N'#', 0, 199000)
INSERT INTO SanPham(MaSach, TenSach ,TacGia , TenNXB, PhienBan, AnhSach ,TrangThai ,Gia) VALUES (3, N'Lỗi code: Ác mộng của Coder', N'Elon Muske', N'SELF', N'Thường', N'#', 0, 299000)
INSERT INTO SanPham(MaSach, TenSach ,TacGia , TenNXB, PhienBan, AnhSach ,TrangThai ,Gia) VALUES (4, N'The Divine Comedia', N'TRAGEAN', N'SELF', N'Siêu đặc biệt',N'#', 1, 899000)
INSERT INTO SanPham(MaSach, TenSach ,TacGia , TenNXB, PhienBan, AnhSach ,TrangThai ,Gia) VALUES (5, N'Và Tình Yêu Thuở Ngàn Năm', N'Christina Aurorea', N'SELF', N'Đặc biệt', N'#', 1, 299000)
INSERT INTO SanPham(MaSach, TenSach ,TacGia , TenNXB, PhienBan, AnhSach ,TrangThai ,Gia) VALUES (6, N'Spy X Family 5', N'Tetsuya Endo', N'Kim Đồng', N'Thường',N'https://product.hstatic.net/200000287623/product/co-gai-noi-xu-ngoai-2-banthuong_1feb602961634793bc131b7843ca325e_master.jpg', 0, 25000)
INSERT INTO SanPham(MaSach, TenSach ,TacGia , TenNXB, PhienBan, AnhSach ,TrangThai ,Gia) VALUES (7, N'Yuzu Camp 1', N'ALFO', N'Kim Đồng', N'Thường', N'https://cdn0.fahasa.com/media/catalog/product/v/o/vol1_card.png', 0, 30000)
INSERT INTO SanPham(MaSach, TenSach ,TacGia , TenNXB, PhienBan, AnhSach ,TrangThai ,Gia) VALUES (8, N'Nhà Giả Kim', N'Paulo Coelho', N'Trẻ', N'Thường', N'https://salt.tikicdn.com/cache/w1200/ts/product/83/30/87/737846efdb9f28f0f51352cacf9225c5.jpg', 0, 199000)
INSERT INTO SanPham(MaSach, TenSach ,TacGia , TenNXB, PhienBan, AnhSach ,TrangThai ,Gia) VALUES (9, N'Fantastic Beast and Where To Find Them', N'J.K.Rowling', N'Trẻ', N'Siêu đặc biệt',N'https://upload.wikimedia.org/wikipedia/vi/0/05/Fantastic_Beasts_And_Where_To_Find_Them.jpeg', 1, 999000)
INSERT INTO SanPham(MaSach, TenSach ,TacGia , TenNXB, PhienBan, AnhSach ,TrangThai ,Gia) VALUES (10, N'Hoàng hôn nơi mắt người', N'FAELA', N'SELF', N'Đặc biệt',N'#' , 1, 499000)

DELETE FROM SanPham WHERE MaSach = 9;

DELETE FROM ChiTietSanPham WHERE MaChiTietSP = 2;


/****** Mặt hàng bảng NXB ******/

INSERT INTO NhaXuatBan(MaNXB, TenNXB ,DiaChi ,SoDienThoai) VALUES (1, N'SELF', N'Lê Lợi - Hưng Yên - Hưng Yên', 0913377629)
INSERT INTO NhaXuatBan(MaNXB, TenNXB ,DiaChi ,SoDienThoai) VALUES (2, N'Kim Đồng', N'Quang Trung - Hai Bà Trưng - Hà Nội', 1900571595)
INSERT INTO NhaXuatBan(MaNXB, TenNXB ,DiaChi ,SoDienThoai) VALUES (3, N'Hồng Đức', N'Nguyễn Cửu Vân - Bình Thạnh - Hồ Chí Minh', 0971998312)
INSERT INTO NhaXuatBan(MaNXB, TenNXB ,DiaChi ,SoDienThoai) VALUES (4, N'Trẻ', N'Lý Chính Thắng - Quận 3 - Hồ Chí Minh', 0939316289)

SELECT*FROM NhaXuatBan

DELETE FROM NhaXuatBan WHERE MaNXB = 3;


/****** Mặt hàng bảng KhachHang ******/

INSERT INTO KhachHang(MaKhachHang,TenKH,GioiTinh,DiaChi, SDT, Email) VALUES (1, N'Nguyễn Huyền', 1, N'Hưng Yên', 0913377629, 'nguyenhuyen21903@gmail.com')
INSERT INTO KhachHang(MaKhachHang,TenKH,GioiTinh,DiaChi, SDT, Email) VALUES (2, N'Du Nhiên', 1, N'Hà Nội', 0941667862, 'feyrelfey@gmail.com')

SELECT*FROM KhachHang

create trigger Delete_NXB on NhaXuatBan
instead of delete
   as
	   begin
	   if(exists (select TenNXB from  NhaXuatBan where TenNXB in (select TenNXB from NhaXuatBan)))
	   BEGIN
	   PRINT N'Nhà xuất bản còn mặt hàng. Không thể xóa.'
	   rollback tran
   end
	   else
	   begin
	   print N'Đã xóa'
	   delete from NhaXuatBan where TenNXB in (select TenNXB from NhaXuatBan)
	end
end