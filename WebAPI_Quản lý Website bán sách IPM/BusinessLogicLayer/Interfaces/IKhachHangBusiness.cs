using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IKhachHangBusiness
    {
        List<KhachHangModel> getAll_KhachHang();
        KhachHangModel GetDatabyID(string id);

        bool Create(KhachHangModel model);

        bool Update(KhachHangModel model);

        bool Delete(int id);

        bool DeleteMultiple(string id);

        public List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string DiaChi, string TenKH);
    }
}
