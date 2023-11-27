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
        public List<NhaXuatBanModel> getAll_NXB()
        {
            return _res.getAll_NXB();
        }
        public NhaXuatBanModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(NhaXuatBanModel model)
        {
            return _res.Create(model);
        }

        public bool Update(NhaXuatBanModel model)
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

        public List<NhaXuatBanModel> Search(int pageIndex, int pageSize, out long total, string TenNXB)
        {
            return _res.Search(pageIndex, pageSize, out total, TenNXB);
        }
    }
}