create proc sp_SearchTaiKhoan	  
(@page_index  INT, 
@page_size   INT,
@TenTaiKhoan NVARCHAR(50))
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
        IF(@page_size <> 0)
            BEGIN
                SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY TenTaiKHoan ASC)) AS RowNumber, 
							  tk.MaTK,
                              tk.MaLoai,
							  tk.TenTaiKhoan,
							  tk.MatKhau,
							  tk.Email
                        INTO #Results1
                        FROM TaiKhoan AS tk
					    WHERE (@TenTaiKhoan = '' or tk.TenTaiKhoan like N'%' + @TenTaiKhoan +'%');                   
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
                            ORDER BY TenTaiKHoan ASC)) AS RowNumber, 
							  tk.MaTK,
                              tk.MaLoai,
							  tk.TenTaiKhoan,
							  tk.MatKhau,
							  tk.Email
                        INTO #Results2
                        FROM TaiKhoan AS tk
					    WHERE (@TenTaiKhoan = '' or tk.TenTaiKhoan like N'%' + @TenTaiKhoan +'%');           
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2
                        DROP TABLE #Results2; 
        END;
    END;
go