function openNav() {
    document.getElementById("mySidenav").style.width = "400px";
    document.getElementById("mySidenav").style.right = "0";
    document.getElementById("overlay").style.display = "block";
  }
  
  function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("mySidenav").style.right = "-400px";
    document.getElementById("overlay").style.display = "none";
  }
