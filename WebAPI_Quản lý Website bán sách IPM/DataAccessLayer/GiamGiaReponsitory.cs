using DataModel;

namespace DataAccessLayer
{
    public class GiamGiaRepository : IGiamGiaRepository
    {
        private IDatabaseHelper _dbHelper;
        public GiamGiaRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public GiamGiaModel GetDatabyID(string MaGiamGia)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_GetGiamGiaID",
                     "@MaGiamGia", MaGiamGia);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GiamGiaModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(GiamGiaModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_CreateGiamGia",
                "@MaGiamGia", model.MaGiamGia,
                "@TenMaGiamGia", model.TenMaGiamGia,
                "@NoiDungMaGiamGia", model.NoiDungMaGiamGia,
                "@ThoiGianBatDau", model.ThoiGianBatDau,
                "@ThoiGianKetThuc", model.ThoiGianKetThuc,
                "@SoLuongMa", model.SoLuongMa,
                "@SoTienGiam", model.SoTienGiam,
                "@TrangThai", model.TrangThai);
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

        public bool Update(GiamGiaModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateGiamGia",
                "@MaGiamGia", model.MaGiamGia,
                "@TenMaGiamGia", model.TenMaGiamGia,
                "@NoiDungMaGiamGia", model.NoiDungMaGiamGia,
                "@ThoiGianBatDau", model.ThoiGianBatDau,
                "@ThoiGianKetThuc", model.ThoiGianKetThuc,
                "@SoLuongMa", model.SoLuongMa,
                "@SoTienGiam", model.SoTienGiam,
                "@TrangThai", model.TrangThai);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_DeleteGiamGia",
                "@MaGiamGia", id);
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

        public List<GiamGiaModel> Search(int pageIndex, int pageSize, out long total, string TenMaGiamGia, int SoTienGiam)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_SearchGiamGia",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenMaGiamGia", TenMaGiamGia,
                    "@SoTienGiam", SoTienGiam);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<GiamGiaModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    } 
}
