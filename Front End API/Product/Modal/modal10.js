var modal10 = document.getElementById("myModal10");
var btn10 = document.getElementById("eyesa10");
var span10 = document.getElementsByClassName("close10")[0];

btn10.onclick = function() {
    modal10.style.display = "block";
}

span10.onclick = function() {
    modal10.style.display = "none";
}

window.onclick = function(event) {
    if (event.target == modal10) {
        modal10.style.display = "none";
    }
}