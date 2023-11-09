create PROCEDURE sp_SearchSanPham
(@page_index  INT, 
@page_size   INT,
@TenSach NVARCHAR(100), 
@TacGia NVARCHAR(150)
)
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
        IF(@page_size <> 0)
            BEGIN
						SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY TenSach ASC)) AS RowNumber, 
							  sp.MaSach, 
							  sp.TenSach,
							  sp.TacGia , 
							  sp.TenNXB, 
							  sp.PhienBan, 
							  sp.AnhSach,
							  sp.TrangThai,
							  sp.Gia
                        INTO #Results1
                        FROM SanPham AS sp
					    WHERE  (@TenSach = '' Or sp.TenSach like N'%'+@TenSach+'%') and						
						(@TacGia = '' Or sp.TacGia like N'%'+@TacGia+'%');
						--and (@MaSach is null or sp.MaSach like N'%' + @MaSach +'%')              
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
                              ORDER BY TenSach ASC)) AS RowNumber, 
                              sp.MaSach, 
							  sp.TenSach,
							  sp.TacGia , 
							  sp.TenNXB, 
							  sp.PhienBan, 
							  sp.AnhSach,
							  sp.TrangThai,
							  sp.Gia
                        INTO #Results2
                        FROM SanPham AS sp
					    WHERE  (@TenSach = '' Or sp.TenSach like N'%'+@TenSach+'%') and						
						(@TacGia = '' Or sp.TacGia like N'%'+@TacGia+'%');
						--and (@MaSach is null or sp.MaSach = @MaSach)                                 
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2;                        
                        DROP TABLE #Results1; 
        END;
    END;