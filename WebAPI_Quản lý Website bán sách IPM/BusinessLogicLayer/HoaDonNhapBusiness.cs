using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class HoaDonNhapBusiness : IHoaDonNhapBusiness
    {
        private IHoaDonNhapRepository _res;
        public HoaDonNhapBusiness(IHoaDonNhapRepository res)
        {
            _res = res;
        }
        public HoaDonNhapModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(HoaDonNhapModel model)
        {
            return _res.Create(model);
        }

        public bool Update(HoaDonNhapModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

        //public List<ThongKeSanPhamModel> Search(int pageIndex, int pageSize, out long total, string TenSach, DateTime? fr_NgayNhap, DateTime? to_NgayNhap)
        //{
        //    return _res.Search(pageIndex, pageSize, out total, TenSach, fr_NgayNhap, to_NgayNhap);
        //}
    }
}