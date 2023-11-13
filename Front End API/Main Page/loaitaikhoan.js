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
            console.log*reponse.data
        })
    }
    $scope.getAll_LTK();
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