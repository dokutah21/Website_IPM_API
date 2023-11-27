CREATE PROCEDURE [dbo].[DeleteMultipleGiamGia]
    @MaGiamGia NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    SET @Sql = N'DELETE FROM GiamGia WHERE MaGiamGia IN (''' + REPLACE(@MaGiamGia, ',', ''',''') + ''')'

    EXEC sp_executesql @Sql
END;

