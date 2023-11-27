var modal3 = document.getElementById("myModal3");
var btn3 = document.getElementById("eyesa3");
var span3 = document.getElementsByClassName("close3")[0];

btn3.onclick = function() {
    modal3.style.display = "block";
}

span3.onclick = function() {
    modal3.style.display = "none";
}

window.onclick = function(event) {
    if (event.target == modal3) {
        modal3.style.display = "none";
    }
}