CREATE PROCEDURE [dbo].[DeleteMultipleNXB]
    @MaNXB NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    -- T?o câu l?nh SQL ?? xóa s?n ph?m và chi ti?t s?n ph?m liên quan
    SET @Sql = N'DELETE FROM NhaXuatBan WHERE MaNXB IN (''' + REPLACE(@MaNXB, ',', ''',''') + ''')'

    -- Th?c hi?n câu l?nh SQL
    EXEC sp_executesql @Sql
END;
GO

alter PROCEDURE [dbo].[DeleteMultipleNXB]
    @MaNXB NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    -- T?o câu l?nh SQL ?? xóa s?n ph?m và chi ti?t s?n ph?m liên quan
    SET @Sql = N'DELETE FROM NhaXuatBan WHERE MaNXB IN (''' + REPLACE(@MaNXB, ',', ''',''') + ''')'

    -- Th?c hi?n câu l?nh SQL
    EXEC sp_executesql @Sql
END;
GO