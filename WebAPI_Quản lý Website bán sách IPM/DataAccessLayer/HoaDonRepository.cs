using DataModel;

namespace DataAccessLayer
{
    public class HoaDonRepository : IHoaDonRepository
    {
        private IDatabaseHelper _dbHelper;
        public HoaDonRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<HoaDonModel> getAll_HoaDon()
        { 

            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_getAll_HoaDon");
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return result.ConvertTo<HoaDonModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HoaDonModel GetDatabyID(string MaHoaDon)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_GetHoaDonID",
                     "@MaHoaDon", MaHoaDon);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ChiTietHoaDonModel GetDatabyIDHD(string MaHoaDon)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_GetChiTietHoaDonID",
                     "@MaHoaDon", MaHoaDon);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChiTietHoaDonModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HoaDonModel> GetOrderByUsId(string userId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Pro_GetOrderByUsId",
                     "@userId", userId);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HoaDonModel GetOrderDetailByOrderId(string orderId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Pro_GetOrderDetailByOrderId",
                     "@orderId", orderId);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(HoaDonModel model)
        { 
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_CreateHoaDon",
                "@MaVanChuyen", model.MaVanChuyen,
                "@MaKhachHang", model.MaKhachHang,
                "@TenKH", model.TenKH,
                "@DiaChi", model.DiaChi,
                "@NgayTao", model.NgayTao,
                "@NgayDuyet", model.NgayDuyet,
                "@GhiChu", model.GhiChu,
                "@TrangThai", model.TrangThai,
                "@list_json_ChiTietHoaDon", model.list_json_ChiTietHoaDon != null ? MessageConvert.SerializeObject(model.list_json_ChiTietHoaDon) : null);
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

        public bool Update(HoaDonModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_UpdateHoaDon",
                "@MaHoaDon", model.MaHoaDon,
                "@MaVanChuyen", model.MaVanChuyen,
                "@MaKhachHang", model.MaKhachHang,
                "@TenKH", model.TenKH,
                "@DiaChi", model.DiaChi,
                "@NgayTao", model.NgayTao,
                "@NgayDuyet", model.NgayDuyet,
                "@GhiChu", model.GhiChu,
                "@TrangThai", model.TrangThai,
                "@list_json_ChiTietHoaDon", model.list_json_ChiTietHoaDon != null ? MessageConvert.SerializeObject(model.list_json_ChiTietHoaDon) : null);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_DeleteHoaDon",
                "@MaHoaDon", id);
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

        public List<ThongKeKhachModel> Search(int pageIndex, int pageSize, out long total, string TenKH, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_ThongKeKhach",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TenKH", TenKH,
                    "@fr_NgayTao", fr_NgayTao,
                    "@to_NgayTao", to_NgayTao
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ThongKeKhachModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    } 
}
