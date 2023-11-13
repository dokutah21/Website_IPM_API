namespace DataModel
{
    public class HoaDonModel
    {
        public int MaHoaDon { get; set; }
        public int MaVanChuyen { get; set; }
        public int MaKhachHang { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayDuyet { get; set; }
        public string GhiChu { get; set; }
        public decimal TongTien { get; set; }
        public bool TrangThai { get; set; }

        public List<ChiTietHoaDonModel> list_json_ChiTietHoaDon { get; set; }
    }

    public class ChiTietHoaDonModel
    {
        public int MaChiTietHoaDon { get; set; }
        public int MaHoaDon { get; set; }
        public int MaSach { get; set; }
        public int MaGiamGia { get; set; }
        public int SoLuong { get; set; }
        public decimal TongGia { get; set; }
    }
}