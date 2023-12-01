create proc sp_GetChiTietHoaDonID 
(@MaHoaDon        int)
AS
    BEGIN
        SELECT cthd.*, 
        (
            SELECT hd.*
            FROM HoaDon AS hd
            WHERE cthd.MaHoaDon = hd.MaHoaDon FOR JSON PATH
        ) AS list_json_ChiTietHoaDon
        FROM ChiTietHoaDon AS cthd
        WHERE  cthd.MaHoaDon = @MaHoaDon;
    END;