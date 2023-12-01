CREATE PROCEDURE [dbo].[DeleteMultipleHoaDon]
    @MaHoaDon NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    SET @Sql = N'DELETE FROM HoaDon WHERE HoaDon IN (''' + REPLACE(@MaHoaDon, ',', ''',''') + ''')'

    EXEC sp_executesql @Sql
END;

