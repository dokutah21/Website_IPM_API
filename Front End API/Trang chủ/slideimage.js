var index = 1;
changeImage = function () {
    var imgs = [
        "//theme.hstatic.net/200000287623/1000948667/14/slideshow_4.jpg?v=203",
        "//theme.hstatic.net/200000287623/1000948667/14/slideshow_1.jpg?v=203"
    ];
    document.getElementById('img').src = imgs[index];
    index++;
    if (index == 2);
    index = 0;
}
setInterval(changeImage, 3000);      