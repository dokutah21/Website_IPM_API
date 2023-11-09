using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface IKhachHangRepository
    {
        KhachHangModel GetDatabyID(string id);

        bool Create(KhachHangModel model);

        bool Update(KhachHangModel model); 
        
        bool Delete(int id);

        public List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string DiaChi, string TenKH);
    }
}
