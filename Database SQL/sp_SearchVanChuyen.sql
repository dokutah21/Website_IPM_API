create proc sp_SearchVanChuyen		  
(@page_index  INT, 
@page_size   INT,
@TenKH NVARCHAR(100),
@DiaChi NVARCHAR(350))
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
        IF(@page_size <> 0)
            BEGIN
                SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY TenKH ASC)) AS RowNumber, 
                              vc.MaVanChuyen,
							  vc.TenKH, 
							  vc.SDT, 
							  vc.DiaChi, 
							  vc.PhuongThucVanChuyen, 
							  vc.PhuongThucThanhToan
                        INTO #Results1
                        FROM VanChuyen AS vc
					    WHERE (@TenKH = '' or vc.TenKH like N'%' + @TenKH +'%') and
						(@DiaChi is null or vc.DiaChi like N'%' + @DiaChi +'%');                   
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
                              ORDER BY TenKH ASC)) AS RowNumber, 
                              vc.MaVanChuyen,
							  vc.TenKH, 
							  vc.SDT, 
							  vc.DiaChi, 
							  vc.PhuongThucVanChuyen, 
							  vc.PhuongThucThanhToan
                        INTO #Results2
                        FROM VanChuyen AS vc
					    WHERE (@TenKH = '' or vc.TenKH like N'%' + @TenKH +'%') and
						(@DiaChi is null or vc.DiaChi like N'%' + @DiaChi +'%');       
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2
                        DROP TABLE #Results2; 
        END;
    END;
go