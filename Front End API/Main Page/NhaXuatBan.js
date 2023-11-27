appAGL=angular.module("nhaxuatbanModule",[])
const urlPort="https://localhost:44304/api/";
appAGL.controller("nhaxuatbanCtrl",function($scope,$http)
{
    $scope.getAll_NXB=function()
    {
        $http({
            method:"GET",
            url:urlPort+"NhaXuatBan/GetAll_NhaXuatBan"
            
        }).then(function(reponse)
        {
            $scope.danhsachNXB=reponse.data
            console.log(reponse.data);
        })
    }
    $scope.getAll_NXB();

    $scope.begin = 0;
    $scope.page = 1;
    $scope.pageSize = 7; // Số lượng mục trên mỗi trang
    $scope.pageCount;
    $scope.prop ='gia';

    $scope.repaginate = function()
    {
        $scope.begin = 0;
        $scope.pageCount = Math.ceil($scope.getAll_NXB.length / $scope.pageSize);
    }

    $scope.tenNXB=""

    $scope.LoadNXB = function () {
        var token = localStorage.getItem('token');
        
        $http({
            method: 'POST',
            url:"https://localhost:44304/api/NhaXuatBan/search-NhaXuatBan",
            data:
                { 
                  page: 1,
                  pageSize: $scope.pageSize,
                  tenNXB: $scope.tenNXB
                }
           
        }).
        
        then(function (response) {
            $scope.danhsachNXB= response.data.data;
            console.log($scope.getAll_NXB);
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


    $scope.deleteNXB_byID=function(maNhaXuatBan)
    {
        $http({
            method:"DELETE",
            url:urlPort+"NhaXuatBan/delete-NhaXuatBan?id="+maNhaXuatBan
            
        }).then(function()
        {
           alert("Xóa thành công")
           $scope.getAll_NXB();

        }).catch(function()
        {
            alert("Xóa thất bại")
        })
    }

    $scope.deleteSelected = function () {
        var selectedNXB = $scope.danhsachNXB.filter(function (x) {
            return x.selected;
        });
    
        var selectedMaNXB = selectedNXB.map(function (x) {
            return x.maNXB;
        });
    
        if (selectedMaNXB.length === 0) {
            alert("Vui lòng chọn ít nhất một nhà xuất bản để xóa.");
            return;
        }
    
        // Chuyển danh sách mã sản phẩm thành chuỗi dạng '1,2,3'
        var maNXBString = selectedMaNXB.join(',');
    
        var result = confirm("Bạn có thực sự muốn xóa các nhà xuất bản đã chọn không?");
        if (result) {
            $http({
                method: 'POST',
                url: "https://localhost:44304/api/NhaXuatBan/deleteMultiple-NXB",
                data: { MaNXB: maNXBString },  // Truyền danh sách mã sản phẩm qua body
                headers: { 'Content-type': 'application/json' }
            })
    
            .then(function (response) {
                console.log(response.data);  // In thông tin phản hồi từ API
                $scope.getAll_NXB();
                alert('Đã xóa ' + selectedNXB.length + ' nhà xuất bản.');
            });
        }
    };;

    
    $scope.add_NXB=function()
    {
        $scope.showFormQL_NXB=true;
        
        $scope.titleForm="Thêm mới nhà xuất bản"
    }
    $scope.save=function()
    {
        var objNhaXuatBan={
            "maNXB": $scope.maNXB,
            "tenNXB":$scope.tenNXB,
            "diaChi":$scope.diaChi,
            "soDienThoai":$scope.soDienThoai
        }

        if($scope.titleForm==="Thêm mới nhà xuất bản")
        {
            $http(
                {
                    method:"POST",
                    url:urlPort+"NhaXuatBan/create-NhaXuatBan",
                    data:objNhaXuatBan
                }
            ).then(function(reponse)
            {
                alert("Thêm thành công nhà xuất bản")
                $scope.getAll_NXB()
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
                    url:urlPort+"NhaXuatBan/update-NhaXuatBan",
                    data:objNhaXuatBan
                }
            ).then(function(reponse)
            {
                alert("Sửa thành công nhà xuất bản và thông tin")
                $scope.getAll_NXB()
            })
            .catch(function(error)
            {
                alert("Thất bại hãy thử lại !")
            })
        }
    }

    $scope.editNXB=function(x)
    {
        $scope.showFormQL_NXB=true;
        
        $scope.titleForm="Sửa thông tin nhà xuất bản";

        $scope.maNXB=x.maNXB
        $scope.tenNXB=x.tenNXB
        $scope.diaChi=x.diaChi
        $scope.soDienThoai=x.soDienThoai
    }
    $scope.outForm=function()
    {
        $scope.showFormQL_NXB=false;

        $scope.maNXB=null
        $scope.tenNXB=null
        $scope.diaChi=null
        $scope.soDienThoai=null
    }
})
