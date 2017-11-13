<%@ Page Title="" Language="C#" MasterPageFile="~/_construction/IndexMaster.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="WebPages._construction.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>درباره ما</title>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="pageStyles" runat="server">
    <style>
        div#container {
            min-height: 500px;
        }

        .InnerContainer {
            min-height: 300px;
            box-shadow: 5px 4px 10px #858585;
            padding: 1px 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="container">
        <div class="InnerContainer" style="padding: 0 25px;">
            <div class="row sectionTitles">
                <h2 class="sectionTitle"></h2>
                <div class="sectionSubTitle">درباره ما</div>
                <div runat="server" id="aboutUs" style="text-align: right; direction: rtl; padding: 40px 80px; margin-top: 15px;">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="map" runat="server">
    <div class="col-xs-10">
        <div class="mapBox">
            <div class="weHere">
                <p>ما اینجا هستیم</p>
            </div>
            <div id="map" style="width: 100%; margin-left: auto; margin-right: auto; height: 350px;"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="Scripts" runat="server">
    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyALleZ3zPaYhtpL2fLhiYKxEEbnQscPw3I"></script>
    <script>
        $('.active').removeClass('active');
        $('.AboutUs').addClass('active');
        var myLatlng = new google.maps.LatLng(36.543681, 52.689014);
        var imagePath = '/_construction/images/Pin-location.png'
        var mapOptions = {
            zoom: 11,
            center: myLatlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        }

        var map = new google.maps.Map(document.getElementById('map'), mapOptions);
        //Callout Content
        var contentString = 'ما اینجا هستیم';
        //Set window width + content
        var infowindow = new google.maps.InfoWindow({
            content: contentString,
            maxWidth: 500
        });

        //Add Marker
        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map,
            icon: imagePath,
            title: 'image title'
        });

        google.maps.event.addListener(marker, 'click', function () {
            infowindow.open(map, marker);
        });

        //Resize Function
        google.maps.event.addDomListener(window, "resize", function () {
            var center = map.getCenter();
            google.maps.event.trigger(map, "resize");
            map.setCenter(center);
        });

        //google.maps.event.addDomListener(window, 'load', initialize);
    </script>
</asp:Content>