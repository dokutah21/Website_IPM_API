appAGL=angular.module("vanchuyenModule",[])
const urlPort="https://localhost:44304/api/";
appAGL.controller("vanchuyenCtrl",function($scope,$http)
{
    $scope.getAll_VanChuyen=function()
    {
        $http({
            method:"GET",
            url:urlPort+"VanChuyen/GetAll_VanChuyen"
            
        }).then(function(reponse)
        {
            $scope.danhsachVanChuyen=reponse.data
            console.log(reponse.data);
        })
    }

    $scope.getAll_VanChuyen();

    $scope.begin = 0;
    $scope.page = 1;
    $scope.pageSize = 7; // Số lượng mục trên mỗi trang
    $scope.pageCount;
    $scope.prop ='gia';

    $scope.repaginate = function()
    {
        $scope.begin = 0;
        $scope.pageCount = Math.ceil($scope.getAll_VanChuyen.length / $scope.pageSize);
    }

    $scope.tenKH=""
    $scope.diaChi =""

    $scope.LoadVanChuyen = function () {
        var token = localStorage.getItem('token');
        
        $http({
            method: 'POST',
            url:"https://localhost:44304/api/VanChuyen/search-VanChuyen",
            data:
                { 
                  page: 1,
                  pageSize: $scope.pageSize,
                  tenKH: $scope.tenKH,
                  diaChi: $scope.diaChi 
                }
           
        }).
        
        then(function (response) {
            $scope.danhsachVanChuyen= response.data.data;
            console.log($scope.getAll_VanChuyen);
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

    $scope.deleteVanChuyen_byID=function(maVC)
    {
        $http({
            method:"DELETE",
            url:urlPort+"VanChuyen/delete-VanChuyen?id="+maVC
            
        }).then(function()
        {
           alert("Xóa thành công")
           $scope.getAll_VanChuyen();

        }).catch(function()
        {
            alert("Xóa thất bại")
        })
    }

    $scope.deleteSelected = function () {
        var selectedVanChuyen= $scope.danhsachVanChuyen.filter(function (x) {
            return x.selected;
        });
    
        var selectedMaVanChuyen = selectedVanChuyen.map(function (x) {
            return x.maVanChuyen;
        });
    
        if (selectedMaVanChuyen.length === 0) {
            alert("Vui lòng chọn ít nhất một vận chuyển để xóa.");
            return;
        }
    
        var maVanChuyenString = selectedMaVanChuyen.join(',');
    
        var result = confirm("Bạn có thực sự muốn xóa các vận chuyển đã chọn không?");
        if (result) {
            $http({

                method: 'POST',
                url: "https://localhost:44304/api/VanChuyen/deleteMultiple-VanChuyen",
                data: { MaVanChuyen: maVanChuyenString },
                headers: { 'Content-type': 'application/json' }
            })
    
            .then(function (response) {
                console.log(response.data);  // In thông tin phản hồi từ API
                $scope.getAll_VanChuyen();
                alert('Đã xóa ' + selectedVanChuyen.length + ' vận chuyển.');
            });
        }
    };
    
    $scope.add_VanChuyen=function()
    {
        $scope.showFormQL_VanChuyen=true;
        
        $scope.titleForm="Thêm mới vận chuyển"
    }
    $scope.save=function()
    {
        var objVanChuyen={
            "maVanChuyen" :$scope.maVanChuyen,
            "tenKH":$scope.tenKH,
            "sdt":$scope.sdt,
            "diaChi":$scope.diaChi,
            "phuongThucVanChuyen":$scope.phuongThucVanChuyen,
            "phuongThucThanhToan": $scope.phuongThucThanhToan
        }

        if($scope.titleForm==="Thêm mới vận chuyển")
        {
            $http(
                {
                    method:"POST",
                    url:urlPort+"VanChuyen/create-VanChuyen",
                    data:objVanChuyen
                }
            ).then(function(reponse)
            {
                alert("Thêm thành công vận chuyển")
                $scope.getAll_VanChuyen()
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
                    url:urlPort+"VanChuyen/update-VanChuyen",
                    data:objVanChuyen
                }
            ).then(function(reponse)
            {
                alert("Sửa thành công vận chuyển và thông tin")
                $scope.getAll_VanChuyen()
            })
            .catch(function(error)
            {
                alert("Thất bại hãy thử lại !")
            })
        }
    }

    $scope.editVanChuyen=function(x)
    {
        $scope.showFormQL_VanChuyen=true;
        
        $scope.titleForm="Sửa thông tin vận chuyển";

        $scope.maVanChuyen=x.maVanChuyen
        $scope.tenKH=x.tenKH
        $scope.sdt=x.sdt
        $scope.diaChi=x.diaChi
        $scope.phuongThucVanChuyen=x.phuongThucVanChuyen
        $scope.phuongThucThanhToan=x.phuongThucThanhToan
    }
    $scope.outForm=function()
    {
        $scope.showFormQL_VanChuyen=false;

        $scope.maVanChuyen=null
        $scope.tenKH=null
        $scope.sdt=null
        $scope.diaChi=null
        $scope.phuongThucVanChuyen=null
        $scope.phuongThucThanhToan=null
    }
})
