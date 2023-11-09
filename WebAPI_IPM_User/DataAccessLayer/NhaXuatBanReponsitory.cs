using DataModel;

namespace DataAccessLayer
{
    public class NhaXuatBanRepository : INhaXuatBanRepository
    {
        private IDatabaseHelper _dbHelper;
        public NhaXuatBanRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public NhaXuatBanModel GetDatabyID(string MaNXB)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_GetNhaXuatBanID",
                     "@MaNXB", MaNXB);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhaXuatBanModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NhaXuatBanModel> Search(int pageIndex, int pageSize, out long total, string TenNXB)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_SearchNhaXuatBan",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenNXB", TenNXB);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<NhaXuatBanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    } 
}
