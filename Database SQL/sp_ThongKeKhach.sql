create proc sp_ThongKeKhach
(@page_index  INT, 
@page_size   INT,
@TenKH NVARCHAR(100),
@fr_NgayTao datetime, 
@to_NgayTao datetime
)
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
        IF(@page_size <> 0)
            BEGIN
						SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY hd.NgayTao ASC)) AS RowNumber, 
                              sp.MaSach,
							  sp.TenSach,
							  cthd.SoLuong,
							  cthd.TongGia,
							  hd.NgayTao,
							  hd.TenKH
                        INTO #Results1
                        FROM HoaDon  hd
						inner join ChiTietHoaDon cthd on cthd.MaHoaDon = hd.MaHoaDon
						inner join SanPham sp on sp.MaSach = cthd.MaSach
					    WHERE  (@TenKH = '' Or hd.TenKH like N'%'+@TenKH+'%') and						
						((@fr_NgayTao IS NULL
                        AND @to_NgayTao IS NULL)
                        OR (@fr_NgayTao IS NOT NULL
                            AND @to_NgayTao IS NULL
                            AND hd.NgayTao >= @fr_NgayTao)
                        OR (@fr_NgayTao IS NULL
                            AND @to_NgayTao IS NOT NULL
                            AND hd.NgayTao <= @to_NgayTao)
                        OR (hd.NgayTao BETWEEN @fr_NgayTao AND @to_NgayTao))              
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
                               ORDER BY hd.NgayTao ASC)) AS RowNumber, 
                              sp.MaSach,
							  sp.TenSach,
							  cthd.SoLuong,
							  cthd.TongGia,
							  hd.NgayTao,
							  hd.TenKH
                        INTO #Results2
                        FROM HoaDon  hd
						inner join ChiTietHoaDon cthd on cthd.MaHoaDon = hd.MaHoaDon
						inner join SanPham sp on sp.MaSach = cthd.MaSach
					    WHERE  (@TenKH = '' Or hd.TenKH like N'%'+@TenKH+'%') and						
						((@fr_NgayTao IS NULL
                        AND @to_NgayTao IS NULL)
                        OR (@fr_NgayTao IS NOT NULL
                            AND @to_NgayTao IS NULL
                            AND hd.NgayTao >= @fr_NgayTao)
                        OR (@fr_NgayTao IS NULL
                            AND @to_NgayTao IS NOT NULL
                            AND hd.NgayTao <= @to_NgayTao)
                        OR (hd.NgayTao BETWEEN @fr_NgayTao AND @to_NgayTao))             
			SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2                        
                        DROP TABLE #Results2; 
        END;
    END;