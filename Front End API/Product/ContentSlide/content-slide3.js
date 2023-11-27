let slideIndex3 = 1;
showSlides4(slideIndex3, 2);

function plusSlides3(n) {
  showSlides4((slideIndex3 += n), 2);
}

function currentSlide3(n) {
  showSlides4((slideIndex3 = n), 2);
}

function showSlides4(n, modalNumber) {
  let i;
  let slides = document.getElementsByClassName("mySlides2");
  let dots = document.getElementsByClassName("demo");
  if (n > slides.length) {
    slideIndex3 = 1;
  }
  if (n < 1) {
    slideIndex3 = slides.length;
  }
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex3 - 1].style.display = "block";
  dots[slideIndex3 - 1].className += " active";
}
