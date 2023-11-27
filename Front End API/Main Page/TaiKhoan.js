appAGL=angular.module("taikhoanModule",[])
const urlPort="https://localhost:44304/api/";
appAGL.controller("taikhoanCtrl",function($scope,$http)
{
    $scope.getAll_TaiKhoan=function()
    {
        $http({
            method:"GET",
            url:urlPort+"TaiKhoan/GetAll_TaiKhoan"
            
        }).then(function(reponse)
        {
            $scope.danhsachTaiKhoan=reponse.data
            console.log(reponse.data);
        })
    }
    $scope.getAll_TaiKhoan();

    $scope.begin = 0;
    $scope.page = 1;
    $scope.pageSize = 7; // Số lượng mục trên mỗi trang
    $scope.pageCount;
    $scope.prop ='gia';

    $scope.repaginate = function()
    {
        $scope.begin = 0;
        $scope.pageCount = Math.ceil($scope.getAll_TaiKhoan.length / $scope.pageSize);
    }

    $scope.tenTaiKhoan=""

    $scope.LoadTaiKhoan = function () {
        var token = localStorage.getItem('token');
        
        $http({
            method: 'POST',
            url:"https://localhost:44304/api/TaiKhoan/search-TaiKhoan",
            data:
                { 
                  page: 1,
                  pageSize: $scope.pageSize,
                  tenTaiKhoan: $scope.tenTaiKhoan
                }
           
        }).
        
        then(function (response) {
            $scope.danhsachTaiKhoan= response.data.data;
            console.log($scope.getAll_TaiKhoan);
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


    $scope.deleteTaiKhoan_byID=function(maTaiKhoan)
    {
        $http({
            method:"DELETE",
            url:urlPort+"TaiKhoan/delete-TaiKhoan?id="+maTaiKhoan
            
        }).then(function()
        {
           alert("Xóa thành công")
           $scope.getAll_TaiKhoan();

        }).catch(function()
        {
            alert("Xóa thất bại")
        })
    }

    $scope.deleteSelected = function () {
        var selectedTaiKhoan= $scope.danhsachTaiKhoan.filter(function (x) {
            return x.selected;
        });
    
        var selectedMaTK = selectedTaiKhoan.map(function (x) {
            return x.maTK;
        });
    
        if (selectedMaTK.length === 0) {
            alert("Vui lòng chọn ít nhất một tài khoản để xóa.");
            return;
        }
    
        var maTKString = selectedMaTK.join(',');
    
        var result = confirm("Bạn có thực sự muốn xóa các tài khoản đã chọn không?");
        if (result) {
            $http({

                method: 'POST',
                url: "https://localhost:44304/api/TaiKhoan/deleteMultiple-TaiKhoan",
                data: { MaTK: maTKString },
                headers: { 'Content-type': 'application/json' }
            })
    
            .then(function (response) {
                console.log(response.data);  // In thông tin phản hồi từ API
                $scope.getAll_TaiKhoan();
                alert('Đã xóa ' + selectedTaiKhoan.length + ' tài khoản.');
            });
        }
    };



    
    $scope.add_TaiKhoan=function()
    {
        $scope.showFormQL_TaiKhoan=true;
        
        $scope.titleForm="Thêm mới tài khoản"
    }
    $scope.save=function()
    {
        var objTaiKhoan={
            "maTK": $scope.maTK,
            "maLoai": $scope.maLoai,
            "tenTaiKhoan":$scope.tenTaiKhoan,
            "matKhau":$scope.matKhau,
            "email":$scope.email
        }

        if($scope.titleForm==="Thêm mới tài khoản")
        {
            $http(
                {
                    method:"POST",
                    url:urlPort+"TaiKhoan/create-TaiKhoan",
                    data:objTaiKhoan
                }
            ).then(function(reponse)
            {
                alert("Thêm thành công tài khoản")
                $scope.getAll_TaiKhoan()
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
                    url:urlPort+"TaiKhoan/update-TaiKhoan",
                    data:objTaiKhoan
                }
            ).then(function(reponse)
            {
                alert("Sửa thành công tài khoản và thông tin")
                $scope.getAll_TaiKhoan()
            })
            .catch(function(error)
            {
                alert("Thất bại hãy thử lại !")
            })
        }
    }

    $scope.editTaiKhoan=function(x)
    {
        $scope.showFormQL_TaiKhoan=true;
        
        $scope.titleForm="Sửa thông tin tài khoản";
        $scope.maTK= x.maTK
        $scope.maLoai=x.maLoai
        $scope.tenTaiKhoan=x.tenTaiKhoan
        $scope.matKhau=x.matKhau
        $scope.email=x.email
    }
    $scope.outForm=function()
    {
        $scope.showFormQL_TaiKhoan=false;

        $scope.maTK=null
        $scope.maLoai=null
        $scope.tenTaiKhoan=null
        $scope.matKhau=null
        $scope.email=null
    }
})
