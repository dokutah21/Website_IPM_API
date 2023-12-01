using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace API.BanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private IHoaDonBusiness _HoaDonBusiness;
        public HoaDonController(IHoaDonBusiness hoaDonBusiness)
        {
            _HoaDonBusiness = hoaDonBusiness;
        }

        [Route("GetAll_HoaDon")]
        [HttpGet]
        public List<HoaDonModel> getAll_HoaDon()
        {
            return _HoaDonBusiness.getAll_HoaDon();
        }

        [Route("get-HoaDonByID")]
        [HttpGet]
        public HoaDonModel GetDatabyID(string id)
        {
            return _HoaDonBusiness.GetDatabyID(id);
        }

        [Route("get-ChiTietHoaDonByID")]
        [HttpGet]
        public ChiTietHoaDonModel GetDataByIDHD(string id)
        {
            return _HoaDonBusiness.GetDatabyIDHD(id);
        }


        [Route("get-GetOrderByUsId")]
        [HttpGet]
        public List<HoaDonModel> GetOrderByUsId(string id)
        {
            return _HoaDonBusiness.GetOrderByUsId(id);
        }

        [Route("get-GetOrderDetailByOrderId")]
        [HttpGet]
        public HoaDonModel GetOrderDetailByOrderId(string id)
        {
            return _HoaDonBusiness.GetOrderDetailByOrderId(id);
        }


        [Route("create-HoaDon")]
        [HttpPost]
        public HoaDonModel CreateItem([FromBody] HoaDonModel model)
        {
            _HoaDonBusiness.Create(model);
            return model;
        }

        [Route("update-HoaDon")]
        [HttpPut]
        public HoaDonModel UpdateItem([FromBody] HoaDonModel model)
        {
            _HoaDonBusiness.Update(model);
            return model;
        }

        [Route("delete-HoaDon")]
        [HttpDelete]
        public int DeleteItem(int id)
        {
            _HoaDonBusiness.Delete(id);
            return id;
        }

        [Route("statistical-ThongKeKhach")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenKH = "";
                if (formData.Keys.Contains("TenKH") && !string.IsNullOrEmpty(Convert.ToString(formData["TenKH"]))) { TenKH = Convert.ToString(formData["TenKH"]); }
                DateTime? fr_NgayTao = null;
                if (formData.Keys.Contains("fr_NgayTao") && formData["fr_NgayTao"] != null && formData["fr_NgayTao"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["fr_NgayTao"].ToString());
                    fr_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                }
                DateTime? to_NgayTao = null;
                if (formData.Keys.Contains("to_NgayTao") && formData["to_NgayTao"] != null && formData["to_NgayTao"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["to_NgayTao"].ToString());
                    to_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
                }
                long total = 0;
                var data = _HoaDonBusiness.Search(page, pageSize, out total, TenKH, fr_NgayTao, to_NgayTao);
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
