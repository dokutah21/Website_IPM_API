CREATE PROCEDURE [dbo].[DeleteMultipleKhachHang]
    @MaKhachHang NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    -- T?o câu l?nh SQL ?? xóa s?n ph?m và chi ti?t s?n ph?m liên quan
    SET @Sql = N'DELETE FROM KhachHang WHERE MaKhachHang IN (''' + REPLACE(@MaKhachHang, ',', ''',''') + ''')'

    -- Th?c hi?n câu l?nh SQL
    EXEC sp_executesql @Sql
END;
GO

alter PROCEDURE [dbo].[DeleteMultipleKhachHang]
    @MaKhachHang NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    -- T?o câu l?nh SQL ?? xóa s?n ph?m và chi ti?t s?n ph?m liên quan
    SET @Sql = N'DELETE FROM KhachHang WHERE MaKhachHang IN (''' + REPLACE(@MaKhachHang, ',', ''',''') + ''')'

    -- Th?c hi?n câu l?nh SQL
    EXEC sp_executesql @Sql
END;
GO

