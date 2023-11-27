const urlApiGetUserById = "https://localhost:44304/api/KhachHang/get-KhachHangByID";
const urlApiCreateOrder = "https://localhost:44304/api/HoaDon/create-HoaDon"
const btnAdd = document.querySelectorAll("#btnAdd")
const namepro  = $(".book-information h1")
const infoUs = JSON.parse(localStorage.getItem("User_Order"))
console.log(btnAdd)
var loginLocal = JSON.parse(localStorage.getItem("login"))

function httpgetAsync(data,resolve,reject,url){
  $.get(url+"?id="+data)
  .done(res=>{
    resolve(res)
  })
  .fail(err=>{
    reject(err)
  })
}

async function getUser(){
   var data =loginLocal["user_id"]
    const promise = new Promise((resolve,reject)=>{
      httpgetAsync(data,resolve,reject,urlApiGetUserById)
    })
    const res = await promise;
    console.log(res)
    localStorage.setItem("User_Order",JSON.stringify(res))
}
function httpPostAsync(data,resolve,reject,url){
  $.post({
    url: url,
    data:JSON.stringify(data),
    contentType:"application/json"

  })
  .done(res=>{
    console.log(res)
    resolve(res)
  })
  .fail(err=>{
    reject(err)
  })
}
btnAdd.forEach(item=>{
    item.onclick =  async()=>{
        console.log("oge")
    
        await getUser()
        handleCreateOrder();
      
      }
})


function handleCreateOrder(){
    var data = {
            
            "maVanChuyen": 1,
            "maKhachHang": loginLocal["user_id"],
            "tenKH": infoUs["tenKH"],
            "diaChi": "Hưng Yê",
            "ngayTao": "2023-11-27T02:11:31.267Z",
            "ngayDuyet": "2023-11-27T02:11:31.267Z",
            "ghiChu": "string",
            "tongTien": 234230,
            "trangThai": false,
            "list_json_ChiTietHoaDon": [
              {
                "maSach": 1,
                "maGiamGia": 1,
                "soLuong": 1,
                "tongGia": 92827280
              }
            ]
    }
    CreateOrder(data)
}
function CreateOrder(data){
  const promise = new Promise((resole,reject)=>{
    httpPostAsync(data,resole,reject,urlApiCreateOrder)
  })
  var res = promise;
  console.log(res)
}