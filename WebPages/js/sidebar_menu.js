var CURRENT_URL = window.location.href, $SIDEBAR_MENU = $('#menu');
$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");

    $('.sid-profile').toggleClass('my-hide')
});

$("#menu-toggle-2").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled-2");
    $('#menu ul').hide();
    $('.sid-profile').slideToggle();
    $('#menu a[href="' + CURRENT_URL + '"]').parent().addClass('sub-active').parent().slideDown().parent().addClass('active');
});

$("#menu a").click(function (e) {
    if (!$(this).parent().hasClass("active") && (!$(this).hasClass("sub-menu"))) {
        $(".active").removeClass("active");
        $(this).parent().addClass("active");
    }
    else {
        //e.preventDefault();
    }
});
$(".sub-menu").click(function (e) {
    if (!$(this).parent().hasClass("sub-active")) {
        $(".sub-active").removeClass("sub-active");
        $(this).parent().addClass("sub-active");
    } else {
        //e.preventDefault();
    }
});

function initMenu() {
    $('#menu ul').hide();
    $('#menu ul').children('.current').parent().show();
    $('.sid-profile').slideToggle();
    //$('#menu ul:first').css("display","block")
    $('#menu li a').click(
      function () {
          var checkElement = $(this).next();
          if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
              return false;
          }
          if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
              $('#menu ul:visible').slideUp('normal');
              checkElement.slideDown('normal');
              return false;
          }
      }
      );
}
$(document).ready(function () {
    initMenu();
    $(".active").removeClass("active");
    $(".sub-active").removeClass("sub-active");
    $('#menu a[href="' + CURRENT_URL + '"]').parent().addClass('sub-active').parent().slideDown().parent().addClass('active');
});

//--------------------------------------------------------------