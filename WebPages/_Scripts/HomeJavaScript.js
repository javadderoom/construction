$(document).ready(function () {
    //Check to see if the window is top if not then display button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 180) {
            $('.scrollToTop').fadeIn();
        } else {
            $('.scrollToTop').fadeOut();
        }
    });

    //Click event to scroll to top
    $('.scrollToTop').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 800);
        return false;
    });
});

//$(document).ready(function () {
//    $(window).scroll(function () {
//        if ($(document).scrollTop() > 41) {
//            $("#fixme").addClass("fixclass");
//        } else {
//            $("#fixme").removeClass("fixclass");
//        }
//    });
//});