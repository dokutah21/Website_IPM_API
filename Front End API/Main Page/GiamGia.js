appAGL=angular.module("giamgiaModule",[])
const urlPort="https://localhost:44304/api/";
appAGL.controller("giamgiaCtrl",function($scope,$http)
{
    $scope.getAll_GiamGia=function()
    {
        $http({
            method:"GET",
            url:urlPort+"GiamGia/GetAll_GiamGia"
            
        }).then(function(reponse)
        {
            $scope.danhsachGiamGia=reponse.data
            console.log*reponse.data
        })
    }
    $scope.getAll_GiamGia();

    $scope.begin = 0;
    $scope.page = 1;
    $scope.pageSize = 7; // Số lượng mục trên mỗi trang
    $scope.pageCount;
    $scope.prop ='gia';

    $scope.repaginate = function()
    {
        $scope.begin = 0;
        $scope.pageCount = Math.ceil($scope.getAll_GiamGia.length / $scope.pageSize);
    }

    $scope.tenMaGiamGia=""
    $scope.soTienGiam =""

    $scope.LoadGiamGia = function () {
        var token = localStorage.getItem('token');
        
        $http({
            method: 'POST',
            url:"https://localhost:44304/api/GiamGia/search-GiamGia",
            data:
                { 
                  page: 1,
                  pageSize: $scope.pageSize,
                  tenMaGiamGia: $scope.tenMaGiamGia,
                  soTienGiam: $scope.soTienGiam 
                }
           
        }).
        
        then(function (response) {
            $scope.danhsachGiamGia= response.data.data;
            console.log($scope.getAll_GiamGia);
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

    $scope.deleteGiamGia_byID=function(maGG)
    {
        $http({
            method:"DELETE",
            url:urlPort+"GiamGia/delete-GiamGia?id="+maGG
            
        }).then(function()
        {
           alert("Xóa thành công")
           $scope.getAll_GiamGia();

        }).catch(function()
        {
            alert("Xóa thất bại")
        })
    }

    $scope.deleteSelected = function () {
        var selectedGiamGia= $scope.danhsachGiamGia.filter(function (x) {
            return x.selected;
        });
    
        var selectedMaGiamGia = selectedGiamGia.map(function (x) {
            return x.maGiamGia;
        });
    
        if (selectedMaGiamGia.length === 0) {
            alert("Vui lòng chọn ít nhất một mã giảm để xóa.");
            return;
        }
    
        var maGiamGiaString = selectedMaGiamGia.join(',');
    
        var result = confirm("Bạn có thực sự muốn xóa các mã giảm đã chọn không?");
        if (result) {
            $http({

                method: 'POST',
                url: "https://localhost:44304/api/GiamGia/deleteMultiple-GiamGia",
                data: { MaGiamGia: maGiamGiaString },
                headers: { 'Content-type': 'application/json' }
            })
    
            .then(function (response) {
                console.log(response.data);  // In thông tin phản hồi từ API
                $scope.getAll_GiamGia();
                alert('Đã xóa ' + selectedGiamGia.length + ' mã giảm giá.');
            });
        }
    };

    
    $scope.add_GiamGia=function()
    {
        $scope.showFormQL_GiamGia=true;
        
        $scope.titleForm="Thêm mới giảm giá"
    }
    $scope.save=function()
    {
        var objGiamGia={
            "maGiamGia": $scope.maGiamGia,
            "tenMaGiamGia": $scope.tenMaGiamGia,
            "noiDungMaGiamGia": $scope.noiDungMaGiamGia,
            "thoiGianBatDau": $scope.thoiGianBatDau,
            "thoiGianKetThuc": $scope.thoiGianKetThuc,
            "soLuongMa": $scope.soLuongMa,
            "soTienGiam": $scope.soTienGiam,
            "trangThai": $scope.trangThai,
        }
        if($scope.titleForm==="Thêm mới giảm giá")
        {
            $http(
                {
                    method:"POST",
                    url:urlPort+"GiamGia/create-GiamGia",
                    data:objGiamGia
                }
            ).then(function(reponse)
            {
                alert("Thêm thành công mã giảm giá")
                $scope.getAll_GiamGia()
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
                    url:urlPort+"GiamGia/update-GiamGia",
                    data:objGiamGia
                }
            ).then(function(reponse)
            {
                alert("Sửa thành công mã giảm giá và thông tin")
                $scope.getAll_GiamGia()
            })
            .catch(function(error)
            {
                alert("Thất bại hãy thử lại !")
            })
        }
    }

    $scope.editGiamGia=function(x)
    {
        $scope.showFormQL_GiamGia=true;
        
        $scope.titleForm="Sửa thông tin mã giảm giá";
        $scope.maGiamGia=x.maGiamGia
        $scope.tenMaGiamGia=x.tenMaGiamGia
        $scope.noiDungMaGiamGia=x.noiDungMaGiamGia
        $scope.thoiGianBatDau=x.thoiGianBatDau
        $scope.thoiGianKetThuc=x.thoiGianKetThuc
        $scope.soLuongMa=x.soLuongMa
        $scope.soTienGiam=x.soTienGiam
        $scope.trangThai=x.trangThai
    }
    $scope.outForm=function()
    {
        $scope.showFormQL_GiamGia=false;

        $scope.maGiamGia=null
        $scope.tenMaGiamGia=null
        $scope.noiDungMaGiamGia=null
        $scope.thoiGianBatDau=null
        $scope.thoiGianKetThuc=null
        $scope.soLuongMa=null
        $scope.soTienGiam=null
        $scope.trangThai=null
    }
})
