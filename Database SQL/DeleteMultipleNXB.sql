CREATE PROCEDURE [dbo].[DeleteMultipleNXB]
    @MaNXB NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    -- T?o c�u l?nh SQL ?? x�a s?n ph?m v� chi ti?t s?n ph?m li�n quan
    SET @Sql = N'DELETE FROM NhaXuatBan WHERE MaNXB IN (''' + REPLACE(@MaNXB, ',', ''',''') + ''')'

    -- Th?c hi?n c�u l?nh SQL
    EXEC sp_executesql @Sql
END;
GO

alter PROCEDURE [dbo].[DeleteMultipleNXB]
    @MaNXB NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    -- T?o c�u l?nh SQL ?? x�a s?n ph?m v� chi ti?t s?n ph?m li�n quan
    SET @Sql = N'DELETE FROM NhaXuatBan WHERE MaNXB IN (''' + REPLACE(@MaNXB, ',', ''',''') + ''')'

    -- Th?c hi?n c�u l?nh SQL
    EXEC sp_executesql @Sql
END;
GO