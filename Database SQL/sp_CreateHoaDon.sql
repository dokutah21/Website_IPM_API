select * From HoaDon
select * from ChiTietHoaDon
alter proc sp_CreateHoaDon
(

@MaVanChuyen INT,
@MaKhachHang INT, 
@TenKH NVARCHAR(100),
@DiaChi NVARCHAR(MAX),
@NgayTao DATETIME,
@NgayDuyet DATETIME,
@GhiChu NVARCHAR(MAX),
@TrangThai BIT,
@list_json_ChiTietHoaDon NVARCHAR(MAX)
)
AS
    BEGIN
	declare @mahd int;
        INSERT INTO HoaDon
                ( 
                 MaVanChuyen, 
                 MaKhachHang,
				 TenKH,
				 DiaChi,
				 NgayTao,
				 NgayDuyet,
				 GhiChu,
				 TrangThai
                )
                VALUES
                ( 
                 @MaVanChuyen, 
                 @MaKhachHang,
				 @TenKH,
				 @DiaChi,
				 @NgayTao,
				 @NgayDuyet,
				 @GhiChu,
				 @TrangThai
                );

				SET @mahd = (SELECT SCOPE_IDENTITY());
                IF(@list_json_ChiTietHoaDon IS NOT NULL)
                    BEGIN
                        INSERT INTO ChiTietHoaDon
						 (
						  MaHoaDon,
						  MaSach,
						  MaGiamGia,
						  SoLuong,
						  TongGia
                        )
                    SELECT  
							@mahd, 
                            JSON_VALUE(cthd.value, '$.maSach'), 
							JSON_VALUE(cthd.value, '$.maGiamGia'), 
                            JSON_VALUE(cthd.value, '$.soLuong'),
							JSON_VALUE(cthd.value, '$.tongGia')
                    FROM OPENJSON(@list_json_ChiTietHoaDon) AS cthd;
                END;
        SELECT '';
    END;