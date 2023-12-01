create proc sp_DeleteHoaDon
@MaHoaDon INT
as
Delete from HoaDon
where MaHoaDon = @MaHoaDon


alter PROCEDURE sp_DeleteHoaDon
    @MaHoaDon INT
AS
BEGIN
    
    IF NOT EXISTS (SELECT * FROM [HoaDon] WHERE MaHoaDon = @MaHoaDon)
    BEGIN
        RETURN -1;
    END
    DELETE FROM [ChiTietHoaDon] WHERE MaHoaDon = @MaHoaDon;

    DELETE FROM [HoaDon] WHERE MaHoaDon = @MaHoaDon;
    RETURN 0;
END;