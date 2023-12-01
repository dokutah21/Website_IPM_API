using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class HoaDonBusiness : IHoaDonBusiness
    {
        private IHoaDonRepository _res;
        public HoaDonBusiness(IHoaDonRepository res)
        {
            _res = res;
        }

        public List<HoaDonModel> getAll_HoaDon()
        {
            return _res.getAll_HoaDon();
        }
        public HoaDonModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public ChiTietHoaDonModel GetDatabyIDHD(string id)
        {
            return _res.GetDatabyIDHD(id);
        }

        public List<HoaDonModel> GetOrderByUsId(string id)
        {
            return _res.GetOrderByUsId(id);
        }


        public HoaDonModel GetOrderDetailByOrderId(string id)
        {
            return _res.GetOrderDetailByOrderId(id);
        }

        public bool Create(HoaDonModel model)
        {
            return _res.Create(model);
        }

        public bool Update(HoaDonModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

        public List<ThongKeKhachModel> Search(int pageIndex, int pageSize, out long total, string TenKH, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        {
            return _res.Search(pageIndex, pageSize, out total, TenKH, fr_NgayTao, to_NgayTao);
        }


    }
}