create proc sp_CreateHoaDon
(
@MaHoaDon INT,
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
        INSERT INTO HoaDon
                (MaHoaDon, 
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
                (@MaHoaDon, 
                 @MaVanChuyen, 
                 @MaKhachHang,
				 @TenKH,
				 @DiaChi,
				 @NgayTao,
				 @NgayDuyet,
				 @GhiChu,
				 @TrangThai
                );

				SET @MaHoaDon = (SELECT SCOPE_IDENTITY());
                IF(@list_json_ChiTietHoaDon IS NOT NULL)
                    BEGIN
                        INSERT INTO ChiTietHoaDon
						 (MaChiTietHoaDon,
						  MaHoaDon,
						  MaSach,
						  MaGiamGia,
						  SoLuong,
						  TongGia
                        )
                    SELECT  JSON_VALUE(cthd.value, '$.maChiTietHoaDon'),
							@MaHoaDon, 
                            JSON_VALUE(cthd.value, '$.maSach'), 
							JSON_VALUE(cthd.value, '$.maGiamGia'), 
                            JSON_VALUE(cthd.value, '$.soLuong'),
							JSON_VALUE(cthd.value, '$.tongGia')
                    FROM OPENJSON(@list_json_ChiTietHoaDon) AS cthd;
                END;
        SELECT '';
    END;