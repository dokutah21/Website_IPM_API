using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.BanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _SanPhamBusiness;
        public SanPhamController(ISanPhamBusiness sanPhamBusiness)
        {
            _SanPhamBusiness = sanPhamBusiness;
        }

        [Route("get-SanPhamByID")]
        [HttpGet]
        public SanPhamModel GetDatabyID(string id)
        {
            return _SanPhamBusiness.GetDatabyID(id);
        }

        [Route("search-SanPham")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenSach = "";
                if (formData.Keys.Contains("TenSach") && !string.IsNullOrEmpty(Convert.ToString(formData["TenSach"]))) { TenSach = Convert.ToString(formData["TenSach"]); }
                string TacGia = "";
                if (formData.Keys.Contains("TacGia") && !string.IsNullOrEmpty(Convert.ToString(formData["TacGia"]))) { TacGia = Convert.ToString(formData["TacGia"]); }
                long total = 0;
                var data = _SanPhamBusiness.Search(page, pageSize, out total, TenSach, TacGia);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
