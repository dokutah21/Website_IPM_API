appAGL=angular.module("loaitaikhoanModule",[])
const urlPort="https://localhost:44304/api/";
appAGL.controller("loaitaikhoanCtrl",function($scope,$http)
{
    $scope.getAll_LTK=function()
    {
        $http({
            method:"GET",
            url:urlPort+"LoaiTaiKhoan/GetAll_LTK"
            
        }).then(function(reponse)
        {
            $scope.danhsachLTK=reponse.data
            console.log(reponse.data);
        });
    };
    $scope.getAll_LTK();

    $scope.begin = 0;
    $scope.page = 1;
    $scope.pageSize = 7; // Số lượng mục trên mỗi trang
    $scope.pageCount;
    $scope.prop ='gia';

    $scope.repaginate = function()
    {
        $scope.begin = 0;
        $scope.pageCount = Math.ceil($scope.getAll_LTK.length / $scope.pageSize);
    }

    $scope.phanQuyen=""
    $scope.tenChucDanh =""

    $scope.LoadLTK = function () {
        var token = localStorage.getItem('token');
        
        $http({
            method: 'POST',
            url:"https://localhost:44304/api/LoaiTaiKhoan/search-LoaiTaiKhoan",
            data:
                { 
                  page: 1,
                  pageSize: $scope.pageSize,
                  phanQuyen: $scope.phanQuyen,
                  tenChucDanh: $scope.tenChucDanh 
                }
           
        }).
        
        then(function (response) {
            $scope.danhsachLTK= response.data.data;
            console.log($scope.getAll_LTK);
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


    $scope.deleteTK_byID=function(maLoaiTK)
    {
        $http({
            method:"DELETE",
            url:urlPort+"LoaiTaiKhoan/delete-LoaiTaiKhoan?id="+maLoaiTK
            
        }).then(function()
        {
           alert("Xóa thành công")
           $scope.getAll_LTK();

        }).catch(function()
        {
            alert("Xóa thất bại")
        })
    }

    $scope.deleteSelected = function () {
        var selectedLoaiTaiKhoan = $scope.danhsachLTK.filter(function (x) {
            return x.selected;
        });
    
        var selectedMaLoai = selectedLoaiTaiKhoan.map(function (x) {
            return x.maLoai;
        });
    
        if (selectedMaLoai.length === 0) {
            alert("Vui lòng chọn ít nhất một loại tài khoản để xóa.");
            return;
        }
    
        // Chuyển danh sách mã sản phẩm thành chuỗi dạng '1,2,3'
        var maLoaiString = selectedMaLoai.join(',');
    
        var result = confirm("Bạn có thực sự muốn xóa các loại tài khoản đã chọn không?");
        if (result) {
            $http({
                method: 'POST',
                url: "https://localhost:44304/api/LoaiTaiKhoan/deleteMultiple-LoaiTaiKhoan",
                data: { MaLoai: maLoaiString },  
                headers: { 'Content-type': 'application/json' }
            })
    
            .then(function (response) {
                console.log(response.data);  // In thông tin phản hồi từ API
                $scope.getAll_LTK();
                alert('Đã xóa ' + selectedLoaiTaiKhoan.length + ' loại tài khoản.');
            });
        }
    };;

    $scope.add_LTK=function()
    {
        $scope.showFormQL_LTK=true;
        
        $scope.titleForm="Thêm mới loại tài khoản"
    }
    $scope.save=function()
    {
        var objLTK={
            "maLoai": $scope.maLoai,
            "phanQuyen": $scope.phanQuyen,
            "tenChucDanh": $scope.tenChucDanh
        }
        if($scope.titleForm==="Thêm mới loại tài khoản")
        {
            $http(
                {
                    method:"POST",
                    url:urlPort+"LoaiTaiKhoan/create-LoaiTaiKhoan",
                    data:objLTK
                }
            ).then(function(reponse)
            {
                alert("Thêm thành công tài khoản ")
                $scope.getAll_LTK()
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
                    url:urlPort+"LoaiTaiKhoan/update-LoaiTaiKhoan",
                    data:objLTK
                }
            ).then(function(reponse)
            {
                alert("Sửa thành công tài khoản với thông tin")
                $scope.getAll_LTK()
            })
            .catch(function(error)
            {
                alert("Thất bại hãy thử lại !")
            })
        }
    }
    $scope.editLTK=function(x)
    {
        $scope.showFormQL_LTK=true;
        
        $scope.titleForm="Sửa thông tin loại tài khoản";
        $scope.maLoai=x.maLoai
        $scope.phanQuyen=x.phanQuyen
        $scope.tenChucDanh=x.tenChucDanh
    }
    $scope.outForm=function()
    {
        $scope.showFormQL_LTK=false;
        $scope.maLoai=null
        $scope.phanQuyen=null
        $scope.tenChucDanh=null
    }
})