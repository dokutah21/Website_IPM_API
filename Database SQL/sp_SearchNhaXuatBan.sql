create PROCEDURE sp_SearchNhaXuatBan
(@page_index  INT, 
@page_size   INT, 
@TenNXB NVARCHAR(100)
)
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
        IF(@page_size <> 0)
            BEGIN
						SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY TenNXB ASC)) AS RowNumber, 
							  nxb.MaNXB, 
							  nxb.TenNXB,
							  nxb.DiaChi,
							  nxb.SoDienThoai
                        INTO #Results1
                        FROM NhaXuatBan AS nxb
					    WHERE  (@TenNXB = '' Or nxb.TenNXB like N'%'+@TenNXB+'%');            
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
                              ORDER BY TenNXB ASC)) AS RowNumber, 
							  nxb.MaNXB, 
							  nxb.TenNXB,
							  nxb.DiaChi,
							  nxb.SoDienThoai
                        INTO #Results2
                        FROM NhaXuatBan AS nxb
					    WHERE  (@TenNXB = '' Or nxb.TenNXB like N'%'+@TenNXB+'%');                          
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2;                        
                        DROP TABLE #Results1; 
        END;
    END;