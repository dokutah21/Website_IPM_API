let slideIndex4 = 1;
showSlides5(slideIndex4, 2);

function plusSlides4(n) {
  showSlides5((slideIndex4 += n), 2);
}

function currentSlide4(n) {
  showSlides5((slideIndex4 = n), 2);
}

function showSlides5(n, modalNumber) {
  let i;
  let slides = document.getElementsByClassName("mySlide3");
  let dots = document.getElementsByClassName("demo");
  if (n > slides.length) {
    slideIndex4 = 1;
  }
  if (n < 1) {
    slideIndex4 = slides.length;
  }
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex4 - 1].style.display = "block";
  dots[slideIndex4 - 1].className += " active";
}
