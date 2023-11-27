using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class LoaiTaiKhoanBusiness : ILoaiTaiKhoanBusiness
    {
        private ILoaiTaiKhoanRepository _res;
        public LoaiTaiKhoanBusiness(ILoaiTaiKhoanRepository res)
        {
            _res = res;
        }
        public List<LoaiTaiKhoanModel> getAll_LTK()
        {
            return _res.getAll_LTK();
        }
        public LoaiTaiKhoanModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(LoaiTaiKhoanModel model)
        {
            return _res.Create(model);
        }

        public bool Update(LoaiTaiKhoanModel model)
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

        public List<LoaiTaiKhoanModel> Search(int pageIndex, int pageSize, out long total, string PhanQuyen, string TenChucDanh)
        {
            return _res.Search(pageIndex, pageSize, out total, PhanQuyen, TenChucDanh);
        }   
    }
}