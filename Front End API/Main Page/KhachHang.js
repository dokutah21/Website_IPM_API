appAGL=angular.module("khachhangModule",[])
const urlPort="https://localhost:44304/api/";
appAGL.controller("khachhangCtrl",function($scope,$http)
{
    $scope.getAll_KhachHang=function()
    {
        $http({
            method:"GET",
            url:urlPort+"KhachHang/GetAll_KhachHang"
            
        }).then(function(reponse)
        {
            $scope.danhsachKhachHang=reponse.data
            console.log(reponse.data);
        })
    }

    $scope.getAll_KhachHang();

    $scope.begin = 0;
    $scope.page = 1;
    $scope.pageSize = 7; // Số lượng mục trên mỗi trang
    $scope.pageCount;
    $scope.prop ='gia';

    $scope.repaginate = function()
    {
        $scope.begin = 0;
        $scope.pageCount = Math.ceil($scope.getAll_KhachHang.length / $scope.pageSize);
    }

    $scope.tenKH=""
    $scope.diaChi =""

    $scope.LoadKhachHang = function () {
        var token = localStorage.getItem('token');
        
        $http({
            method: 'POST',
            url:"https://localhost:44304/api/KhachHang/search-KhachHang",
            data:
                { 
                  page: 1,
                  pageSize: $scope.pageSize,
                  tenKH: $scope.tenKH,
                  diaChi: $scope.diaChi 
                }
           
        }).
        
        then(function (response) {
            $scope.danhsachKhachHang= response.data.data;
            console.log($scope.getAll_KhachHang);
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


    $scope.deleteKhachHang_byID=function(maKH)
    {
        $http({
            method:"DELETE",
            url:urlPort+"KhachHang/delete-KhachHang?id="+maKH
            
        }).then(function()
        {
           alert("Xóa thành công")
           $scope.getAll_KhachHang();

        }).catch(function()
        {
            alert("Xóa thất bại")
        })
    }

    $scope.deleteSelected = function () {
        var selectedKhachHang= $scope.danhsachKhachHang.filter(function (x) {
            return x.selected;
        });
    
        var selectedMaKhachHang = selectedKhachHang.map(function (x) {
            return x.maKhachHang;
        });
    
        if (selectedMaKhachHang.length === 0) {
            alert("Vui lòng chọn ít nhất một khách hàng để xóa.");
            return;
        }
    
        var maKhachHangString = selectedMaKhachHang.join(',');
    
        var result = confirm("Bạn có thực sự muốn xóa các khách hàng đã chọn không?");
        if (result) {
            $http({

                method: 'POST',
                url: "https://localhost:44304/api/KhachHang/deleteMultiple-KhachHang",
                data: { MaKhachHang: maKhachHangString },
                headers: { 'Content-type': 'application/json' }
            })
    
            .then(function (response) {
                console.log(response.data);  // In thông tin phản hồi từ API
                $scope.getAll_KhachHang();
                alert('Đã xóa ' + selectedKhachHang.length + ' khách hàng.');
            });
        }
    };

    
    $scope.add_KhachHang=function()
    {
        $scope.showFormQL_KhachHang=true;
        
        $scope.titleForm="Thêm mới khách hàng"
    }
    $scope.save=function()
    {
        var objKhachHang={
            "maKhachHang": $scope.maKhachHang,
            "tenKH": $scope.tenKH,
            "gioiTinh": $scope.gioiTinh,
            "diaChi" :$scope.diaChi,
            "sdt":$scope.sdt,
            "email":$scope.email
        }

        if($scope.titleForm==="Thêm mới khách hàng")
        {
            $http(
                {
                    method:"POST",
                    url:urlPort+"KhachHang/create-KhachHang",
                    data:objKhachHang
                }
            ).then(function(reponse)
            {
                alert("Thêm thành công khách hàng")
                $scope.getAll_KhachHang()
            })
            .catch(function(error)
            {
                alert("Thất bại hãy thử lại !")
            })
        }
        else
        {
            $http(
                {
                    method:"PUT",
                    url:urlPort+"KhachHang/update-KhachHang",
                    data:objKhachHang
                }
            ).then(function(reponse)
            {
                alert("Sửa thành công khách hàng và thông tin")
                $scope.getAll_KhachHang()
            })
            .catch(function(error)
            {
                alert("Thất bại hãy thử lại !")
            })
        }
    }

    $scope.editKhachHang=function(x)
    {
        $scope.showFormQL_KhachHang=true;
        
        $scope.titleForm="Sửa thông tin khách hàng";

        $scope.maKhachHang=x.maKhachHang
        $scope.tenKH=x.tenKH
        $scope.gioiTinh=x.gioiTinh
        $scope.diaChi=x.diaChi
        $scope.sdt=x.sdt
        $scope.email=x.email
    }
    $scope.outForm=function()
    {
        $scope.showFormQL_KhachHang=false;

        $scope.maKhachHang=null
        $scope.tenKH=null
        $scope.gioiTinh=null
        $scope.diaChi=null
        $scope.sdt=null
        $scope.email=null
    }
})
