using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.BanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaXuatBanController : ControllerBase
    {
        private INhaXuatBanBusiness _NhaXuatBanBusiness;
        public NhaXuatBanController(INhaXuatBanBusiness nhaXuatBanBusiness)
        {
            _NhaXuatBanBusiness = nhaXuatBanBusiness;
        }

        [Route("get-NhaXuatBanByID")]
        [HttpGet]
        public NhaXuatBanModel GetDatabyID(string id)
        {
            return _NhaXuatBanBusiness.GetDatabyID(id);
        }

        [Route("create-NhaXuatBan")]
        [HttpPost]
        public NhaXuatBanModel CreateItem([FromBody] NhaXuatBanModel model)
        {
            _NhaXuatBanBusiness.Create(model);
            return model;
        }

        [Route("update-NhaXuatBan")]
        [HttpPut]
        public NhaXuatBanModel UpdateItem([FromBody] NhaXuatBanModel model)
        {
            _NhaXuatBanBusiness.Update(model);
            return model;
        }

        [Route("delete-NhaXuatBan")]
        [HttpDelete]
        public int DeleteItem(int id)
        {
            _NhaXuatBanBusiness.Delete(id);
            return id;
        }

        [Route("search-NhaXuatBan")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenNXB = "";
                if (formData.Keys.Contains("TenNXB") && !string.IsNullOrEmpty(Convert.ToString(formData["TenNXB"]))) { TenNXB = Convert.ToString(formData["TenNXB"]); }
                long total = 0;
                var data = _NhaXuatBanBusiness.Search(page, pageSize, out total, TenNXB);
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
