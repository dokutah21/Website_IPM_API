CREATE PROCEDURE [dbo].[DeleteMultipleTaiKhoan]
    @MaTK NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    SET @Sql = N'DELETE FROM TaiKhoan WHERE MaTK IN (''' + REPLACE(@MaTK, ',', ''',''') + ''')'

    EXEC sp_executesql @Sql
END;
