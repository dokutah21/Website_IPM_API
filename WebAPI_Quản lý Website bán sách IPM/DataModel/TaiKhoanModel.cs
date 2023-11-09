
using System;

namespace DataModel
{
    public class TaiKhoanModel
    {
        public int MaTK { get; set; }

        public int MaLoai{ get; set; }

        public string TenTaiKhoan { get; set; }

        public string MatKhau { get; set; }

        public string Email { get; set; }

        public List<ChiTietTaiKhoanModel> list_json_ChiTietTaiKhoan { get; set; }
    }

    public class ChiTietTaiKhoanModel
    {
        public int MaChiTietTK { get; set; }
        public int MaTK { get; set; } 
	    public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public int SoDienThoai { get; set; }
        public string Avatar { get; set; }
    }
}
