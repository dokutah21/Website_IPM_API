USE [WebsiteIPM]
GO

/****** Object:  StoredProcedure [dbo].[sp_SearchSanPham]    Script Date: 11/29/2023 9:55:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_SearchSanPham]
(@page_index  INT, 
@page_size   INT,
@TenSach NVARCHAR(200), 
@TacGia NVARCHAR(250)
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
GO


Create Proc  Pro_GetProductWebCustomer
	@page_index int,
	@page_size int
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
					
						--and (@MaSach is null or sp.MaSach = @MaSach)                                 
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2;                        
                        DROP TABLE #Results1; 
        END;
    END;