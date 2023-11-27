using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.BanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiamGiaController : ControllerBase
    {
        private IGiamGiaBusiness _GiamGiaBusiness;
        public GiamGiaController(IGiamGiaBusiness giamGiaBusiness)
        {
            _GiamGiaBusiness = giamGiaBusiness;
        }

        [Route("get-GiamGiaByID")]
        [HttpGet]
        public GiamGiaModel GetDatabyID(string id)
        {
            return _GiamGiaBusiness.GetDatabyID(id);
        }

        [Route("GetAll_GiamGia")]
        [HttpGet]
        public List<GiamGiaModel> getAll_GiamGia()
        {
            return _GiamGiaBusiness.getAll_GiamGia();
        }

        [Route("create-GiamGia")]
        [HttpPost]
        public GiamGiaModel CreateItem([FromBody] GiamGiaModel model)
        {
            _GiamGiaBusiness.Create(model);
            return model;
        }

        [Route("update-GiamGia")]
        [HttpPut]
        public GiamGiaModel UpdateItem([FromBody] GiamGiaModel model)
        {
            _GiamGiaBusiness.Update(model);
            return model;
        }

        [Route("delete-GiamGia")]
        [HttpDelete]
        public int DeleteItem(int id)
        {
            _GiamGiaBusiness.Delete(id);
            return id;
        }

        [Route("deleteMultiple-GiamGia")]
        [HttpPost]
        public IActionResult DeleteGiamGia([FromBody] Dictionary<string, object> formData)
        {
            string ID = "";
            if (formData.Keys.Contains("MaGiamGia") && !string.IsNullOrEmpty(Convert.ToString(formData["MaGiamGia"]))) { ID = Convert.ToString(formData["MaGiamGia"]); }
            _GiamGiaBusiness.DeleteMultiple(ID);
            return Ok();
        }

        [Route("search-GiamGia")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenMaGiamGia = formData.ContainsKey("tenMaGiamGia") ? Convert.ToString(formData["tenMaGiamGia"].ToString()) : "";
                int SoTienGiam = formData.ContainsKey("soTienGiam") && int.TryParse(formData["soTienGiam"].ToString(), out var soTienGiamValue) ? soTienGiamValue : 0;
                long total = 0;
                var data = _GiamGiaBusiness.Search(page, pageSize, out total, TenMaGiamGia, SoTienGiam);
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
