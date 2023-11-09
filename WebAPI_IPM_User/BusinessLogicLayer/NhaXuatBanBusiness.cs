using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class NhaXuatBanBusiness : INhaXuatBanBusiness
    {
        private INhaXuatBanRepository _res;
        public NhaXuatBanBusiness(INhaXuatBanRepository res)
        {
            _res = res;
        }
        public NhaXuatBanModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<NhaXuatBanModel> Search(int pageIndex, int pageSize, out long total, string TenNXB)
        {
            return _res.Search(pageIndex, pageSize, out total, TenNXB);
        }
    }
}