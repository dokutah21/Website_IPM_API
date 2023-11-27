appAGL=angular.module("sanphamModule",[])
const urlPort="https://localhost:44304/api/";
appAGL.controller("sanphamCtrl",function($scope,$http)
{
    $scope.getAll_SanPham=function()
    {
        $http({
            method:"GET",
            url:urlPort+"SanPham/GetAll_SanPham"
            
        }).then(function(reponse)
        {
            $scope.danhsachSanPham=reponse.data
            console.log(reponse.data);
        });
    };
    $scope.getAll_SanPham();

    $scope.begin = 0;
    $scope.page = 1;
    $scope.pageSize = 7; // Số lượng mục trên mỗi trang
    $scope.pageCount;
    $scope.prop ='gia';

    $scope.repaginate = function()
    {
        $scope.begin = 0;
        $scope.pageCount = Math.ceil($scope.getAll_SanPham.length / $scope.pageSize);
    }

    $scope.tenSach=""
    $scope.tacGia =""

    $scope.LoadSanPham = function () {
        var token = localStorage.getItem('token');
        
        $http({
            method: 'POST',
            url:"https://localhost:44304/api/SanPham/search-SanPham",
            data:
                { 
                  page: 1,
                  pageSize: $scope.pageSize,
                  tenSach: $scope.tenSach,
                  tacGia: $scope.tacGia 
                }
           
        }).
        
        then(function (response) {
            $scope.danhsachSanPham= response.data.data;
            console.log($scope.getAll_SanPham);
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

    $scope.deleteSanPham_byID=function(maSP)
    {
        $http({
            method:"DELETE",
            url:urlPort+"SanPham/delete-SanPham?id="+maSP
            
        }).then(function()
        {
           alert("Xóa thành công")
           $scope.getAll_SanPham();

        }).catch(function()
        {
            alert("Xóa thất bại")
        })
    }

    $scope.deleteSelected = function () {
        var selectedSach = $scope.danhsachSanPham.filter(function (x) {
            return x.selected;
        });
    
        var selectedMaSach = selectedSach.map(function (x) {
            return x.maSach;
        });
    
        if (selectedMaSach.length === 0) {
            alert("Vui lòng chọn ít nhất một sản phẩm để xóa.");
            return;
        }
    
        // Chuyển danh sách mã sản phẩm thành chuỗi dạng '1,2,3'
        var maSachString = selectedMaSach.join(',');
    
        var result = confirm("Bạn có thực sự muốn xóa các sản phẩm đã chọn không?");
        if (result) {
            $http({
                method: 'POST',
                url: "https://localhost:44304/api/SanPham/deleteMultiple-SanPham",
                data: { MaSach: maSachString },  // Truyền danh sách mã sản phẩm qua body
                headers: { 'Content-type': 'application/json' }
            })
    
            .then(function (response) {
                console.log(response.data);  // In thông tin phản hồi từ API
                $scope.getAll_SanPham();
                alert('Đã xóa ' + selectedSach.length + ' sản phẩm.');
            });
        }
    };

    $scope.add_SanPham=function()
    {
        $scope.showFormQL_SanPham=true;
        
        $scope.titleForm="Thêm mới sản phẩm"
    }
    $scope.save=function()
    {
        var objSanPham={
            "maLoai":$scope.maSach,
            "tenSach": $scope.tenSach,
            "tacGia" :$scope.tacGia,
            "tenNXB": $scope.tenNXB,
            "phienBan":$scope.phienBan,
            "trangThai":$scope.trangThai,
            "anhSach": $scope.anhSach,
            "gia": $scope.gia
        }
        if($scope.titleForm==="Thêm mới sản phẩm")
        {
            $http(
                {
                    method:"POST",
                    url:urlPort+"SanPham/create-SanPham",
                    data:objLTK
                }
            ).then(function(reponse)
            {
                alert("Thêm thành công sản phẩm ")
                $scope.getAll_SanPham()
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
                    url:urlPort+"SanPham/update-SanPham",
                    data:objSanPham
                }
            ).then(function(reponse)
            {
                alert("Sửa thành công sản phẩm với thông tin")
                $scope.getAll_SanPham()
            })
            .catch(function(error)
            {
                alert("Thất bại hãy thử lại !")
            })
        }
    }
    $scope.editSanPham=function(x)
    {
        $scope.showFormQL_SanPham=true;
        
        $scope.titleForm="Sửa thông tin sản phẩm";

        $scope.maSach=x.maSach
        $scope.tenSach=x.tenSach
        $scope.tacGia=x.tacGia
        $scope.tenNXB=x.tenNXB
        $scope.phienBan=x.phienBan
        $scope.trangThai=x.trangThai
        $scope.anhSach=x.anhSach
        $scope.gia=x.gia
    }
    $scope.outForm=function()
    {
        $scope.showFormQL_SanPham=false;

        $scope.maSach=null
        $scope.tenSach=null
        $scope.tacGia=null
        $scope.tenNXB=null
        $scope.phienBan=null
        $scope.trangThai=null
        $scope.anhSach=null
        $scope.gia=null
    }
})