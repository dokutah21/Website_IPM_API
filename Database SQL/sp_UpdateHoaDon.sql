create proc sp_UpdateHoaDon
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
		UPDATE HoaDon
		SET
            MaVanChuyen = @MaVanChuyen, 
            MaKhachHang = @MaKhachHang,
			TenKH = @TenKH,
			DiaChi = @DiaChi,
			NgayTao = @NgayTao,
		    NgayDuyet = @NgayDuyet,
			GhiChu = @GhiChu,
			TrangThai = @TrangThai
		WHERE MaHoaDon = @MaHoaDon;
		
		IF(@list_json_ChiTietHoaDon IS NOT NULL) 
		BEGIN
			 -- Insert data to temp table 
		   SELECT
			   JSON_VALUE(cthd.value, '$.maChiTietHoaDon') as maChiTietHoaDon,
			   JSON_VALUE(cthd.value, '$.maHoaDon') as maHoaDon,
			   JSON_VALUE(cthd.value, '$.maSach') as maSach, 
			   JSON_VALUE(cthd.value, '$.maGiamGia') as maGiamGia, 
			   JSON_VALUE(cthd.value, '$.soLuong') as soLuong,
			   JSON_VALUE(cthd.value, '$.tongGia') as tongGia
			  INTO #Results 
		   FROM OPENJSON(@list_json_ChiTietHoaDon) AS cthd;
		   UPDATE ChiTietHoaDon
			  SET
				 MaChiTietHoaDon = #Results.maChiTietHoaDon,
				 MaHoaDon = #Results.maHoaDon,
				 MaSach = #Results.maSach,
				 MaGiamGia = #Results.maGiamGia,
				 SoLuong = #Results.soLuong,
				 TongGia = #Results.tongGia
			  FROM #Results 
			  WHERE  ChiTietHoaDon.MaChiTietHoaDon = #Results.maChiTietHoaDon
		END;
     SELECT '';
END;
GO


