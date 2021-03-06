﻿<%@ Page Title="" Language="C#" MasterPageFile="~/_construction/IndexMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebPages._construction.Index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>جعبه ابزار
    </title>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="pageStyles" runat="server">
    <%--    <link href="../_Styles/slick.css" rel="stylesheet" />
    <link href="../_Styles/slick-theme.css" rel="stylesheet" />--%>
    <style>
        div.blogInner {
            max-height: 490px !important;
        }

        .tp-bullets {
            left: 48% !important;
        }
    </style>

    <link href="<%= ResolveUrl("vendors/owl.carousel/css/owl.theme.default.min.css") %>" rel="stylesheet" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <link href="<%= ResolveUrl("css/ServiseDetailsStyle.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="nr_slider" class="row">
        <div class="mainSliderContainer">
            <div class="mainSlider" style="direction: rtl;">
                <ul>

                    <!-- SLIDE  -->
                    <!-- SLIDE 1 -->
                    <li data-transition="boxslide" data-slotamount="7">
                        <img src="" alt="slidebg1" runat="server" id="bImg1" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat" />
                        <div class="caption sfr str"
                            data-x="-100"
                            data-y="135"
                            data-speed="700"
                            data-start="1700"
                            data-easing="easeOutBack">
                            <div runat="server" id="divText1"></div>
                        </div>

                        <div runat="server" id="diva1" class="caption sfb stb"
                            data-x="-100"
                            data-y="375"
                            data-hoffset="0"
                            data-speed="500"
                            data-start="1900"
                            data-easing="easeOutBack">
                        </div>
                        <div class="caption skewfromright skewtoright"
                            data-x="right"
                            data-y="130"
                            data-hoffset="176"
                            data-speed="500"
                            data-start="1900"
                            data-easing="easeOutBack">
                            <div class="tools" runat="server" id="rightPic">
                            </div>
                        </div>
                    </li>
                    <!-- SLIDE 2 -->
                    <li data-transition="boxslide" data-slotamount="7">
                        <img src="" alt="slidebg1" runat="server" id="bImg2" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat" />
                        <div class="caption sfr str"
                            data-x="-100"
                            data-y="135"
                            data-speed="700"
                            data-start="1700"
                            data-easing="easeOutBack">
                            <div runat="server" id="divText2"></div>
                        </div>

                        <div runat="server" id="diva2" class="caption sfb stb"
                            data-x="-100"
                            data-y="375"
                            data-hoffset="0"
                            data-speed="500"
                            data-start="1900"
                            data-easing="easeOutBack">
                        </div>
                        <div class="caption skewfromright skewtoright"
                            data-x="right"
                            data-y="130"
                            data-hoffset="176"
                            data-speed="500"
                            data-start="1900"
                            data-easing="easeOutBack">
                            <div class="tools" runat="server" id="rightPic2">
                            </div>
                        </div>
                    </li>
                    <!-- SLIDE 3 -->
                    <li data-transition="boxslide" data-slotamount="7">
                        <img src="" alt="slidebg1" runat="server" id="bImg3" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat" />
                        <div class="caption sfr str"
                            data-x="-100"
                            data-y="135"
                            data-speed="700"
                            data-start="1700"
                            data-easing="easeOutBack">
                            <div runat="server" id="divText3"></div>
                        </div>

                        <div runat="server" id="diva3" class="caption sfb stb"
                            data-x="-100"
                            data-y="375"
                            data-hoffset="0"
                            data-speed="500"
                            data-start="1900"
                            data-easing="easeOutBack">
                        </div>
                        <div class="caption skewfromright skewtoright"
                            data-x="right"
                            data-y="130"
                            data-hoffset="176"
                            data-speed="500"
                            data-start="1900"
                            data-easing="easeOutBack">
                            <div class="tools" runat="server" id="rightPic3">
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>

        <div class="container sliderAfterTriangle">
        </div>
        <!--Triangle After Slider-->
    </section>
    <!--Slider-->

    <div class="ServisDetails" runat="server" id="servisDetails">
        <i class="btnClose material-icons ">close</i><asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="updatepanel2" runat="server">

            <ContentTemplate>

                <div id="servisContent" runat="server" class="detailContent col-md-11 col-sm-11 col-xs-11">
                </div>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div runat="server" id="modalsdiv"></div>

    <section class="nr_services row ">

        <div class="container">
            <div class="row sectionTitles">
                <h2 class="sectionTitle">خدمات ما</h2>
                <div class="sectionSubTitle">آنچه ما ارائه می دهیم</div>
            </div>
            <div class="row m0 text-center">

                <div class="owl-one owl-carousel " runat="server" id="ourServises"></div>
            </div>
        </div>
    </section>
    <!--Services-->

    <section id="projects" class="row fullWidth">
        <div class="row sectionTitles m0">
            <h2 class="sectionTitle">پروژه های ما</h2>
            <div class="sectionSubTitle">آخرین کار ها</div>
        </div>
        <div class="ccontainer" id="proj" runat="server"></div>
    </section>
    <!--Projects-->

    <section id="latestPosts" class="row">
        <div class="container">
            <div class="row sectionTitles">
                <h2 class="sectionTitle">آخرین مقالات</h2>
                <div class="sectionSubTitle">جدید ترین ها</div>
            </div>
            <div class="row" runat="server" id="blogsContainer">
            </div>
        </div>
    </section>
    <!--Latest Blog-->

    <section id="testimonials" class="row">
        <div class="container">
            <div class="row sectionTitles">
                <h2 class="sectionTitle whiteTC">استاد کاران برتر</h2>
                <div class="sectionSubTitle whiteTC">از دیددگاه شما</div>
            </div>
            <div class="row">
                <div id="best" class="owl-carousel owl-two testimonialSlider row m0" runat="server">
                </div>
            </div>
        </div>
    </section>
    <!--Testimonials-->

    <!--Elements-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="map" runat="server">
    <%-- <div class="col-xs-10">
        <div class="mapBox">
            <div class="weHere">
                <p>ما اینجا هستیم</p>
            </div>
            <div id="map" style="width: 100%; margin-left: auto; margin-right: auto; height: 350px;"></div>
        </div>
    </div>--%>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Scripts" runat="server">
    <%--<script src="../_Scripts/slick.js"></script>--%>
    <script src="<%= ResolveUrl("vendors/owl.carousel/js/owl.carousel.min.js")%>"></script>
    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyALleZ3zPaYhtpL2fLhiYKxEEbnQscPw3I"></script>
    <script>

        $(".project").mouseenter(function () {
            $(this).find(".projectName").addClass("dispnone");
        });
        $(".project").mouseleave(function () {
            $(this).find(".projectName").removeClass("dispnone");
        });
        $(document).ready(function () {
            $('.owl-one').owlCarousel({

                loop: true,
                autoplay: true,
                autoplayHoverPause: true,
                autoplayTimeout: 2000,

                responsive: {
                    0: {
                        items: 1

                    },
                    600: {
                        items: 2

                    },
                    1200: {
                        items: 4
                    }
                }
            })
        });
        $(document).ready(function () {
            $('.owl-two').owlCarousel({

                loop: true,
                autoplay: true,
                autoplayHoverPause: true,
                autoplayTimeout: 2000,

                responsive: {
                    0: {
                        items: 1

                    },
                    600: {
                        items: 3

                    },
                    1200: {
                        items: 3
                    }
                }
            })
        });

        //function myFunc() {
        //    $('.ServisDetails').addClass('Active')
        //}
        //$('.btnClose').click(function () {
        //    $('.ServisDetails').removeClass('Active')
        //    $('#servisContent').innerHtml = "";

        //})

        //var myLatlng = new google.maps.LatLng(36.543681, 52.689014);
        //var imagePath = '/_construction/images/Pin-location.png'
        //var mapOptions = {
        //    zoom: 11,
        //    center: myLatlng,
        //    mapTypeId: google.maps.MapTypeId.ROADMAP
        //}

        //var map = new google.maps.Map(document.getElementById('map'), mapOptions);
        ////Callout Content
        //var contentString = 'ما اینجا هستیم';
        ////Set window width + content
        //var infowindow = new google.maps.InfoWindow({
        //    content: contentString,
        //    maxWidth: 500
        //});

        ////Add Marker
        //var marker = new google.maps.Marker({
        //    position: myLatlng,
        //    map: map,
        //    icon: imagePath,
        //    title: 'image title'
        //});

        //google.maps.event.addListener(marker, 'click', function () {
        //    infowindow.open(map, marker);
        //});

        ////Resize Function
        //google.maps.event.addDomListener(window, "resize", function () {
        //    var center = map.getCenter();
        //    google.maps.event.trigger(map, "resize");
        //    map.setCenter(center);
        //});

        //google.maps.event.addDomListener(window, 'load', initialize);
    </script>
</asp:Content>