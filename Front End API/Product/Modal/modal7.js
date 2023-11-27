var modal7 = document.getElementById("myModal7");
var btn7 = document.getElementById("eyesa7");
var span7 = document.getElementsByClassName("close7")[0];

btn7.onclick = function() {
    modal7.style.display = "block";
}

span7.onclick = function() {
    modal7.style.display = "none";
}

window.onclick = function(event) {
    if (event.target == modal7) {
        modal7.style.display = "none";
    }
}