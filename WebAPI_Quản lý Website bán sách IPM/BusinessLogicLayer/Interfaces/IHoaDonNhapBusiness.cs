using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IHoaDonNhapBusiness
    {
        HoaDonNhapModel GetDatabyID(string id);

        bool Create(HoaDonNhapModel model);

        bool Update(HoaDonNhapModel model);

        bool Delete(int id);

        public List<ThongKeSanPhamModel> Search(int pageIndex, int pageSize, out long total, string TenSach, DateTime? fr_NgayNhap, DateTime? to_NgayNhap);
    }
}
