myapp=angular.module("myapp",[])
myapp.controller("loginCtrl",function($scope,$http)
{
    
    $scope.login_=function()
    {
        
        $http(
            {
                method:"POST",
                url:'https://localhost:44304/api/Login/Login',
                data:{
                    "username": $scope.user_name,
                    "password": $scope.password
                  }
            }).then(function(reponse)
            {
                console.log(reponse.data)
                localStorage.setItem("user",JSON.stringify(reponse.data))
                var user_role=reponse.data.role
                
                alert("Đăng nhập thành công")
                console.log(user_role)
                location.href=user_role===1?'/Main Page/MainPage.html':'/Trang chủ/style.html'
            }).catch(function(error)
              {
                alert("Thông tin tài khoản hoặc mật khẩu không chính xác !")
               console.log(error.data)
              })
        
    }
   
})