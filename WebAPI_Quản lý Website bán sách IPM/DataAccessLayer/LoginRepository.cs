using DataModel;

namespace DataAccessLayer
{
    public class LoginRepository:ILoginRepository
    {
        private IDatabaseHelper _dbHelper;
        public LoginRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public LoginModel Login(string TenTaiKhoan, string MatKhau)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_LoginAccount",
                     "@us", TenTaiKhoan,
                     "@pw", MatKhau
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoginModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
    }
}
