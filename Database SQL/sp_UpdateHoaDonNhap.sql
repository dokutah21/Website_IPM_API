create proc sp_UpdateHoaDonNhap
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
		UPDATE HoaDonNhap
		SET
				 MaNXB = @MaNXB, 
                 NgayNhap = @NgayNhap,
				 KieuThanhToan = @KieuThanhToan,
				 TrangThai = @TrangThai
		WHERE MaHoaDonNhap = @MaHoaDonNhap;
		
		IF(@list_json_ChiTietHoaDonNhap IS NOT NULL) 
		BEGIN
			 -- Insert data to temp table 
		   SELECT
			  JSON_VALUE(cthdn.value, '$.maChiTietHoaDonNhap') as maChiTietHoaDonNhap,
			  JSON_VALUE(cthdn.value, '$.maHoaDonNhap') as maHoaDonNhap,
              JSON_VALUE(cthdn.value, '$.maSach') as maSach, 
			  JSON_VALUE(cthdn.value, '$.soLuong') as soLuong, 
              JSON_VALUE(cthdn.value, '$.donViTinh') as donViTinh,
			  JSON_VALUE(cthdn.value, '$.tongTien') as tongTien
			  INTO #Results 
		   FROM OPENJSON(@list_json_ChiTietHoaDonNhap) AS cthdn;
		   UPDATE ChiTietHoaDonNhap
			  SET
				 MaChiTietHoaDonNhap = #Results.maChiTietHoaDonNhap,
				 MaHoaDonNhap = #Results.maHoaDonNhap, 
				 MaSach = #Results.maSach,
				 SoLuong = #Results.soLuong,
				 DonViTinh = #Results.donViTinh,
			     TongTien = #Results.tongTien
			  FROM #Results 
			  WHERE  ChiTietHoaDonNhap.MaChiTietHoaDonNhap = #Results.maChiTietHoaDonNhap
		END;
     SELECT '';
END;
GO


