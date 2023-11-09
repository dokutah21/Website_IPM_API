create proc sp_SearchGiamGia		  
(@page_index  INT, 
@page_size   INT,
@TenMaGiamGia NVARCHAR(10),
@SoTienGiam VARCHAR(50))
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
        IF(@page_size <> 0)
            BEGIN
                SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY TenMaGiamGia ASC)) AS RowNumber, 
                              gg.MaGiamGia, 
							  gg.TenMaGiamGia, 
							  gg.NoiDungMaGiamGia, 
							  gg.ThoiGianBatDau, 
							  gg.ThoiGianKetThuc,
							  gg.SoLuongMa, 
							  gg.SoTienGiam, 
							  gg.TrangThai
                        INTO #Results1
                        FROM GiamGia AS gg
					    WHERE (@TenMaGiamGia = '' or gg.TenMaGiamGia like N'%' + @TenMaGiamGia +'%') and
						(@SoTienGiam is null or gg.SoTienGiam like N'%' + @SoTienGiam +'%');                   
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results1;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results1
                        WHERE ROWNUMBER BETWEEN(@page_index - 1) * @page_size + 1 AND(((@page_index - 1) * @page_size + 1) + @page_size) - 1
                              OR @page_index = -1;
                        DROP TABLE #Results1; 
            END;
            ELSE
            BEGIN
                SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                             ORDER BY TenMaGiamGia ASC)) AS RowNumber, 
                              gg.MaGiamGia, 
							  gg.TenMaGiamGia, 
							  gg.NoiDungMaGiamGia, 
							  gg.ThoiGianBatDau, 
							  gg.ThoiGianKetThuc,
							  gg.SoLuongMa, 
							  gg.SoTienGiam, 
							  gg.TrangThai
                        INTO #Results2
                        FROM GiamGia AS gg
					    WHERE (@TenMaGiamGia = '' or gg.TenMaGiamGia like N'%' + @TenMaGiamGia +'%') and
						(@SoTienGiam is null or gg.SoTienGiam like N'%' + @SoTienGiam +'%');     
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2
                        DROP TABLE #Results2; 
        END;
    END;
go