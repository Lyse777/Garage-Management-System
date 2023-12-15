$(document).ready(function () {
    $('#carouselExampleControls').carousel({
        interval: 3000 // 3 seconds
    });

    $('.carousel-control-prev').click(function () {
        $('#carouselExampleControls').carousel('prev');
    });

    $('.carousel-control-next').click(function () {
        $('#carouselExampleControls').carousel('next');
    });



});
