create proc sp_GetGiamGiaID
@MaGiamGia INT
as
begin
	select * from GiamGia
	where MaGiamGia = @MaGiamGia
end



