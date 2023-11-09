create proc sp_SearchLoaiTaiKhoan	  
(@page_index  INT, 
@page_size   INT,
@PhanQuyen NVARCHAR(50),
@TenChucDanh NVARCHAR(100))
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
        IF(@page_size <> 0)
            BEGIN
                SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY PhanQuyen ASC)) AS RowNumber, 
                              ltk.MaLoai,
							  ltk.PhanQuyen,
							  ltk.TenChucDanh
                        INTO #Results1
                        FROM LoaiTaiKhoan AS ltk
					    WHERE (@PhanQuyen = '' or ltk.PhanQuyen like N'%' + @PhanQuyen +'%') and
						(@TenChucDanh is null or ltk.TenChucDanh like N'%' + @TenChucDanh +'%');                   
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
                            ORDER BY PhanQuyen ASC)) AS RowNumber, 
                              ltk.MaLoai,
							  ltk.PhanQuyen,
							  ltk.TenChucDanh
                        INTO #Results2
                        FROM LoaiTaiKhoan AS ltk
					    WHERE (@PhanQuyen = '' or ltk.PhanQuyen like N'%' + @PhanQuyen +'%') and
						(@TenChucDanh is null or ltk.TenChucDanh like N'%' + @TenChucDanh +'%');       
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2
                        DROP TABLE #Results2; 
        END;
    END;
go