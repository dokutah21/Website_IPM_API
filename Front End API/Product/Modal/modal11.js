var modal11 = document.getElementById("myModal11");
var btn11 = document.getElementById("eyesa11");
var span11 = document.getElementsByClassName("close11")[0];

btn11.onclick = function() {
    modal11.style.display = "block";
}

span11.onclick = function() {
    modal11.style.display = "none";
}

window.onclick = function(event) {
    if (event.target == modal11) {
        modal11.style.display = "none";
    }
}