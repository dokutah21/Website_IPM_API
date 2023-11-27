var modal8 = document.getElementById("myModal8");
var btn8 = document.getElementById("eyesa8");
var span8 = document.getElementsByClassName("close8")[0];

btn8.onclick = function() {
    modal8.style.display = "block";
}

span8.onclick = function() {
    modal8.style.display = "none";
}

window.onclick = function(event) {
    if (event.target == modal8) {
        modal8.style.display = "none";
    }
}