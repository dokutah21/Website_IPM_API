using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IVanChuyenBusiness
    {
        VanChuyenModel GetDatabyID(string id);

        bool Create(VanChuyenModel model);

        bool Update(VanChuyenModel model);

        bool Delete(int id);

        public List<VanChuyenModel> Search(int pageIndex, int pageSize, out long total, string TenKH, string DiaChi);
    }
}
