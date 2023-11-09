create proc sp_GetHoaDonNhapID 
(@MaHoaDonNhap        int)
AS
    BEGIN
        SELECT hdn.*, 
        (
            SELECT cthdn.*
            FROM ChiTietHoaDonNhap AS cthdn
            WHERE hdn.MaHoaDonNhap = cthdn.MaHoaDonNhap FOR JSON PATH
        ) AS list_json_ChiTietHoaDonNhap
        FROM HoaDonNhap AS hdn
        WHERE  hdn.MaHoaDonNhap = @MaHoaDonNhap;
    END;