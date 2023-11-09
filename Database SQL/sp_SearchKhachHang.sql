create proc sp_SearchKhachHang		  
(@page_index  INT, 
@page_size   INT,
@DiaChi NVARCHAR(250),
@TenKH NVARCHAR(100))
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
        IF(@page_size <> 0)
            BEGIN
                SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY TenKH ASC)) AS RowNumber, 
                              kh.MaKhachHang,
							  kh.TenKH,
							  kh.GioiTinh,
							  kh.DiaChi, 
							  kh.SDT, 
							  kh.Email
                        INTO #Results1
                        FROM KhachHang AS kh
					    WHERE (@TenKH = '' or kh.TenKH like N'%' + @TenKH +'%') and
						(@DiaChi is null or kh.DiaChi like N'%' + @DiaChi +'%');                   
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
                              kh.MaKhachHang,
							  kh.TenKH,
							  kh.GioiTinh,
							  kh.DiaChi, 
							  kh.SDT, 
							  kh.Email
                        INTO #Results2
                        FROM KhachHang AS kh
					    WHERE (@TenKH = '' or kh.TenKH like N'%' + @TenKH +'%') and
						(@DiaChi is null or kh.DiaChi like N'%' + @DiaChi +'%');  
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2
                        DROP TABLE #Results2; 
        END;
    END;
go