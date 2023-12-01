using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;
        public LoginController(ILoginBusiness userBusiness)
        {
            _loginBusiness = userBusiness;
        }
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _loginBusiness.Login(model.Username, model.Password);
            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không chính xác!" });
            return Ok(new { user_id = user.MaKH, taikhoan = user.TenTaiKhoan, email = user.Email, token = user.token,role=user.MaLoai });
        }
    }
}
