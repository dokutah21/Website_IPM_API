myAdmin.controller('sanphamCtrl', function ($scope,$http) {
    // Khởi tạo
   
    $scope.listItem = [];

    $scope.getProducts = function () {
        $http({
            method: 'GET',
            url: 'https://localhost:44316/api/SanPham/ALLSP'
         
        }).then(function (response) {
            $scope.listItem = response.data;          
           console.log($scope.listItem)     
            // console.log($scope.listItem)
        }).catch(function (error) {
            console.error('Lỗi:', error);
        });
        
        
    };
    $scope.getProducts()

    // Các form chức năng thêm sửa xóa sản phẩm
    $scope.screen_shadow=true;
    $scope.addSPShow=false;
    $scope.editSPShow=false;
    $scope.detailSPShow=false;
    $scope.exitForm=()=>{
        $scope.screen_shadow=true;
        $scope.addSPShow=false;
        $scope.editSPShow=false;
        $scope.detailSPShow=false;
    }
    // model
    // $scope.MaSP=1;
    // $scope.TenSP="";
    // $scope.MaTH=1;
    // $scope.maLoai=1;
    // $scope.giaBan=10000;
    // $scope.imageSP='anh.jpg';
    // $scope.Mota="";
    // $scope.sldaban=0;
    // $scope.trangthai="Còn Hàng"
    // $scope.listTH={};
    // $scope.listTheLoai={};
    // // Lấy danh sách thể loại
    // $scope.getTheLoai = () => {
    //   $http({
    //         method: "GET",
    //         url: "https://localhost:44334/api/TheLoai/GetAll_TheLoai"
    //     }).then((response)=>{
    //        $scope.listTheLoai=response.data;
    //     }).catch((error)=>{
    //        console.log("Lỗi : "+error)
    //     })}
        
    // $scope.getThuongHieu = () => {
    //   $http({
    //         method: "GET",
    //         url: "https://localhost:44334/getALL_ThuongHieu"
    //     }).then((response)=>{
    //        $scope.listTH=response.data;
    //     }).catch((error)=>{
    //        console.log("Lỗi : "+error)})}
// Sử dụng hàm getTheLoai bằng cách sử dụng await

    // $scope.getTheLoai();   
    // $scope.getThuongHieu();  
        // hàm
    $scope.editSP=(x)=>{
        $scope.screen_shadow=false;
    }
    $scope.showAddSP=()=>{
        $scope.screen_shadow=false;
        $scope.addSPShow=true;
        console.log($scope.listTheLoai)  
    }
    // Thêm sp
    // $scope.objSP={        
    //          maSP: $scope.MaSP,
    //          maTH: $scope.MaTH,
    //          tenMH: $scope.TenSP,
    //          maLoai: $scope.maLoai,
    //          soLuongton: $scope.sldaban,
    //          giaBan: $scope.giaBan,
    //          image_SP: $scope.imageSP,
    //          mota: $scope.Mota,
    //          sldaban: $scope.sldaban,
    //          trangthai: $scope.trangthai          
    // }
    // $scope.addSP=()=>{   
    //     console.log($scope.objSP)  
       
    //     $http({
    //         method:"POST",
    //         url:'https://localhost:44334/api/SanPham/create_SP',
    //         data: $scope.objSP
    //     }).then((result)=>{
    //         alert("Thông báo : "+result.data)
    //     }).catch((error)=>{alert("Có lỗi khi thêm sản phẩm : "+ error)})

    // }
    $scope.detailSP=(x)=>{
        $scope.screen_shadow=false;
    }
    $scope.deleteSP=(x)=>{
        if (confirm("Bạn có chắc chắn muốn xóa?")) {
            // Người dùng đã nhấn nút "OK", thực hiện hành động xóa ở đây
            console.log("Hành động xóa đã được thực hiện.");
        } else {
            // Người dùng đã nhấn nút "Cancel", không thực hiện hành động xóa
            console.log("Hành động xóa đã bị hủy bỏ.");
        }
        
    }

    // Khởi tạo các biến
    $scope.page = 1;
    $scope.totalItems = 50; // Tổng số phần tử
    $scope.pageSize = 3;  // Số phần tử trên mỗi trang
    $scope.pageAfter = false;
    $scope.pagePrev = false;
    
    // Chuyển trang sau
    $scope.pageAfter = function() {
        if ($scope.page * $scope.pageSize < $scope.totalItems) {
            $scope.page += 1;
        }
        $scope.updatePagination();
    }
    
    // Chuyển trang trước
    $scope.pagePrev = function() {  
        if ($scope.page > 1) {
            $scope.page -= 1;
        }
        $scope.updatePagination();
    }
    
    // Cập nhật trạng thái phân trang
    $scope.updatePagination = function() {
        $scope.pageafter = $scope.page * $scope.pageSize < $scope.totalItems;
        $scope.pageprev = $scope.page > 1;
    }
    
    // Ban đầu, cập nhật trạng thái phân trang
    $scope.updatePagination();

 });

