let slideIndex5 = 1;
showSlides6(slideIndex5, 2);

function plusSlides5(n) {
  showSlides6((slideIndex5 += n), 2);
}

function currentSlide5(n) {
  showSlides6((slideIndex5 = n), 2);
}

function showSlides6(n, modalNumber) {
  let i;
  let slides = document.getElementsByClassName("mySlides4");
  let dots = document.getElementsByClassName("demo");
  if (n > slides.length) {
    slideIndex5 = 1;
  }
  if (n < 1) {
    slideIndex5 = slides.length;
  }
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex5 - 1].style.display = "block";
  dots[slideIndex5 - 1].className += " active";
}
