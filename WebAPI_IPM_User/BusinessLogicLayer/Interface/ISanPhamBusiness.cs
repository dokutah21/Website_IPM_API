using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface ISanPhamBusiness
    {
        SanPhamModel GetDatabyID(string id);

        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string TenSach, string TacGia);

        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total);
    }
}
