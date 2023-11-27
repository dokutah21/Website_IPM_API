using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class TaiKhoanBusiness : ITaiKhoanBusiness
    {
        private ITaiKhoanRepository _res;
        public TaiKhoanBusiness(ITaiKhoanRepository res)
        {
            _res = res;
        }
        public List<TaiKhoanModel> getAll_TaiKhoan()
        {
            return _res.getAll_TaiKhoan();
        }
        public TaiKhoanModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(TaiKhoanModel model)
        {
            return _res.Create(model);
        }

        public bool Update(TaiKhoanModel model)
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

        public List<TaiKhoanModel> Search(int pageIndex, int pageSize, out long total, string TenTaiKhoan)
        {
            return _res.Search(pageIndex, pageSize, out total, TenTaiKhoan);
        }
    }
}