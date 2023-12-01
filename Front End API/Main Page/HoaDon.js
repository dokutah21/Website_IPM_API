appAGL=angular.module("hoadonModule",[])
const urlPort="https://localhost:44304/api/";
appAGL.controller("hoadonCtrl",function($scope,$http)
{
    $scope.getAll_HoaDon=function()
    {
        $http({
            method:"GET",
            url:urlPort+"HoaDon/GetAll_HoaDon"
            
        }).then(function(reponse)
        {
            $scope.danhsachHoaDon=reponse.data
            console.log(reponse.data);
        })
    }

    $scope.getAll_HoaDon();

    $scope.begin = 0;
    $scope.page = 1;
    $scope.pageSize = 7; // Số lượng mục trên mỗi trang
    $scope.pageCount;
    $scope.prop ='gia';

    $scope.repaginate = function()
    {
        $scope.begin = 0;
        $scope.pageCount = Math.ceil($scope.getAll_HoaDon.length / $scope.pageSize);
    }

    $scope.tenKH=""

    $scope.LoadHoaDon = function () {
        var token = localStorage.getItem('token');
        
        $http({
            method: 'POST',
            url:"https://localhost:44304/api/HoaDon/search-HoaDon",
            data:
                { 
                  page: 1,
                  pageSize: $scope.pageSize,
                  tenKH: $scope.tenKH 
                }
           
        }).
        
        then(function (response) {
            $scope.danhsachHoaDon= response.data.data;
            console.log($scope.getAll_HoaDon);
        });
    };
   

    $scope.PageIndex = function(total){
      var liElements = document.querySelectorAll('.pageElement li');
      liElements.forEach(function (li) {
          li.remove();
      });

      var countPage = Math.ceil((total)/$scope.pageSize)
      
      for (let i = 1; i <= countPage; i++) {
        var li = document.createElement('li')
        li.className= 'page-item'
        var a = document.createElement('a')
        li.appendChild(a)
        a.innerHTML = i
        document.querySelector('.pageElement').appendChild(li)
        li.onclick = function(){
          $scope.changePage(i)
        }
      }
    }


    $scope.deleteHoaDon_byID=function(maHD)
    {
        $http({
            method:"DELETE",
            url:urlPort+"HoaDon/delete-HoaDon?id="+maHD
            
        }).then(function()
        {
           alert("Xóa thành công")
           $scope.getAll_HoaDon();

        }).catch(function()
        {
            alert("Xóa thất bại")
        })
    }

    $scope.deleteSelected = function () {
        var selectedHoaDon= $scope.danhsachHoaDon.filter(function (x) {
            return x.selected;
        });
    
        var selectedMaHoaDon = selectedHoaDon.map(function (x) {
            return x.maHoaDon;
        });
    
        if (selectedMaHoaDon.length === 0) {
            alert("Vui lòng chọn ít nhất một hóa đơn để xóa.");
            return;
        }
    
        var maHoaDonString = selectedMaHoaDon.join(',');
    
        var result = confirm("Bạn có thực sự muốn xóa các hóa đơn đã chọn không?");
        if (result) {
            $http({

                method: 'POST',
                url: "https://localhost:44304/api/HoaDon/deleteMultiple-HoaDon",
                data: { MaHoaDon: maHoaDonString },
                headers: { 'Content-type': 'application/json' }
            })
    
            .then(function (response) {
                console.log(response.data);  // In thông tin phản hồi từ API
                $scope.getAll_HoaDon();
                alert('Đã xóa ' + selectedHoaDon.length + ' hóa đơn.');
            });
        }
    };

    
    $scope.add_HoaDon=function()
    {
        $scope.showFormQL_HoaDon=true;
        
        $scope.titleForm="Thêm mới hóa đơn"
    }
    $scope.save=function()
    {
        var objHoaDon={
            "maHoaDon": $scope.maHoaDon,
            "maVanChuyen": $scope.maVanChuyen,
            "maKhachHang": $scope.maKhachHang,
            "tenKH" :$scope.tenKH,
            "diaChi":$scope.diaChi,
            "ngayTao":$scope.ngayTao,
            "ngayDuyet":$scope.ngayDuyet,
            "ghiChu":$scope.ghiChu,
            "tongTien":$scope.tongTien,
            "trangThai":$scope.trangThai=="true"?true:false,
            list_json_ChiTietHoaDon:[{
                "maChiTietHoaDon":$scope.maChiTietHoaDon,
                "maHoaDon":$scope.maHoaDon,
                "maSach":$scope.maSach,
                "maGiamGia":$scope.maGiamGia,
                "soLuong": $scope.soLuong,
                "tongGia": $scope.tongGia
            }]
        }
        console.log(objHoaDon)

        if($scope.titleForm==="Thêm mới hóa đơn")
        {
            $http(
                {
                    method:"POST",
                    url:urlPort+"HoaDon/create-HoaDon",
                    data:objHoaDon
                }
            ).then(function(reponse)
            {
                alert("Thêm thành công hóa đơn")
                $scope.getAll_HoaDon()
            })
            .catch(function(error)
            {
                console.log("Thất bại hãy thử lại !"+error)
            })
        }
        else
        {
            $http(
                {
                    method:"PUT",
                    url:urlPort+"HoaDon/update-HoaDon",
                    data:objHoaDon
                }
            ).then(function(reponse)
            {
                alert("Sửa thành công hóa đơn, chi tiết hóa đơn và thông tin")
                $scope.getAll_HoaDon()
            })
            .catch(function(error)
            {
                console.log("Thất bại hãy thử lại !"+ error.data)
            })
        }
    }

    $scope.editHoaDon=function(x)
    {
        $scope.showFormQL_HoaDon=true;
        
        $scope.titleForm="Sửa thông tin hóa đơn";

        $scope.maHoaDon = x. maHoaDon
        $scope.maVanChuyen = x. maVanChuyen
        $scope.maKhachHang = x.maKhachHang
        $scope.tenKH = x.tenKH
        $scope.diaChi = x.diaChi
        $scope.ngayTao = x.ngayTao
        $scope.ngayDuyet = x.ngayDuyet
        $scope.ghiChu = x.ghiChu
        $scope.tongTien = x.tongTien
        $scope.trangThai = x.trangThai
        $scope.list_json_ChiTietHoaDon = x.list_json_ChiTietHoaDon
    }
    $scope.outForm=function()
    {
        $scope.showFormQL_HoaDon=false;

        $scope.maHoaDon = null
        $scope.maVanChuyen = null
        $scope.maKhachHang = null
        $scope.tenKH = null
        $scope.diaChi = null
        $scope.ngayTao = null
        $scope.ngayDuyet = null
        $scope.ghiChu = null
        $scope.tongTien = null
        $scope.trangThai = null

        $scope.list_json_ChiTietHoaDon = null
    }
})
