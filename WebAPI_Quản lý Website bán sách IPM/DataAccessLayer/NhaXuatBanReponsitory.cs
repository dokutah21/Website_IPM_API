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

        public List<NhaXuatBanModel> getAll_NXB()
        {

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_getAll_NXB");
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<NhaXuatBanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public bool Create(NhaXuatBanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_CreateNhaXuatBan",
                "@MaNXB", model.MaNXB,
                "@TenNXB", model.TenNXB,
                "@DiaChi", model.DiaChi,
                "@SoDienThoai", model.SoDienThoai);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(NhaXuatBanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateNhaXuatBan",
                "@MaNXB", model.MaNXB,
                "@TenNXB", model.TenNXB,
                "@DiaChi", model.DiaChi,
                "@SoDienThoai", model.SoDienThoai);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_DeleteNhaXuatBan",
                "@MaNXB", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteMultiple(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "DeleteMultipleNXB",
                "@MaNXB", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
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
