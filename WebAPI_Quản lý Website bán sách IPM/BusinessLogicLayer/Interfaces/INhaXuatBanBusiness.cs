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
        List<NhaXuatBanModel> getAll_NXB();
        NhaXuatBanModel GetDatabyID(string id);

        bool Create(NhaXuatBanModel model);

        bool Update(NhaXuatBanModel model);

        bool Delete(int id);

        bool DeleteMultiple(string id);

        public List<NhaXuatBanModel> Search(int pageIndex, int pageSize, out long total, string TenNXB);
    }
}
