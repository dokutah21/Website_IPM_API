ALTER Proc Pro_GetOrderByUsId
	@userId int
As
	Begin
		  SELECT hd.*, 
        (
            SELECT cthd.*
            FROM ChiTietHoaDon AS cthd
            WHERE hd.MaHoaDon = cthd.MaHoaDon FOR JSON PATH
        ) AS list_json_ChiTietHoaDon
        FROM HoaDon AS hd
		Where MaKhachHang = @userId
	End
Alter table TaiKhoan
Add maKh int foreign key references KhachHang (MaKhachHang)
select * from KhachHang
Create Proc Pro_GetOrderDetailByOrderId
	@orderId int
As
	Begin
		Select *  From ChiTietHoaDon
		Where MaHoaDon = @orderId
	End
Exec Pro_GetOrderDetailByOrderId 1
Select * From HoaDon


USE [WebsiteIPM]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetHoaDonID]    Script Date: 11/28/2023 10:43:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_GetHoaDonID] 
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
GO



USE [WebsiteIPM]
GO

/****** Object:  StoredProcedure [dbo].[sp_LoginAccount]    Script Date: 11/28/2023 11:00:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_LoginAccount]
 @us varchar(100),
 @pw varchar(100)
 As 
	Begin
		Select * From TaiKhoan
		Where TenTaiKhoan = @us and MatKhau = @pw
	End
GO

