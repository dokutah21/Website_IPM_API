CREATE PROCEDURE [dbo].[DeleteMultipleKhachHang]
    @MaKhachHang NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    -- T?o c�u l?nh SQL ?? x�a s?n ph?m v� chi ti?t s?n ph?m li�n quan
    SET @Sql = N'DELETE FROM KhachHang WHERE MaKhachHang IN (''' + REPLACE(@MaKhachHang, ',', ''',''') + ''')'

    -- Th?c hi?n c�u l?nh SQL
    EXEC sp_executesql @Sql
END;
GO

alter PROCEDURE [dbo].[DeleteMultipleKhachHang]
    @MaKhachHang NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    -- T?o c�u l?nh SQL ?? x�a s?n ph?m v� chi ti?t s?n ph?m li�n quan
    SET @Sql = N'DELETE FROM KhachHang WHERE MaKhachHang IN (''' + REPLACE(@MaKhachHang, ',', ''',''') + ''')'

    -- Th?c hi?n c�u l?nh SQL
    EXEC sp_executesql @Sql
END;
GO

