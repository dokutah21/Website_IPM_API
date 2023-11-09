create proc sp_GetVanChuyenID
@MaVanChuyen INT
as
begin
	select * from VanChuyen
	where MaVanChuyen = @MaVanChuyen
end



