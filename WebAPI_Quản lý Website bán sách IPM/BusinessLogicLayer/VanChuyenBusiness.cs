using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class VanChuyenBusiness : IVanChuyenBusiness
    {
        private IVanChuyenRepository _res;
        public VanChuyenBusiness(IVanChuyenRepository res)
        {
            _res = res;
        }
        public VanChuyenModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(VanChuyenModel model)
        {
            return _res.Create(model);
        }

        public bool Update(VanChuyenModel model)
        {   
            return _res.Update(model);
        }

        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

        public List<VanChuyenModel> Search(int pageIndex, int pageSize, out long total, string TenKH, string DiaChi)
        {
            return _res.Search(pageIndex, pageSize, out total, TenKH, DiaChi);
        }
    }
}