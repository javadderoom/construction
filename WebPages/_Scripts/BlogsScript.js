
$('#easyPaginate').easyPaginate({
    paginateElement: 'li', firstButtonText: "اولین صفحه", lastButtonText: "آخرین صفحه", prevButtonText: "قبلی", nextButtonText: "بعدی",
    elementsPerPage: 6,
    effect: 'fade',
});

$('a').click(function () {

    myFunction();
})

function setMargins() {

    width = $(".container").width();
    containerWidth = $(".easyPaginateNav").width();
    leftMargin = (width - containerWidth) / 2;
    $(".easyPaginateNav").css("marginLeft", leftMargin);
}
function myFunction() {
    var lastone = $('.next').prev().attr('rel');


    $(".prev").nextUntil('div').css("display", "inline-block");
    $('.leftSide').removeClass('leftSide');
    $('.rightSide').removeClass('rightSide');
    var selected = $(".current").attr("rel");

    if ((selected - 3) > 1) {
        var g = selected - 3;
        $("a[rel='" + g + "']").addClass('leftSide');
        $(".prev").nextUntil('.leftSide').css("display", "none");

    }


    if ((lastone - selected) > 3) {
        var f = parseInt(selected) + 3;
        $("a[rel='" + f + "']").addClass('rightSide');

        $(".next").prevUntil('.rightSide').css("display", "none");
    }


}

$(document).ready(function () {

    setMargins();
    $(window).resize(function () {
        setMargins();
    });
    myFunction();
});
function run() {
    $('#easyPaginate').easyPaginate({
        paginateElement: 'li', firstButtonText: "اولین صفحه", lastButtonText: "آخرین صفحه", prevButtonText: "قبلی", nextButtonText: "بعدی",
        elementsPerPage: 6,
        effect: 'fade',
    });
    var lastone = $('.next').prev().attr('rel');
}
$(window).scroll(function () {
    myFunction();
});
var prm = Sys.WebForms.PageRequestManager.getInstance();

prm.add_endRequest(function () {
    function setMargins() {

        width = $(".container").width();
        containerWidth = $(".easyPaginateNav").width();
        leftMargin = (width - containerWidth) / 2;
        $(".easyPaginateNav").css("marginLeft", leftMargin);
    }
    function myFunction() {
        var lastone = $('.next').prev().attr('rel');


        $(".prev").nextUntil('div').css("display", "inline-block");
        $('.leftSide').removeClass('leftSide');
        $('.rightSide').removeClass('rightSide');
        var selected = $(".current").attr("rel");

        if ((selected - 3) > 1) {
            var g = selected - 3;
            $("a[rel='" + g + "']").addClass('leftSide');
            $(".prev").nextUntil('.leftSide').css("display", "none");

        }


        if ((lastone - selected) > 3) {
            var f = parseInt(selected) + 3;
            $("a[rel='" + f + "']").addClass('rightSide');

            $(".next").prevUntil('.rightSide').css("display", "none");
        }


    }
    $('a').click(function () {

        myFunction();
    })
    $(window).scroll(function () {
        myFunction();
    });

});