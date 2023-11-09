using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface INhaXuatBanRepository
    {
        NhaXuatBanModel GetDatabyID(string id);

        public List<NhaXuatBanModel> Search(int pageIndex, int pageSize, out long total, string TenNXB);
    }
}
