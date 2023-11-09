create proc sp_GetHoaDonID 
(@MaHoaDon        int)
AS
    BEGIN
        SELECT hd.*, 
        (
            SELECT cthd.*
            FROM ChiTietHoaDon AS cthd
            WHERE hd.MaHoaDon = cthd.MaHoaDon FOR JSON PATH
        ) AS list_json_ChiTietHoaDon
        FROM HoaDon AS hd
        WHERE  hd.MaHoaDon = @MaHoaDon;
    END;