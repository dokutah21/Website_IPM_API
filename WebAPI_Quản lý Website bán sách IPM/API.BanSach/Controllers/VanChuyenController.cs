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

        [Route("GetAll_VanChuyen")]
        [HttpGet]
        public List<VanChuyenModel> getAll_VanChuyen()
        {
            return _VanChuyenBusiness.getAll_VanChuyen();
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

        [Route("deleteMultiple-VanChuyen")]
        [HttpPost]
        public IActionResult DeleteSanPham([FromBody] Dictionary<string, object> formData)
        {
            string ID = "";
            if (formData.Keys.Contains("MaVanChuyen") && !string.IsNullOrEmpty(Convert.ToString(formData["MaVanChuyen"]))) { ID = Convert.ToString(formData["MaVanChuyen"]); }
            _VanChuyenBusiness.DeleteMultiple(ID);
            return Ok();
        }

        [Route("search-VanChuyen")]
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
