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
        public int DeleteItem(int id)
        {
            _LoaiTaiKhoanBusiness.Delete(id);
            return id;
        }

        [Route("search-LoaiTaiKhoan")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string PhanQuyen = "";
                if (formData.Keys.Contains("PhanQuyen") && !string.IsNullOrEmpty(Convert.ToString(formData["PhanQuyen"]))) { PhanQuyen = Convert.ToString(formData["PhanQuyen"]); }
                string TenChucDanh = "";
                if (formData.Keys.Contains("TenChucDanh") && !string.IsNullOrEmpty(Convert.ToString(formData["TenChucDanh"]))) { PhanQuyen = Convert.ToString(formData["TenChucDanh"]); }
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
