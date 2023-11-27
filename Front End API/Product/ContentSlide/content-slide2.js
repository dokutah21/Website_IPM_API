let slideIndex2 = 1;
showSlides3(slideIndex2, 2);

function plusSlides2(n) {
  showSlides3((slideIndex2 += n), 2);
}

function currentSlide2(n) {
  showSlides3((slideIndex2 = n), 2);
}

function showSlides3(n, modalNumber) {
  let i;
  let slides = document.getElementsByClassName("mySlides1");
  let dots = document.getElementsByClassName("demo");
  if (n > slides.length) {
    slideIndex2 = 1;
  }
  if (n < 1) {
    slideIndex2 = slides.length;
  }
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex2 - 1].style.display = "block";
  dots[slideIndex2 - 1].className += " active";
}
