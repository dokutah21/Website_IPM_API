using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.BanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private ITaiKhoanBusiness _TaiKhoanBusiness;
        public TaiKhoanController(ITaiKhoanBusiness taiKhoanBusiness)
        {
            _TaiKhoanBusiness = taiKhoanBusiness;
        }

        [Route("GetAll_TaiKhoan")]
        [HttpGet]
        public List<TaiKhoanModel> getAll_TaiKhoan()
        {
            return _TaiKhoanBusiness.getAll_TaiKhoan();
        }

        [Route("get-TaiKhoanByID")]
        [HttpGet]
        public TaiKhoanModel GetDatabyID(string id)
        {
            return _TaiKhoanBusiness.GetDatabyID(id);
        }

        [Route("create-TaiKhoan")]
        [HttpPost]
        public TaiKhoanModel CreateItem([FromBody] TaiKhoanModel model)
        {
            _TaiKhoanBusiness.Create(model);
            return model;
        }

        [Route("update-TaiKhoan")]
        [HttpPut]
        public TaiKhoanModel UpdateItem([FromBody] TaiKhoanModel model)
        {
            _TaiKhoanBusiness.Update(model);
            return model;
        }

        [Route("delete-TaiKhoan")]
        [HttpDelete]
        public int DeleteItem(int id)
        {
            _TaiKhoanBusiness.Delete(id);
            return id;
        }

        [Route("deleteMultiple-TaiKhoan")]
        [HttpPost]
        public IActionResult DeleteTaiKhoan([FromBody] Dictionary<string, object> formData)
        {
            string ID = "";
            if (formData.Keys.Contains("MaTK") && !string.IsNullOrEmpty(Convert.ToString(formData["MaTK"]))) { ID = Convert.ToString(formData["MaTK"]); }
            _TaiKhoanBusiness.DeleteMultiple(ID);
            return Ok();
        }


        [Route("search-TaiKhoan")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenTaiKhoan = formData.ContainsKey("tenTaiKhoan") ? Convert.ToString(formData["tenTaiKhoan"].ToString()) : ""; long total = 0;
                var data = _TaiKhoanBusiness.Search(page, pageSize, out total, TenTaiKhoan);
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
