using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class SanPhamBusiness : ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness(ISanPhamRepository res)
        {
            _res = res;
        }
        public SanPhamModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string TenSach, string TacGia)
        {
            return _res.Search(pageIndex, pageSize, out total, TenSach, TacGia);
        }
    }
}