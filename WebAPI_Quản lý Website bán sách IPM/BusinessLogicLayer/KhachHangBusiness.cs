using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class KhachHangBusiness : IKhachHangBusiness
    {
        private IKhachHangRepository _res;
        public KhachHangBusiness(IKhachHangRepository res)
        {
            _res = res;
        }
        public List<KhachHangModel> getAll_KhachHang()
        {
            return _res.getAll_KhachHang();
        }
        public KhachHangModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(KhachHangModel model)
        {
            return _res.Create(model);
        }

        public bool Update(KhachHangModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

        public bool DeleteMultiple(string id)
        {
            return _res.DeleteMultiple(id);
        }

        public List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string DiaChi, string TenKH)
        {
            return _res.Search(pageIndex, pageSize, out total, DiaChi, TenKH);
        }
    }
}