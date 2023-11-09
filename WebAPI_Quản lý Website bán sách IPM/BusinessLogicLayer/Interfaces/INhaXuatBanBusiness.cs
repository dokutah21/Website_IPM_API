using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface INhaXuatBanBusiness
    {
        NhaXuatBanModel GetDatabyID(string id);

        bool Create(NhaXuatBanModel model);

        bool Update(NhaXuatBanModel model);

        bool Delete(int id);

        public List<NhaXuatBanModel> Search(int pageIndex, int pageSize, out long total, string TenNXB);
    }
}
