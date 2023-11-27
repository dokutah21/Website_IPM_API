var modal9 = document.getElementById("myModal9");
var btn9 = document.getElementById("eyesa9");
var span9 = document.getElementsByClassName("close9")[0];

btn9.onclick = function() {
    modal9.style.display = "block";
}

span9.onclick = function() {
    modal9.style.display = "none";
}

window.onclick = function(event) {
    if (event.target == modal9) {
        modal9.style.display = "none";
    }
}