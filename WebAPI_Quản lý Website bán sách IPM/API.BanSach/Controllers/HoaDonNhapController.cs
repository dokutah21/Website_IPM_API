using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.BanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonNhapController : ControllerBase
    {
        private IHoaDonNhapBusiness _HoaDonNhapBusiness;
        public HoaDonNhapController(IHoaDonNhapBusiness hoaDonNhapBusiness)
        {
            _HoaDonNhapBusiness = hoaDonNhapBusiness;
        }

        [Route("get-HoaDonNhapByID")]
        [HttpGet]
        public HoaDonNhapModel GetDatabyID(string id)
        {
            return _HoaDonNhapBusiness.GetDatabyID(id);
        }

        [Route("create-HoaDonNhap")]
        [HttpPost]
        public HoaDonNhapModel CreateItem([FromBody] HoaDonNhapModel model)
        {
            _HoaDonNhapBusiness.Create(model);
            return model;
        }

        [Route("update-HoaDonNhap")]
        [HttpPut]
        public HoaDonNhapModel UpdateItem([FromBody] HoaDonNhapModel model)
        {
            _HoaDonNhapBusiness.Update(model);
            return model;
        }

        [Route("delete-HoaDonNhap")]
        [HttpDelete]
        public int DeleteItem(int id)
        {
            _HoaDonNhapBusiness.Delete(id);
            return id;
        }

        [Route("statistical-SanPham")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenSach = "";
                if (formData.Keys.Contains("TenSach") && !string.IsNullOrEmpty(Convert.ToString(formData["TenSach"]))) { TenSach = Convert.ToString(formData["TenSach"]); }
                DateTime? fr_NgayNhap = null;
                if (formData.Keys.Contains("fr_NgayNhap") && formData["fr_NgayNhap"] != null && formData["fr_NgayNhap"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["fr_NgayNhap"].ToString());
                    fr_NgayNhap = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                }
                DateTime? to_NgayNhap = null;
                if (formData.Keys.Contains("to_NgayNhap") && formData["to_NgayNhap"] != null && formData["to_NgayNhap"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["to_NgayNhap"].ToString());
                    to_NgayNhap = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
                }
                long total = 0;
                var data = _HoaDonNhapBusiness.Search(page, pageSize, out total, TenSach, fr_NgayNhap, to_NgayNhap);
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
