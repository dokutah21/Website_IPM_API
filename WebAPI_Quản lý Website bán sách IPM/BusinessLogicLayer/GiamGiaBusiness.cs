using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class GiamGiaBusiness : IGiamGiaBusiness
    {
        private IGiamGiaRepository _res;
        public GiamGiaBusiness(IGiamGiaRepository res)
        {
            _res = res;
        }
        public GiamGiaModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(GiamGiaModel model)
        {
            return _res.Create(model);
        }

        public bool Update(GiamGiaModel model)
        {   
            return _res.Update(model);
        }

        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

        public List<GiamGiaModel> Search(int pageIndex, int pageSize, out long total, string TenMaGiamGia, int SoTienGiam)
        {
            return _res.Search(pageIndex, pageSize, out total, TenMaGiamGia, SoTienGiam);
        }
    }
}