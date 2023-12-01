using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IHoaDonBusiness
    {
        List<HoaDonModel> getAll_HoaDon();
        HoaDonModel GetDatabyID(string id);

        ChiTietHoaDonModel GetDatabyIDHD(string id);

        List<HoaDonModel> GetOrderByUsId(string id);

        HoaDonModel GetOrderDetailByOrderId(string id);

        bool Create(HoaDonModel model);

        bool Update(HoaDonModel model);

        bool Delete(int id);

        public List<ThongKeKhachModel> Search(int pageIndex, int pageSize, out long total, string TenKH, DateTime? fr_NgayTao, DateTime? to_NgayTao);
    }
}
