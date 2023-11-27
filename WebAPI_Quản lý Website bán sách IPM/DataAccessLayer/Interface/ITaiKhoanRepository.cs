using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface ITaiKhoanRepository
    {
        List<TaiKhoanModel> getAll_TaiKhoan();

        TaiKhoanModel GetDatabyID(string id);

        bool Create(TaiKhoanModel model);

        bool Update(TaiKhoanModel model); 
        
        bool Delete(int id);

        bool DeleteMultiple(string id);

        public List<TaiKhoanModel> Search(int pageIndex, int pageSize, out long total, string TenTaiKhoan);
    }
}
