using DataModel;

namespace DataAccessLayer
{
    public class VanChuyenRepository : IVanChuyenRepository
    {
        private IDatabaseHelper _dbHelper;
        public VanChuyenRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public VanChuyenModel GetDatabyID(string MaVanChuyen)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_GetVanChuyenID",
                     "@MaVanChuyen", MaVanChuyen);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<VanChuyenModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(VanChuyenModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_CreateVanChuyen",
                "@MaVanChuyen", model.MaVanChuyen,
                "@TenKH", model.TenKH,
                "@SDT", model.SDT,
                "@DiaChi", model.DiaChi,
                "@PhuongThucVanChuyen", model.PhuongThucVanChuyen,
                "@PhuongThucThanhToan", model.PhuongThucThanhToan);
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

        public bool Update(VanChuyenModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateVanChuyen",
                "@MaVanChuyen", model.MaVanChuyen,
                "@TenKH", model.TenKH,
                "@SDT", model.SDT,
                "@DiaChi", model.DiaChi,
                "@PhuongThucVanChuyen", model.PhuongThucVanChuyen,
                "@PhuongThucThanhToan", model.PhuongThucThanhToan);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_DeleteVanChuyen",
                "@MaVanChuyen", id);
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

        public List<VanChuyenModel> Search(int pageIndex, int pageSize, out long total, string TenKH, string DiaChi)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_SearchVanChuyen",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenKH", TenKH,
                    "@DiaChi", DiaChi);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<VanChuyenModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    } 
}
