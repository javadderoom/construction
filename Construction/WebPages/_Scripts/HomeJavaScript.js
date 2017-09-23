$(document).ready(function () {
    $(".toggle").click(function () {
        $('.links').slideToggle();
    });
    $(window).resize(function () {
        if ($(window).width() > 768) {
            $('.links').show();
        } else {
            $('.links').hide();
        }
    });
});

$(document).ready(function () {
    $(window).scroll(function () {
        if ($(document).scrollTop() > 41) {
            $("#fixme").addClass("fixclass");
        } else {
            $("#fixme").removeClass("fixclass");
        }
    });
});

//var nav = $('#fixme');
//if (nav.length) {
//    var fixmeTop = $('#fixme').offset().top;       // get initial position of the element

//    window.scroll(function () {                  // assign scroll event listener
//        var currentScroll = window.scrollTop(); // get current position

//        if (currentScroll >= fixmeTop) {           // apply position: fixed if you
//            $('#fixme').css({                      // scroll to that element or below it
//                position: 'fixed',
//                top: '0',
//                left: '0'
//            });
//        } else {                                   // apply position: static
//            $('#fixme').css({                      // if you scroll above it
//                position: 'static'
//            });
//        }
//    });
//}