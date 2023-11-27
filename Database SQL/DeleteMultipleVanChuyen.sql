CREATE PROCEDURE [dbo].[DeleteMultipleVanChuyen]
    @MaVanChuyen NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Sql NVARCHAR(MAX)

    SET @Sql = N'DELETE FROM VanChuyen WHERE MaVanChuyen IN (''' + REPLACE(@MaVanChuyen, ',', ''',''') + ''')'

    EXEC sp_executesql @Sql
END;
