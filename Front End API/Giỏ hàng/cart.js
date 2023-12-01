
const urlApiCreateOrder = "";
const urlApiUpdateOrder = "";
const urlApiGetOrderByUserId = "https://localhost:44304/api/HoaDon/get-GetOrderByUsId";
const urlApiGetOrderDetailByOrderid = "";
const urlApiGetProductByid="https://localhost:44304/api/SanPham/get-SanPhamByID";
const urlApiGetUserById = "https://localhost:44304/api/KhachHang/get-KhachHangByID"
const btnAdd = document.querySelectorAll(".add-product")
const inputAmount = $(".met")
var loginLocal = JSON.parse(localStorage.getItem("login"))

async function Run(){
    await GetOrderByUserId();
    handleGetProducInOrderByProductId();

};
Run();

async function getUser(){
    data = {id:loginLocal["user_id"]}
    const promise = new Promise((resolve,reject)=>{
        httpGetAsyncByData(urlApiGetUserById,resolve,reject,data);
    })
    try{
        const res = await promise;
        localStorage.setItem("user_order",JSON.stringify(res));
    }catch(err){
        console.log(err)
    }
}
async function handleAddProductOnClick(){
    
}
btnAdd.forEach(item=>{
    item.onclick = async ()=>{
        await getUser();
        handleCreateOrder (item.dataset.id,Number(item.parentElement.parentElement.querySelector(".prices .discount").textContent.replace(",","").replace("₫","")))
        
}
})

function handleCreateOrder(masach,price){
    const user_order = JSON.parse(localStorage.getItem("user_order"))
    var data = {
            
            "maVanChuyen": 1,
            "maKhachHang": loginLocal["user_id"],
            "tenKH": user_order["tenKH"],
            "diaChi": user_order["diaChi"],
            "ngayTao": "2023-11-27T02:11:31.267Z",
            "ngayDuyet": "2023-11-27T02:11:31.267Z",
            "ghiChu": "",
            "tongTien": price*Number(inputAmount.val()),
            "trangThai": false,
            "list_json_ChiTietHoaDon": [
              {
                "maSach": Number(masach),
                "maGiamGia": 1,
                "soLuong": Number(inputAmount.val()),
                "tongGia": price*Number(inputAmount.val())
              }
            ]
    }
    console.log(data)
    CreateOrder(data);
}
function httpGetAsyncByData(url,resolve,reject,data)
{
    $.get({
        url:url,
        data:data
    })
    .done(res=>{
        resolve(res);
    })
    .fail(err=>{
        reject(err)
    })
};
function
CreateOrder(data){
    $.post({
        url:"https://localhost:44304/api/HoaDon/create-HoaDon",
        data:JSON.stringify(data),
        contentType:"application/json"
    })
    .done( async(res)=>{
        await GetOrderByUserId();
        handleGetProducInOrderByProductId();
    })
    .fail(err=>{
        console.log(err)})
}
async function GetOrderByUserId(){
    var loginLocal = JSON.parse(localStorage.getItem("login"))
    var data = {id:loginLocal["user_id"]}
    const promise = new Promise((resolve,reject)=>{
        httpGetAsyncByData(urlApiGetOrderByUserId,resolve,reject,data)
    })
    try{
        const res = await promise;
        localStorage.setItem("listOrder",JSON.stringify(res))
        console.log(res[0]["list_json_ChiTietHoaDon"])
    
    }
    catch(err){
        console.log(err);
    }
   
};

async function handleGetProducInOrderByProductId(){
    var listOrder = JSON.parse(localStorage.getItem("listOrder"));
    var data = listOrder.map(item=>{
        return {id:item["list_json_ChiTietHoaDon"][0]["maSach"]}
    })
    GetProducInOrderByProductId(data)
}
async function GetProducInOrderByProductId(data){
    let i = 0;
     var list = []
    while(i<data.length){
        const promise = new Promise((resolve,reject)=>{
            httpGetAsyncByData(urlApiGetProductByid,resolve,reject,data[i])
        })
        try{
            const res = await promise;
            list.push(res)
        }
        catch(err){
            console.log(err)
        }
        i++   
    } 
    renderOrder(list);
  
}


async function renderOrder(listproduct){
   
    var listOrder = JSON.parse(localStorage.getItem("listOrder"))
    const totalOrder = listOrder.length;
    $(".totalOrder").html(totalOrder)

    var totalBill = 0;
    
    var html =  listproduct.map(item=>{
        var order =  listOrder.find(order =>{
            return order["list_json_ChiTietHoaDon"][0]["maSach"] == item["maSach"] 
        })
        let totalPrice = order["list_json_ChiTietHoaDon"][0]["soLuong"] *order["list_json_ChiTietHoaDon"][0]["tongGia"] 
        
        totalBill += totalPrice; // Cộng thêm vào tổng hóa đơn
        
        console.log(order)
        return `

        <table>
            <tr class="whyicantfix">
                <td style="width: 300px"><img style="width: 70px; height: 100px" src="${item["anhSach"]}" /></td>
                
                <td style="width: 450px">
                    <a href="#"><strong>${item["tenSach"]}</strong></a><br>
                </td>

                <td style="width: 300px"> ${order["list_json_ChiTietHoaDon"][0]["soLuong"]}</td>

                <td style="width: 300px">${totalPrice}₫</td>

                <td><a onclick=DeleteOrder(${order["maHoaDon"]}) href="#" class="cart click-delete">Xóa</a></td>
            </tr>
        </table>
        `
    })
    $(".title-cart").html(html.join(""));

    $(".total-bill").html(`${totalBill}₫`);
};




function DeleteOrder(orderid){
    $.ajax({
        url:"https://localhost:44304/api/HoaDon/delete-HoaDon?id="+orderid,
        type:"DELETE" 
    })
    .done(res=>{
        console.log(res)
    })
    .fail(err=>{
        console.log(err)
    })
}

