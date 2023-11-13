using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface ILoaiTaiKhoanBusiness
    {
        LoaiTaiKhoanModel GetDatabyID(string id);

        bool Create(LoaiTaiKhoanModel model);

        bool Update(LoaiTaiKhoanModel model);

        bool Delete(int id);
        List<LoaiTaiKhoanModel> getAll_LTK();

        public List<LoaiTaiKhoanModel> Search(int pageIndex, int pageSize, out long total, string PhanQuyen, string TenChucDanh);
    }
}
