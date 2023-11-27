CREATE PROCEDURE [dbo].[DeleteMultipleSanPham]
    @MaSach NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    -- Tạo câu lệnh SQL để xóa sản phẩm và chi tiết sản phẩm liên quan
    SET @Sql = N'DELETE FROM SanPham WHERE MaSach IN (''' + REPLACE(@MaSach, ',', ''',''') + ''')'

    -- Thực hiện câu lệnh SQL
    EXEC sp_executesql @Sql
END;
GO

alter PROCEDURE [dbo].[DeleteMultipleSanPham]
    @MaSach NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    -- Tạo câu lệnh SQL để xóa sản phẩm và chi tiết sản phẩm liên quan
    SET @Sql = N'DELETE FROM SanPham WHERE MaSach IN (' + @MaSach + N')'

    -- Thực hiện câu lệnh SQL
    EXEC sp_executesql @Sql
END;
GO


