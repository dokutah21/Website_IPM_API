var modal12 = document.getElementById("myModal12");
var btn12 = document.getElementById("eyesa12");
var span12 = document.getElementsByClassName("close12")[0];

btn12.onclick = function() {
    modal12.style.display = "block";
}

span12.onclick = function() {
    modal12.style.display = "none";
}

window.onclick = function(event) {
    if (event.target == modal12) {
        modal12.style.display = "none";
    }
}