var modal6 = document.getElementById("myModal6");
var btn6 = document.getElementById("eyesa6");
var span6 = document.getElementsByClassName("close6")[0];

btn6.onclick = function() {
    modal6.style.display = "block";
}

span6.onclick = function() {
    modal6.style.display = "none";
}

window.onclick = function(event) {
    if (event.target == modal6) {
        modal6.style.display = "none";
    }
}