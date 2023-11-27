CREATE PROCEDURE [dbo].[DeleteMultipleLTK]
    @MaLoai NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    -- Tạo câu lệnh SQL để xóa sản phẩm và chi tiết sản phẩm liên quan
    SET @Sql = N'DELETE FROM LoaiTaiKhoan WHERE MaLoai IN (''' + REPLACE(@MaLoai, ',', ''',''') + ''')'

    -- Thực hiện câu lệnh SQL
    EXEC sp_executesql @Sql
END;
GO

alter PROCEDURE [dbo].[DeleteMultipleTK]
    @MaLoai NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    -- Tạo câu lệnh SQL để xóa sản phẩm và chi tiết sản phẩm liên quan
    SET @Sql = N'DELETE FROM LoaiTaiKhoan WHERE MaLoai IN (' + @MaLoai + N')'

    -- Thực hiện câu lệnh SQL
    EXEC sp_executesql @Sql
END;
GO


