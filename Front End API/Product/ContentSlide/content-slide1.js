let slideIndex1 = 1;
showSlides2(slideIndex1, 2);

function plusSlides1(n) {
  showSlides2((slideIndex1 += n), 2);
}

function currentSlide1(n) {
  showSlides2((slideIndex1 = n), 2);
}

function showSlides2(n) {
  let i;
  let slides = document.getElementsByClassName("mySlide");
  let dots = document.getElementsByClassName("demo");
  if (n > slides.length) {slideIndex1 = 1}
  if (n < 1) {slideIndex1 = slides.length}
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex1-1].style.display = "block";
  dots[slideIndex1-1].className += " active";
}