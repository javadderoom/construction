$(document).ready(function () {
    (function ($) {
        "use strict";
        /*PreLoader*/
        $(".loader-item").delay(700).fadeOut();
        $("#pageloader").delay(800).fadeOut("slow");

        /*NiceScroll*/
        $("html").niceScroll({
            cursorcolor: "#293133",
            cursorborderradius: "0",
            cursorborder: "0 solid #fff",
            cursorwidth: "15px",
            zindex: "999999",
            scrollspeed: 60
        });
        $('#ContentPlaceHolder1_fileImage').change(function () {
            var filename = $(this).val();
            var lastIndex = filename.lastIndexOf("\\");
            if (lastIndex >= 0) {
                filename = filename.substring(lastIndex + 1);
            }
            $('#imageName').html(filename);
        });
        //equal height

        $('#ContentPlaceHolder1_fileResume').change(function () {
            var filename = $(this).val();
            var lastIndex = filename.lastIndexOf("\\");
            if (lastIndex >= 0) {
                filename = filename.substring(lastIndex + 1);
            }
            $('#filename').html(filename);
        });
        var options = {
            trigger: 'focus'
        }
        if ($(window).width() < 768) {
            $(document).ready(function () {
                $('[data-toggle="popover"]').popover(options);
            });
        }
        if ($(window).width() >= 768) {
            $('[data-toggle="popover"]').popover({ trigger: "manual", html: true, animation: false })
            .on("mouseenter", function () {
                var _this = this;
                $(this).popover("show");
                $(".popover").on("mouseleave", function () {
                    $(_this).popover('hide');
                });
            }).on("mouseleave", function () {
                var _this = this;
                setTimeout(function () {
                    if (!$(".popover:hover").length) {
                        $(_this).popover("hide");
                    }
                }, 300);
            });
        }
        $(document).click(function (event) {
            if (!$(event.target).closest('#btnProfilePopover').length && !$(event.target).closest('#myPopoverContent').length) {
                if ($('#myPopoverContent').is(":visible")) {
                    $('#myPopoverContent').hide();
                }
            }
            //else {
            //    var x = document.getElementById("myPopoverContent");

            //    if (x.style.display === "none") {
            //        x.style.display = "block";
            //    } else {
            //        x.style.display = "none";
            //    }
            //}
        });
        $('#btnProfilePopover').click(function () {
            var x = document.getElementById("myPopoverContent");

            if (x.style.display === "none") {
                x.style.display = "block";
            } else {
                x.style.display = "none";
            }
        })
        function displayFunction() {
        }
        /*Go Top*/
        $('a[href="#top"]').click(function () {
            $('html, body').animate({ scrollTop: 0 }, 800);
            return false
        });

        /*Project Filter*/
        $(".projects").mixItUp({
            animation: {
                effects: 'fade scale(0)'
            },
            layout: {},
            selectors: {
                target: ".project"
            },
            load: {
                filter: 'all',
                sort: 'random:asc'
            }
        });

        /*TweetSlider Slider*/
        $('.twitterSlide .twitterSlider').owlCarousel({
            loop: true,
            margin: 0,
            nav: true,
            items: 1,
            dots: false,
            lazyLoad: true,
            autoplay: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>']
        });

        /*Testimonial Slider*/
        //$('.testimonialSlider').owlCarousel({
        //    loop: true,
        //    margin: 0,
        //    nav: false,
        //    items: 3,
        //    dots: false,
        //    lazyLoad: true,
        //    autoplay: false
        //});

        /*ParterSlider*/
        $('.partnerSlider').owlCarousel({
            loop: true,
            margin: 10,
            responsiveClass: true,
            nav: true,
            navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
            autoplay: true,
            responsive: {
                0: {
                    items: 1,
                    nav: true
                },
                600: {
                    items: 2,
                    nav: false
                },
                1000: {
                    items: 3,
                    nav: true,
                    loop: false
                }
            }
        });

        /*Rev Slider*/
        jQuery('.mainSlider').revolution({
            delay: 9000,
            startwidth: 960,
            startheight: 660,
            startWithSlide: 0,

            fullScreenAlignForce: "off",
            autoHeight: "off",
            minHeight: "off",

            shuffle: "off",

            onHoverStop: "on",

            thumbWidth: 100,
            thumbHeight: 50,
            thumbAmount: 3,

            hideThumbsOnMobile: "off",
            hideNavDelayOnMobile: 1500,
            hideBulletsOnMobile: "off",
            hideArrowsOnMobile: "off",
            hideThumbsUnderResoluition: 0,

            hideThumbs: 0,
            hideTimerBar: "off",

            keyboardNavigation: "on",

            navigationType: "bullet",
            navigationArrows: "solo",
            navigationStyle: "round-old",

            navigationHAlign: "center",
            navigationVAlign: "bottom",
            navigationHOffset: 30,
            navigationVOffset: 30,

            soloArrowLeftHalign: "left",
            soloArrowLeftValign: "bottom",
            soloArrowLeftHOffset: 0,
            soloArrowLeftVOffset: 0,

            soloArrowRightHalign: "right",
            soloArrowRightValign: "bottom",
            soloArrowRightHOffset: 0,
            soloArrowRightVOffset: 0,

            touchenabled: "on",
            swipe_velocity: "0.7",
            swipe_max_touches: "1",
            swipe_min_touches: "1",
            drag_block_vertical: "false",

            parallax: "mouse",
            parallaxBgFreeze: "on",
            parallaxLevels: [10, 7, 4, 3, 2, 5, 4, 3, 2, 1],
            parallaxDisableOnMobile: "off",

            stopAtSlide: -1,
            stopAfterLoops: -1,
            hideCaptionAtLimit: 0,
            hideAllCaptionAtLilmit: 0,
            hideSliderAtLimit: 0,

            dottedOverlay: "none",

            spinned: "spinner4",

            fullWidth: "off",
            forceFullWidth: "off",
            fullScreen: "off",
            fullScreenOffsetContainer: "#topheader-to-offset",
            fullScreenOffset: "0px",
            panZoomDisableOnMobile: "off",

            simplifyAll: "off",

            shadow: 0
        })
    })(jQuery)
});
