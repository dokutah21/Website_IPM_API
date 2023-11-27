const inputEmail = $("#customer_email");
const inputPassword = $("#customer_password");
const urlApiLogin = "https://localhost:44304/api/Login/Login";
const btnLogin = $(".btn-signIn");
 function handleLogin(){
    var data = {
        username : inputEmail.val().trim(),
        password : inputPassword.val().trim()
    };
    Login(data);
 }

 function Login(data){
    $.post({
        url:urlApiLogin,
        data:JSON.stringify(data),
        contentType:"application/json"
    })
    .done(res=>{
        console.log(res)
        localStorage.setItem("login",JSON.stringify(res))
    })
    .fail(err=>{
        console.log(err)
    })
 }

 btnLogin.on("click",()=>{
    handleLogin();
 })