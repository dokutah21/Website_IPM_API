using DataModel;

namespace DataAccessLayer
{
    public class HoaDonNhapRepository : IHoaDonNhapRepository
    {
        private IDatabaseHelper _dbHelper;
        public HoaDonNhapRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public HoaDonNhapModel GetDatabyID(string MaHoaDonNhap)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_GetHoaDonNhapID",
                     "@MaHoaDonNhap", MaHoaDonNhap);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonNhapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(HoaDonNhapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_CreateHoaDonNhap",
                "@MaHoaDonNhap", model.MaHoaDonNhap,
                "@MaNXB", model.MaNXB,
                "@NgayNhap", model.NgayNhap,
                "@KieuThanhToan", model.KieuThanhToan,
                "@TrangThai", model.TrangThai,
                "@list_json_ChiTietHoaDonNhap", model.list_json_ChiTietHoaDonNhap != null ? MessageConvert.SerializeObject(model.list_json_ChiTietHoaDonNhap) : null);
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

        public bool Update(HoaDonNhapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateHoaDonNhap",
                "@MaHoaDonNhap", model.MaHoaDonNhap,
                "@MaNXB", model.MaNXB,
                "@NgayNhap", model.NgayNhap,
                "@KieuThanhToan", model.KieuThanhToan,
                "@TrangThai", model.TrangThai,
                "@list_json_ChiTietHoaDonNhap", model.list_json_ChiTietHoaDonNhap != null ? MessageConvert.SerializeObject(model.list_json_ChiTietHoaDonNhap) : null);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_DeleteHoaDonNhap",
                "@MaHoaDonNhap", id);
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
    } 
}
