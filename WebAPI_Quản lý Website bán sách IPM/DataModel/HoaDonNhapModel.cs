namespace DataModel
{
    public class HoaDonNhapModel
    {
        public int MaHoaDonNhap { get; set; }
        public int MaNXB { get; set; }
        public DateTime NgayNhap { get; set; }
        public string KieuThanhToan { get; set; }
        public bool TrangThai { get; set; }
        public List<ChiTietHoaDonNhapModel> list_json_ChiTietHoaDonNhap { get; set; }
    }

    public class ChiTietHoaDonNhapModel
    {
        public int MaChiTietHoaDonNhap { get; set; }
        public int MaHoaDonNhap { get; set; }
        public int MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal TongTien { get; set; }
    }
}