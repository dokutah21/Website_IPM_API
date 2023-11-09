create proc sp_CreateHoaDonNhap
(
@MaHoaDonNhap INT,
@MaNXB INT,
@NgayNhap DATETIME,
@KieuThanhToan NVARCHAR(100),
@TrangThai BIT,
@list_json_ChiTietHoaDonNhap NVARCHAR(MAX)
)
AS
    BEGIN
        INSERT INTO HoaDonNhap
                (MaHoaDonNhap, 
                 MaNXB, 
                 NgayNhap,
				 KieuThanhToan,
				 TrangThai
                )
                VALUES
                (@MaHoaDonNhap, 
                 @MaNXB, 
                 @NgayNhap,
				 @KieuThanhToan,
				 @TrangThai
                );

				SET @MaHoaDonNhap = (SELECT SCOPE_IDENTITY());
                IF(@list_json_ChiTietHoaDonNhap IS NOT NULL)
                    BEGIN
                        INSERT INTO ChiTietHoaDonNhap
						 (MaChiTietHoaDonNhap,
						  MaHoaDonNhap,
						  MaSach,
						  SoLuong,
						  DonViTinh,
						  TongTien
                        )
                    SELECT  JSON_VALUE(cthdn.value, '$.maChiTietHoaDonNhap'),
							@MaHoaDonNhap, 
                            JSON_VALUE(cthdn.value, '$.maSach'), 
							JSON_VALUE(cthdn.value, '$.soLuong'), 
                            JSON_VALUE(cthdn.value, '$.donViTinh'),
							JSON_VALUE(cthdn.value, '$.tongTien')
                    FROM OPENJSON(@list_json_ChiTietHoaDonNhap) AS cthdn;
                END;
        SELECT '';
    END;