<%@ Page Title="" Language="C#" MasterPageFile="~/_construction/IndexMaster.Master" AutoEventWireup="true" CodeBehind="Blogs.aspx.cs" Inherits="WebPages._construction.Blogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="pageStyles" runat="server">
    <link href="../_Styles/Blogs.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="pageCover" class="row blogPage">

        <div class="row pageTitle">مقاله ها</div>
        <div class="row pageBreadcrumbs">
            <ol class="breadcrumb" style="direction: rtl">
                <li><a href="index.html" style="color: #F7B71E">خانه</a></li>
                <li><span class="fa fa-arrow-left" style="color: #ffffff" aria-hidden="true"></span></li>
                <li class="active" style="color: #F7B71E">مقاله ها</li>
            </ol>
        </div>
    </section>

    <section id="blogs" class="row">
        <div class="container" style="text-align: right">
            <div class="row" id="easyPaginate">
                <ul runat="server" id="UlArticles">
                </ul>
            </div>

        </div>

    </section>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="Scripts" runat="server">
    <script src="../_Scripts/jquery.easyPaginate.js"></script>
    <script>
        var lastNum = $('.next').prev().attr('rel');
        $('#easyPaginate').easyPaginate({
            paginateElement: 'li', firstButtonText: "اولین صفحه", lastButtonText: "آخرین صفحه", prevButtonText: "قبلی", nextButtonText: "بعدی",
            elementsPerPage: 3,
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
    </script>
</asp:Content>
