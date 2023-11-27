create proc sp_LoginAccount
 @us varchar(100),
 @pw varchar(100)
 As 
	Begin
		Select * From TaiKhoan
		Where TenTaiKhoan = @us and MatKhau = @pw
	End
Select * from TaiKhoan
alter table TaiKhoan add user_id int
Select * From KhachHang