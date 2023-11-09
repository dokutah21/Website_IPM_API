using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.BanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VanChuyenController : ControllerBase
    {
        private IVanChuyenBusiness _VanChuyenBusiness;
        public VanChuyenController(IVanChuyenBusiness vanChuyenBusiness)
        {
            _VanChuyenBusiness = vanChuyenBusiness;
        }

        [Route("get-VanChuyenByID")]
        [HttpGet]
        public VanChuyenModel GetDatabyID(string id)
        {
            return _VanChuyenBusiness.GetDatabyID(id);
        }

        [Route("create-VanChuyen")]
        [HttpPost]
        public VanChuyenModel CreateItem([FromBody] VanChuyenModel model)
        {
            _VanChuyenBusiness.Create(model);
            return model;
        }

        [Route("update-VanChuyen")]
        [HttpPut]
        public VanChuyenModel UpdateItem([FromBody] VanChuyenModel model)
        {
            _VanChuyenBusiness.Update(model);
            return model;
        }

        [Route("delete-VanChuyen")]
        [HttpDelete]
        public int DeleteItem(int id)
        {
            _VanChuyenBusiness.Delete(id);
            return id;
        }

        [Route("search-VanChuyen")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenKH = "";
                if (formData.Keys.Contains("TenKH") && !string.IsNullOrEmpty(Convert.ToString(formData["TenKH"]))) { TenKH = Convert.ToString(formData["TenKH"]); }
                string DiaChi = "";
                if (formData.Keys.Contains("DiaChi") && !string.IsNullOrEmpty(Convert.ToString(formData["DiaChi"]))) { DiaChi = Convert.ToString(formData["DiaChi"]); }
                long total = 0;
                var data = _VanChuyenBusiness.Search(page, pageSize, out total, TenKH, DiaChi);
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
