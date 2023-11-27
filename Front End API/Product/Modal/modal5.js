var modal5 = document.getElementById("myModal5");
var btn5 = document.getElementById("eyesa5");
var span5 = document.getElementsByClassName("close5")[0];

btn5.onclick = function() {
    modal5.style.display = "block";
}

span5.onclick = function() {
    modal5.style.display = "none";
}

window.onclick = function(event) {
    if (event.target == modal5) {
        modal5.style.display = "none";
    }
}