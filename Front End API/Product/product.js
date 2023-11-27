const urlApiGetUserById = "https://localhost:44304/api/KhachHang/get-KhachHangByID";
const btnAdd = document.querySelectorAll(".add-product")

console.log(btnAdd)
var loginLocal = JSON.parse(localStorage.getItem("login"))

function getUser(){
   
    $.ajax({
        url: urlApiGetUserById+"?id="+loginLocal["user_id"],
        type: 'GET'
       
    })
     .done(res=>{
         console.log(res)
         localStorage.setItem("User_Order",JSON.stringify(res))

     })
     .fail(err=>{
         console.log(err)
     })
}
btnAdd.forEach(item=>{
    item.onclick =()=>{
        console.log("oge")
    
        getUser()}
})

function handleCreateOrder(){
    var data = {
            
            "maVanChuyen": 1,
            "maKhachHang": loginLocal["user_id"],
            "tenKH": "",
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
                "soLuong": 28,
                "tongGia": 92827280
              }
            ]
    }
}