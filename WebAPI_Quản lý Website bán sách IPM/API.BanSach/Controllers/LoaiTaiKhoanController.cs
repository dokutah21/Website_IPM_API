using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.BanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiTaiKhoanController : ControllerBase
    {
        private ILoaiTaiKhoanBusiness _LoaiTaiKhoanBusiness;
        public LoaiTaiKhoanController(ILoaiTaiKhoanBusiness loaiTaiKhoanBusiness)
        {
            _LoaiTaiKhoanBusiness = loaiTaiKhoanBusiness;
        }

        [Route("get-LoaiTaiKhoanByID")]
        [HttpGet]
        public LoaiTaiKhoanModel GetDatabyID(string id)
        {
            return _LoaiTaiKhoanBusiness.GetDatabyID(id);
        }

        [Route("GetAll_LTK")]
        [HttpGet]
        public List<LoaiTaiKhoanModel> getAll_LTK()
        {
            return _LoaiTaiKhoanBusiness.getAll_LTK();
        }

        [Route("create-LoaiTaiKhoan")]
        [HttpPost]
        public LoaiTaiKhoanModel CreateItem([FromBody] LoaiTaiKhoanModel model)
        {
            _LoaiTaiKhoanBusiness.Create(model);
            return model;
        }

        [Route("update-LoaiTaiKhoan")]
        [HttpPut]
        public LoaiTaiKhoanModel UpdateItem([FromBody] LoaiTaiKhoanModel model)
        {
            _LoaiTaiKhoanBusiness.Update(model);
            return model;
        }


        [Route("delete-LoaiTaiKhoan")]
        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {

            if (_LoaiTaiKhoanBusiness.Delete(id))
            {
                return Ok(true);
            }
            return BadRequest(false);
        }

        [Route("deleteMultiple-LoaiTaiKhoan")]
        [HttpPost]
        public IActionResult DeleteLoaiTaiKhoan([FromBody] Dictionary<string, object> formData)
        {
            string ID = "";
            if (formData.Keys.Contains("MaLoai") && !string.IsNullOrEmpty(Convert.ToString(formData["MaLoai"]))) { ID = Convert.ToString(formData["MaLoai"]); }
            _LoaiTaiKhoanBusiness.DeleteMultiple(ID);
            return Ok();
        }


        [Route("search-LoaiTaiKhoan")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string PhanQuyen = formData.ContainsKey("phanQuyen") ? Convert.ToString(formData["phanQuyen"].ToString()) : "";
                string TenChucDanh = formData.ContainsKey("tenChucDanh") ? Convert.ToString(formData["tenChucDanh"].ToString()) : "";
                long total = 0;
                var data = _LoaiTaiKhoanBusiness.Search(page, pageSize, out total, PhanQuyen, TenChucDanh);
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
