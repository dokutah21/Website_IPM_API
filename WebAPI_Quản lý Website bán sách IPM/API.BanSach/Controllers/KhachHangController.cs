using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.BanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private IKhachHangBusiness _KhachHangBusiness;
        public KhachHangController(IKhachHangBusiness khachHangBusiness)
        {
            _KhachHangBusiness = khachHangBusiness;
        }

        [Route("GetAll_KhachHang")]
        [HttpGet]
        public List<KhachHangModel> getAll_KhachHang()
        {
            return _KhachHangBusiness.getAll_KhachHang();
        }

        [Route("get-KhachHangByID")]
        [HttpGet]
        public KhachHangModel GetDatabyID(string id)
        {
            return _KhachHangBusiness.GetDatabyID(id);
        }

        [Route("create-KhachHang")]
        [HttpPost]
        public KhachHangModel CreateItem([FromBody] KhachHangModel model)
        {
            _KhachHangBusiness.Create(model);
            return model;
        }

        [Route("update-KhachHang")]
        [HttpPut]
        public KhachHangModel UpdateItem([FromBody] KhachHangModel model)
        {
            _KhachHangBusiness.Update(model);
            return model;
        }

        [Route("delete-KhachHang")]
        [HttpDelete]
        public int DeleteItem(int id)
        {
            _KhachHangBusiness.Delete(id);
            return id;
        }

        [Route("deleteMultiple-KhachHang")]
        [HttpPost]
        public IActionResult DeleteKhachHang([FromBody] Dictionary<string, object> formData)
        {
            string ID = "";
            if (formData.Keys.Contains("MaKhachHang") && !string.IsNullOrEmpty(Convert.ToString(formData["MaKhachHang"]))) { ID = Convert.ToString(formData["MaKhachHang"]); }
            _KhachHangBusiness.DeleteMultiple(ID);
            return Ok();
        }

        [Route("search-KhachHang")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenKH = formData.ContainsKey("tenKH") ? Convert.ToString(formData["tenKH"].ToString()) : "";
                string DiaChi = formData.ContainsKey("diaChi") ? Convert.ToString(formData["diaChi"].ToString()) : "";
                long total = 0;
                var data = _KhachHangBusiness.Search(page, pageSize, out total, DiaChi, TenKH);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
